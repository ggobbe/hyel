//pas d'anim liée bonne
using System;

namespace Server.Items
{
    public class RobeArcaniste : BaseOuterTorso
    {
        [Constructable]
        public RobeArcaniste()
            : this(0)
        {
        }

        [Constructable]
        public RobeArcaniste(int hue)
            : base(0x24F9, hue)
        {
            Weight = 3.0;
            Name = "Robe d'Arcaniste";
        }

        public RobeArcaniste(Serial serial)
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