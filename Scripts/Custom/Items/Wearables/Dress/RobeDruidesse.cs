//pas d'anim liée bonne
using System;

namespace Server.Items
{
    public class RobeDruidesse : BaseOuterTorso
    {
        [Constructable]
        public RobeDruidesse()
            : this(0)
        {
        }

        [Constructable]
        public RobeDruidesse(int hue)
            : base(0x2CB5, hue)
        {
            Weight = 3.0;
            Name = "Robe de druidesse";
        }

        public RobeDruidesse(Serial serial)
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