﻿using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HonorableExecutionScroll : SpellScroll
    {
        [Constructable]
        public HonorableExecutionScroll()
            : this(1)
        {
        }

        [Constructable]
        public HonorableExecutionScroll(int amount)
            : base(400, 0x1F65, amount)
        {
            Hue = 47;
            Name = "HonorableExecution Scroll";
        }

        public HonorableExecutionScroll(Serial serial)
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
