using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
    public class BoneSewingKit : BaseTool
    {
        public override CraftSystem CraftSystem { get { return DefBoneSewing.CraftSystem; } }

        [Constructable]
        public BoneSewingKit()
            : base(0xF9D)
        {
            Weight = 2.0;
            Hue = 48;
        }

        [Constructable]
        public BoneSewingKit(int uses)
            : base(uses, 0xF9D)
        {
            Weight = 2.0;
        }

        public BoneSewingKit(Serial serial)
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