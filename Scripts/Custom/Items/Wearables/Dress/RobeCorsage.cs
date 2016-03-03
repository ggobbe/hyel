using System;

namespace Server.Items
{
    public class RobeCorsage : BaseOuterTorso
    {
        [Constructable]
        public RobeCorsage() : this(0)
        {
        }

        [Constructable]
        public RobeCorsage(int hue) : base(0x2CAB, hue)
        {
            Weight = 3.0;
            Name = "Robe à corsage";
        }

        public RobeCorsage(Serial serial)
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