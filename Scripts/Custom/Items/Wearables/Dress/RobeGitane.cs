using System;

namespace Server.Items
{
    public class RobeGitane : BaseOuterTorso
    {
        [Constructable]
        public RobeGitane() : this(0)
        {
        }

        [Constructable]
        public RobeGitane(int hue) : base(0x2CAF, hue)
        {
            Weight = 3.0;
            Name = "Robe Gitane";
        }

        public RobeGitane(Serial serial)
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