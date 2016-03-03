using System;

namespace Server.Items
{
    public class RobePardessus : BaseOuterTorso
    {
        [Constructable]
        public RobePardessus() : this(0)
        {
        }

        [Constructable]
        public RobePardessus(int hue) : base(0x2CAD, hue)
        {
            Weight = 3.0;
            Name = "Robe à Pardessus";
        }

        public RobePardessus(Serial serial)
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