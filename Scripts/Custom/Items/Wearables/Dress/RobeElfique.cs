using System;

namespace Server.Items
{
    public class RobeElfique : BaseOuterTorso
    {
        [Constructable]
        public RobeElfique()
            : this(0)
        {
        }

        [Constructable]
        public RobeElfique(int hue)
            : base(0x2D1E, hue)
        {
            Weight = 3.0;
            Name = "Robe elfique";
        }

        public RobeElfique(Serial serial)
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