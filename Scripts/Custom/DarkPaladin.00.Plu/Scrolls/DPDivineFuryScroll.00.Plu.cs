using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DPDivineFuryScroll : SpellScroll
    {
        [Constructable]
        public DPDivineFuryScroll()
            : this(1)
        {
        }

        [Constructable]
        public DPDivineFuryScroll(int amount)
            : base(204, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Dark Divine Fury scroll";
        }

        public DPDivineFuryScroll(Serial serial)
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


