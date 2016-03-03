using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class RemoveCurseScroll : SpellScroll
    {
        [Constructable]
        public RemoveCurseScroll()
            : this(1)
        {
        }

        [Constructable]
        public RemoveCurseScroll(int amount)
            : base(208, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Remove Curse Scroll";
        }

        public RemoveCurseScroll(Serial serial)
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
