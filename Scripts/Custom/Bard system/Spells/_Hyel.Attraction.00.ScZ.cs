/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;
using Server.Mobiles;
using Server.Prompts;
using Server.Gumps;

namespace Server.Spells.Barde
{
    public class AttractionSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Attraction",
            "Viens a moi, muse de cette composition"
            );
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(0.0); } }
        public override double RequiredSkill { get { return 85.0; } }
        public override int RequiredMana { get { return 40; } }

        public AttractionSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (!Caster.HasGump(typeof(Gumps.AttractionGump)))
            {
                Caster.SendGump(new AttractionGump(Caster));
            }
            else
            {
                Caster.CloseGump(typeof(Gumps.AttractionGump));
                Caster.SendGump(new AttractionGump(Caster));
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Caster;

            public InternalTimer(Mobile caster)
                : base(TimeSpan.FromSeconds(0))
            {
            }

            protected override void OnTick()
            {
            }
        }
    }
}
