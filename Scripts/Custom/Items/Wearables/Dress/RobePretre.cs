using System;

namespace Server.Items
{
    public class RobePretre : BaseOuterTorso
    {
        [Constructable]
        public RobePretre()
            : this(0)
        {
        }

        [Constructable]
        public RobePretre(int hue)
            : base(0x24F7, hue)
        {
            Weight = 3.0;
            Name = "Robe de Pretre";
        }

        public RobePretre(Serial serial)
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
    public class RobePretreCopie : BaseOuterTorso
    {
        [Constructable]
        public RobePretreCopie()
            : this(0)
        {
        }

        [Constructable]
        public RobePretreCopie(int hue)
            : base(0x24F2, hue)
        {
            Weight = 3.0;
            Name = "Robe de Pretre";
        }

        public RobePretreCopie(Serial serial)
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
    public class RobePretreCapuche : BaseOuterTorso
    {
        [Constructable]
        public RobePretreCapuche()
            : this(0)
        {
        }

        [Constructable]
        public RobePretreCapuche(int hue)
            : base(0x24F3, hue)
        {
            Weight = 3.0;
            Name = "Robe de Pretre";
        }

        public RobePretreCapuche(Serial serial)
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