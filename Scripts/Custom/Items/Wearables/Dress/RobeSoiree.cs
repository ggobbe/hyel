using System;

namespace Server.Items
{
    public class RobeSoiree : BaseOuterTorso
    {
        [Constructable]
        public RobeSoiree()
            : this(0)
        {
        }

        [Constructable]
        public RobeSoiree(int hue)
            : base(0x2CB4, hue)
        {
            Weight = 3.0;
            Name = "Robe de Soirée";
        }

        public RobeSoiree(Serial serial)
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