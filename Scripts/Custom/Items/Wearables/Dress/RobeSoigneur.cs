using System;

namespace Server.Items
{
    public class RobeSoigneur : BaseOuterTorso
    {
        [Constructable]
        public RobeSoigneur(): this(0)
        {
        }

        [Constructable]
        public RobeSoigneur(int hue): base(0x24EE, hue)
        {
            Weight = 3.0;
            Name = "Robe de soigneur";
        }

        public RobeSoigneur(Serial serial)
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
    public class RobeSoigneurCapuche : BaseOuterTorso
    {
        [Constructable]
        public RobeSoigneurCapuche()
            : this(0)
        {
        }

        [Constructable]
        public RobeSoigneurCapuche(int hue)
            : base(0x24EF, hue)
        {
            Weight = 3.0;
            Name = "Robe de soigneur";
        }

        public RobeSoigneurCapuche(Serial serial)
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