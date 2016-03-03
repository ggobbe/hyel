using System;

namespace Server.Items
{
    public class RobeMageFemme : BaseOuterTorso
    {
        [Constructable]
        public RobeMageFemme()
            : this(0)
        {
        }

        [Constructable]
        public RobeMageFemme(int hue)
            : base(0x24F8, hue)
        {
            Weight = 3.0;
            Name = "Robe de Mage";
        }

        public RobeMageFemme(Serial serial)
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