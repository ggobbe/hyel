using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DPSacredJourneyScroll : SpellScroll
    {
        [Constructable]
        public DPSacredJourneyScroll()
            : this(1)
        {
        }

        [Constructable]
        public DPSacredJourneyScroll(int amount)
            : base(229, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Dark Sacred Journey Scroll";
        }

        public DPSacredJourneyScroll(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }


    }
}
