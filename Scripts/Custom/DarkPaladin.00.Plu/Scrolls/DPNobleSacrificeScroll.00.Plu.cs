using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DPNobleSacrificeScroll : SpellScroll
    {
        [Constructable]
        public DPNobleSacrificeScroll()
            : this(1)
        {
        }

        [Constructable]
        public DPNobleSacrificeScroll(int amount)
            : base(227, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Dark Noble Sacrifice Scroll";
        }

        public DPNobleSacrificeScroll(Serial serial)
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
