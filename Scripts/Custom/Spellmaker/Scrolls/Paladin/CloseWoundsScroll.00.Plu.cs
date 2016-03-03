using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class CloseWoundsScroll : SpellScroll
    {
        [Constructable]
        public CloseWoundsScroll()
            : this(1)
        {
        }

        [Constructable]
        public CloseWoundsScroll(int amount)
            : base(201, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Close wounds scroll";
        }

        public CloseWoundsScroll(Serial serial)
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
