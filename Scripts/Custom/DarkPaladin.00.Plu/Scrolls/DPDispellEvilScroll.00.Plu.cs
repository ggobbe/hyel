using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DPDispelEvilScroll : SpellScroll
    {
        [Constructable]
        public DPDispelEvilScroll()
            : this(1)
        {
        }

        [Constructable]
        public DPDispelEvilScroll(int amount)
            : base(223, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Dark Dispel Evil scroll";
        }

        public DPDispelEvilScroll(Serial serial)
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

