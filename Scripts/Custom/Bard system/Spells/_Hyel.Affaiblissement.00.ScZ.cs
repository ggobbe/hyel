using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class AffaiblissementSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Affaiblissement",
            "Voici la triste histoire d un homme maigre"
            );
        public override SpellCircle Circle { get { return SpellCircle.Second; } }
         public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2 - (double)((Caster.Int / 10) / 120)); } }

        public override double RequiredSkill { get { return 0.0; } }
        public override int RequiredMana { get { return 10; } }

        public AffaiblissementSpell(Mobile caster, Item scroll)
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

                if (m.BeginAction(typeof(AffaiblissementSpell)))
                {
                    m.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                    m.PlaySound(0x1E6);

                    m.BeginAction(typeof(AffaiblissementSpell));

                    Skill provo = Caster.Skills[SkillName.Provocation];
                    provo.Update();

                    ResistanceMod faiblesse = new ResistanceMod(ResistanceType.Physical, -10 - (int)(provo.Value / 10));
                    m.AddResistanceMod(faiblesse);
                    m.SendMessage("Vous vous sentez moins résistant...");

                    new InternalTimer(m, Caster, faiblesse).Start();
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
            private ResistanceMod m_faiblesse;

            public InternalTimer(Mobile target, Mobile caster, ResistanceMod faiblesse)
                : base(TimeSpan.FromSeconds(0))
            {
                Delay = TimeSpan.FromSeconds(30);
                Priority = TimerPriority.OneSecond;

                m_Owner = target;
                m_faiblesse = faiblesse;
            }

            protected override void OnTick()
            {
                m_Owner.RemoveResistanceMod(m_faiblesse);
                m_Owner.SendMessage("Vous êtes à nouveau en pleine forme !");
                m_Owner.EndAction(typeof(AffaiblissementSpell));
                m_Owner.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                m_Owner.PlaySound(0x1E6);
            }
        }

        private class InternalTarget : Target
        {
            private AffaiblissementSpell m_Owner;

            public InternalTarget(AffaiblissementSpell owner)
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
