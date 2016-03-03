using System;

namespace Server.Items
{
    public class RobeMortuaire : BaseOuterTorso
    {
        [Constructable]
        public RobeMortuaire()
            : this(0)
        {
        }

        [Constructable]
        public RobeMortuaire(int hue)
            : base(0x2CB7, hue)
        {
            Weight = 3.0;
            Name = "Robe Mortuaire";
        }

        public RobeMortuaire(Serial serial)
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