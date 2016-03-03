using System;

namespace Server.Items
{
    public class RobeEchancre : BaseOuterTorso
    {
        [Constructable]
        public RobeEchancre() : this(0)
        {
        }

        [Constructable]
        public RobeEchancre(int hue) : base(0x2CB1, hue)
        {
            Weight = 3.0;
            Name = "Robe Échancrée";
        }

        public RobeEchancre(Serial serial)
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