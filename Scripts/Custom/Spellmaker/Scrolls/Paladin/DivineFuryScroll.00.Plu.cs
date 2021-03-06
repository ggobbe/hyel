﻿using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DivineFuryScroll : SpellScroll
    {
        [Constructable]
        public DivineFuryScroll()
            : this(1)
        {
        }

        [Constructable]
        public DivineFuryScroll(int amount)
            : base(204, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Divine Fury scroll";
        }

        public DivineFuryScroll(Serial serial)
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


