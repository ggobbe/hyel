//pas d'anim liée bonne

using System;

namespace Server.Items
{
    public class RobeAraignee : BaseOuterTorso
    {
        [Constructable]
        public RobeAraignee()
            : this(0)
        {
        }

        [Constructable]
        public RobeAraignee(int hue)
            : base(0x24F6, hue)
        {
            Weight = 3.0;
            Name = "Robe d'Araignee";
        }

        public RobeAraignee(Serial serial)
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