using System;

namespace Server.Items
{
    public class RobeManche : BaseOuterTorso
    {
        [Constructable]
        public RobeManche()
            : this(0)
        {
        }

        [Constructable]
        public RobeManche(int hue)
            : base(0x2D1F, hue)
        {
            Weight = 3.0;
            Name = "Robe à longues manches";
        }

        public RobeManche(Serial serial)
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