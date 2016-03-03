using System;

namespace Server.Items
{
    public class RobeNecromant : BaseOuterTorso
    {
        [Constructable]
        public RobeNecromant()
            : this(0)
        {
        }

        [Constructable]
        public RobeNecromant(int hue)
            : base(0x24F0, hue)
        {
            Weight = 3.0;
            Name = "Robe de Necromant";
        }

        public RobeNecromant(Serial serial)
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

    public class RobeNecromantCapuche : BaseOuterTorso
    {
        [Constructable]
        public RobeNecromantCapuche()
            : this(0)
        {
        }

        [Constructable]
        public RobeNecromantCapuche(int hue)
            : base(0x24F1, hue)
        {
            Weight = 3.0;
            Name = "Robe de Necromant";
        }

        public RobeNecromantCapuche(Serial serial)
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