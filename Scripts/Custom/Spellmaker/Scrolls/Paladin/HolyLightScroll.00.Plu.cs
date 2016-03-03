using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HolyLightScroll : SpellScroll
    {
        [Constructable]
        public HolyLightScroll()
            : this(1)
        {
        }

        [Constructable]
        public HolyLightScroll(int amount)
            : base(206, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Holy Light scroll";
        }

        public HolyLightScroll(Serial serial)
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
