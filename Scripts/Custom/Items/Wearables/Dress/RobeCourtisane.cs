using System;

namespace Server.Items
{
    public class RobeCourtisane : BaseOuterTorso
    {
        [Constructable]
        public RobeCourtisane()
            : this(0)
        {
        }

        [Constructable]
        public RobeCourtisane(int hue)
            : base(0x2D1D, hue)
        {
            Weight = 3.0;
            Name = "Robe de Courtisane";
        }

        public RobeCourtisane(Serial serial)
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