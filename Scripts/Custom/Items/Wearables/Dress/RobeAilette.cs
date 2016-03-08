﻿using System;

namespace Server.Items
{
    public class RobeAilette : BaseOuterTorso
    {
        [Constructable]
        public RobeAilette() : this(0)
        {
        }

        [Constructable]
        public RobeAilette(int hue) : base(0x2CAE, hue)
        {
            Weight = 3.0;
            Name = "Robe à Ailettes";
        }

        public RobeAilette(Serial serial)
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