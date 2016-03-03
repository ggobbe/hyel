using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DPEnemyOfOneScroll : SpellScroll
    {
        [Constructable]
        public DPEnemyOfOneScroll()
            : this(1)
        {
        }

        [Constructable]
        public DPEnemyOfOneScroll(int amount)
            : base(225, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Dark Enemy Of One scroll";
        }

        public DPEnemyOfOneScroll(Serial serial)
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


