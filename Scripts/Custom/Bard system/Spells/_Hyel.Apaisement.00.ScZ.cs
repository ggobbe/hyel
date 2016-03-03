/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class ApaisementSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Apaisement",
            "Que ma musique allege le poids de mes pieds"
            );
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2.0); } }
        public override double RequiredSkill { get { return 90.0; } }
        public override int RequiredMana { get { return 40; } }

        public ApaisementSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (Caster.Spell != null)
                Caster.Spell.OnCasterHurt();

            Skill peace = Caster.Skills[SkillName.Peacemaking];
            peace.Update();

            Caster.Stam += ((int)peace.Value / 2);

            Caster.FixedParticles(0x376A, 10, 15, 5045, EffectLayer.Waist);
            Caster.PlaySound(0x3C4);
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Caster;

            public InternalTimer(Mobile caster)
                : base(TimeSpan.FromSeconds(0))
            {
                int time = 5;

                Delay = TimeSpan.FromSeconds(time);
                Priority = TimerPriority.OneSecond;

                m_Caster = caster;
            }

            protected override void OnTick()
            {
            }
        }
    }
}
