using System;

namespace Server.Items
{
    public class RobeNecromancien : BaseOuterTorso
    {
        [Constructable]
        public RobeNecromancien()
            : this(0)
        {
        }

        [Constructable]
        public RobeNecromancien(int hue)
            : base(0x2CB8, hue)
        {
            Weight = 3.0;
            Name = "Robe de Necromancien";
        }

        public RobeNecromancien(Serial serial)
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