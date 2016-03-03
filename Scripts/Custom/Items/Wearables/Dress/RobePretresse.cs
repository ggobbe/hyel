using System;

namespace Server.Items
{
    public class RobePretresse : BaseOuterTorso
    {
        [Constructable]
        public RobePretresse()
            : this(0)
        {
        }

        [Constructable]
        public RobePretresse(int hue)
            : base(0x2CB2, hue)
        {
            Weight = 3.0;
            Name = "Robe de Pretresse";
        }

        public RobePretresse(Serial serial)
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