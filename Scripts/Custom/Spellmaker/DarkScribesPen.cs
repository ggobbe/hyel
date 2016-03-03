using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
    [FlipableAttribute( 0x0FBF, 0x0FC0)]
    public class DarkScribesPen : BaseTool 
    {
        public override CraftSystem CraftSystem { get { return DefDarkSpellmaker.CraftSystem; } }

        public override int LabelNumber { get { return 1063565; } } // dark scribe's pen

        [Constructable]
        public DarkScribesPen()
            : base(0x0FBF)
        {
            Hue = 0x76B;
            Weight = 1.0;
        }

        [Constructable]
        public DarkScribesPen(int uses)
            : base(uses, 0x0FBF)
        {
            Hue = 0x76B;
            Weight = 1.0;
        }

        public DarkScribesPen(Serial serial)
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

            if (Weight == 2.0)
                Weight = 1.0;
        }
    }
}