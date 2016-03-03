using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DPRemoveCurseScroll : SpellScroll
    {
        [Constructable]
        public DPRemoveCurseScroll()
            : this(1)
        {
        }

        [Constructable]
        public DPRemoveCurseScroll(int amount)
            : base(228, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Dark Remove Curse Scroll";
        }

        public DPRemoveCurseScroll(Serial serial)
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
