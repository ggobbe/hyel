using System;

namespace Server.Items
{
    public class RobeMagister : BaseOuterTorso
    {
        [Constructable]
        public RobeMagister()
            : this(0)
        {
        }

        [Constructable]
        public RobeMagister(int hue)
            : base(0x24F5, hue)
        {
            Weight = 3.0;
            Name = "Robe de Magister";
        }

        public RobeMagister(Serial serial)
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
    public class RobeMagisterCapuche : BaseOuterTorso
    {
        [Constructable]
        public RobeMagisterCapuche()
            : this(0)
        {
        }

        [Constructable]
        public RobeMagisterCapuche(int hue)
            : base(0x24F4, hue)
        {
            Weight = 3.0;
            Name = "Robe de Magister";
        }

        public RobeMagisterCapuche(Serial serial)
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