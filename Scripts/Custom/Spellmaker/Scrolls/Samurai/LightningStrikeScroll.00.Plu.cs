﻿using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class LightningStrikeScroll : SpellScroll
    {
        [Constructable]
        public LightningStrikeScroll()
            : this(1)
        {
        }

        [Constructable]
        public LightningStrikeScroll(int amount)
            : base(404, 0x1F65, amount)
        {
            Hue = 47;
            Name = "Lightning Strike Scroll";
        }

        public LightningStrikeScroll(Serial serial)
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