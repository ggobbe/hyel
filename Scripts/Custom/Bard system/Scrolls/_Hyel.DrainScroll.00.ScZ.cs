/* Créé par Scriptiz pour le livre de sorts de barde (c) Plume */
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DrainScroll : SpellScroll
    {
        [Constructable]
        public DrainScroll()
            : this(1)
        {
        }

        [Constructable]
        public DrainScroll(int amount)
            : base(308, 0x1F65, amount)
        {
            Hue = 44;
            Name = "Drain";
        }

        public DrainScroll(Serial serial)
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