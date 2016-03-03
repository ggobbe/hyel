using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DPHolyLightScroll : SpellScroll
    {
        [Constructable]
        public DPHolyLightScroll()
            : this(1)
        {
        }

        [Constructable]
        public DPHolyLightScroll(int amount)
            : base(226, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Dark Holy Light scroll";
        }

        public DPHolyLightScroll(Serial serial)
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
