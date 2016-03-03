//pas d'anim liée bonne
using System;

namespace Server.Items
{
    public class RobeCampagneMotif : BaseOuterTorso
    {
        [Constructable]
        public RobeCampagneMotif()
            : this(0)
        {
        }

        [Constructable]
        public RobeCampagneMotif(int hue)
            : base(0x2CC5, hue)
        {
            Weight = 3.0;
            Name = "Robe";
        }

        public RobeCampagneMotif(Serial serial)
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