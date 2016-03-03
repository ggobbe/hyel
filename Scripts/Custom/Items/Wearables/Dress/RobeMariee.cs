using System;

namespace Server.Items
{
    public class RobeMariee : BaseOuterTorso
    {
        [Constructable]
        public RobeMariee()
            : this(0)
        {
        }

        [Constructable]
        public RobeMariee(int hue)
            : base(0x2D20, hue)
        {
            Weight = 3.0;
            Name = "Robe de mariee";
        }

        public RobeMariee(Serial serial)
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