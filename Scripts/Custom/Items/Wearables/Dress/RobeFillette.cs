using System;

namespace Server.Items
{
    public class RobeFillette : BaseOuterTorso
    {
        [Constructable]
        public RobeFillette()
            : this(0)
        {
        }

        [Constructable]
        public RobeFillette(int hue)
            : base(0x2D1C, hue)
        {
            Weight = 3.0;
            Name = "Robe";
        }

        public RobeFillette(Serial serial)
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