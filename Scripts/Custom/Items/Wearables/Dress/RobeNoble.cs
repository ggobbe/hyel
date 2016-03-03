using System;

namespace Server.Items
{
    public class RobeNoble : BaseOuterTorso
    {
        [Constructable]
        public RobeNoble()
            : this(0)
        {
        }

        [Constructable]
        public RobeNoble(int hue)
            : base(0x2CB3, hue)
        {
            Weight = 3.0;
            Name = "Robe de Noble";
        }

        public RobeNoble(Serial serial)
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