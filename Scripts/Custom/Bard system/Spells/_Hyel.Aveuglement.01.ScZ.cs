/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Spells.Barde
{
    public class AveuglementSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Aveuglement",
            "Cruels sont les gens envers les aveugles"
            );
        public override SpellCircle Circle { get { return SpellCircle.Second; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(0.0); } }
        public override double RequiredSkill { get { return 5.0; } }
        public override int RequiredMana { get { return 15; } }

        public AveuglementSpell(Mobile caster, Item scroll)
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

                if (m.BeginAction(typeof(AveuglementSpell)))
                {
                    if (m is PlayerMobile)
                    {
                        // calculons le temps d'aveuglement
                        Skill provo = Caster.Skills[SkillName.Provocation];
                        Skill music = Caster.Skills[SkillName.Musicianship];
                        provo.Update();
                        music.Update();
                        int time_p = (int)(provo.Value / 5);
                        int time_m = (int)(music.Value / 2);
                        int time = time_p + time_m;

                        m.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                        m.PlaySound(0x1E6);

                        m.BeginAction(typeof(AveuglementSpell));

                        m.SendGump(new NuitGump((PlayerMobile)m, time));
                        m.SendMessage("Vous êtes aveugler par une force inconnue.");
                        m.Emote("*aveugle*");
                    }
                    else
                    {
                        m.SendMessage("Cette commande ne s'applique que sur les joueurs.");
                    }
                }
                else
                {
                    Caster.SendMessage("Votre cible est déjà sous l'effet de ce sort !");
                }
            }
            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private AveuglementSpell m_Owner;

            public InternalTarget(AveuglementSpell owner)
                : base(5, true, TargetFlags.Harmful)
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
