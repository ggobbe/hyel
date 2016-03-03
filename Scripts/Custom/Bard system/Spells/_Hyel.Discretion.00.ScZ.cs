/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class DiscretionSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Discretion",
            "Fort simple est cette melodie, n en tenez compte"
            );

        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3.0); } }
        public override double RequiredSkill { get { return 30.0; } }
        public override int RequiredMana { get { return 20; } }
        public override SpellCircle Circle { get { return SpellCircle.Fourth; } }
        public DiscretionSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (Caster.Spell != null)
                Caster.Spell.OnCasterHurt();

            Caster.FixedParticles(0x376A, 10, 15, 5045, EffectLayer.Waist);
            Caster.PlaySound(0x3C4);

            if (!Caster.Hidden)
            {
                Caster.Hidden = true;
                Caster.SendMessage("Vous vous dissimulez dans l'ombre.");
            }
            else
            {
                Caster.Hidden = false;
                Caster.SendMessage("Vous redevenez visible aux yeux de tous.");
            }

            //new InternalTimer(Caster).Start();
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Caster;

            public InternalTimer(Mobile caster)
                : base(TimeSpan.FromSeconds(0))
            {
                /*
                int time = 5;

                Delay = TimeSpan.FromMinutes(time);
                Priority = TimerPriority.OneMinute;

                m_Caster = caster;
                */
            }

            protected override void OnTick()
            {
                /*
                m_Caster.Hidden = false;               

                m_Caster.SendMessage("Vous redevenez visible aux yeux de tous.");
                m_Caster.FixedParticles(0x376A, 10, 15, 5045, EffectLayer.Waist);
                m_Caster.PlaySound(0x3C4);
                */
            }
        }
    }
}
