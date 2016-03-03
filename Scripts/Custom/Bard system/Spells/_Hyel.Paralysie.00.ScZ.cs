/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class ParalysieSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Paralysie",
            "Le pire apres le mutisme est l immobilisme"
            );
        public override SpellCircle Circle { get { return SpellCircle.Fourth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3.0); } }
        public override double RequiredSkill { get { return 30.0; } }
        public override int RequiredMana { get { return 20; } }

        public ParalysieSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                if (m.Spell != null)
                    m.Spell.OnCasterHurt();

                if (m.BeginAction(typeof(ParalysieSpell)))
                {
                    m.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                    m.PlaySound(0x1E6);

                    m.BeginAction(typeof(ParalysieSpell));

                    Skill provo = Caster.Skills[SkillName.Provocation];
                    Skill music = Caster.Skills[SkillName.Musicianship];

                    provo.Update();
                    music.Update();

                    int time_p = (int)(provo.Value / 10);
                    int time_m = (int)(music.Value / 20);
                    int time = time_p + time_m + 5;

                    m.Paralyze(TimeSpan.FromSeconds(time));

                    if ((int)provo.Value > 40)
                    {
                       //empeche d'attaquer
                    }
                    else if ((int)provo.Value > 80)
                    {
                        //empeche de caster
                    }

                    m.SendMessage("Vos actions sont retenues par une force étrange.");

                    new InternalTimer(m, Caster).Start();
                }
                else
                {
                    Caster.SendMessage("Votre cible est déjà sous l'effet de ce sort !");
                }
            }
            FinishSequence();
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Owner;
            private Mobile m_Caster;

            public InternalTimer(Mobile target, Mobile caster)
                : base(TimeSpan.FromSeconds(0))
            {
                Skill provo = caster.Skills[SkillName.Provocation];
                Skill music = caster.Skills[SkillName.Musicianship];

                provo.Update();
                music.Update();

                int time_p = (int)(provo.Value / 10);
                int time_m = (int)(music.Value / 20);
                int time = time_p + time_m + 5;

                Delay = TimeSpan.FromSeconds(time);
                Priority = TimerPriority.OneSecond;

                m_Owner = target;
                m_Caster = caster;
            }

            protected override void OnTick()
            {
                // libère de toute paralysie

                m_Owner.SendMessage("Vous êtes à nouveau libre de vos actes !");
                m_Owner.EndAction(typeof(ParalysieSpell));
                m_Owner.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                m_Owner.PlaySound(0x1E6);
            }
        }

        private class InternalTarget : Target
        {
            private ParalysieSpell m_Owner;

            public InternalTarget(ParalysieSpell owner)
                : base(12, true, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target((Mobile)o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
