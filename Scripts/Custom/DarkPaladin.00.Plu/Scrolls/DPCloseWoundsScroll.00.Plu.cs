﻿using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DPCloseWoundsScroll : SpellScroll
    {
        [Constructable]
        public DPCloseWoundsScroll()
            : this(1)
        {
        }

        [Constructable]
        public DPCloseWoundsScroll(int amount)
            : base(221, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Dark Close wounds scroll";
        }

        public DPCloseWoundsScroll(Serial serial)
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
