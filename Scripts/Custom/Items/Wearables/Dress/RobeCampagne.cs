//pas d'anim liée bonne
using System;

namespace Server.Items
{
    public class RobeCampagne : BaseOuterTorso
    {
        [Constructable]
        public RobeCampagne()
            : this(0)
        {
        }

        [Constructable]
        public RobeCampagne(int hue)
            : base(0x2CC6, hue)
        {
            Weight = 3.0;
            Name = "Robe";
        }

        public RobeCampagne(Serial serial)
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