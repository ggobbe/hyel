using System;

namespace Server.Items
{
    public class RobeSexy : BaseOuterTorso
    {
        [Constructable]
        public RobeSexy() : this(0)
        {
        }

        [Constructable]
        public RobeSexy(int hue) : base(0x267F, hue)
        {
            Weight = 3.0;
            Name = "Robe sexy";
        }

        public RobeSexy(Serial serial)
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