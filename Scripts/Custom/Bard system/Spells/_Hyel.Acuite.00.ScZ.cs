/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class AcuiteSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Acuite",
            "La musique illumine mes jours"
            );
        public override SpellCircle Circle { get { return SpellCircle.Second; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(0.0); } }
        public override double RequiredSkill { get { return 10.0; } }
        public override int RequiredMana { get { return 15; } }

        public AcuiteSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (Caster.Spell != null)
                Caster.Spell.OnCasterHurt();

            if (Caster.BeginAction(typeof(AcuiteSpell)))
            {
                Caster.BeginAction(typeof(AcuiteSpell));

                Caster.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                Caster.PlaySound(0x1E6);

                Caster.LightLevel = 99;

                Caster.SendMessage("Votre vision s'affine.");

                new InternalTimer(Caster).Start();
            }
            else
            {
                Caster.SendMessage("Votre cible est déjà sous l'effet de ce sort !");
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Caster;

            public InternalTimer(Mobile caster)
                : base(TimeSpan.FromSeconds(0))
            {
                Skill peace = caster.Skills[SkillName.Peacemaking];
                Skill music = caster.Skills[SkillName.Musicianship];

                peace.Update();
                music.Update();

                int time = (int)(((int)peace.Value) + ((int)music.Value / 2));

                Delay = TimeSpan.FromSeconds(time);
                Priority = TimerPriority.OneSecond;

                m_Caster = caster;
            }

            protected override void OnTick()
            {
                m_Caster.LightLevel = 0;
                m_Caster.SendMessage("Votre peau revient à la normale !");
                m_Caster.EndAction(typeof(AcuiteSpell));
                m_Caster.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                m_Caster.PlaySound(0x1E6);
            }
        }
    }
}
