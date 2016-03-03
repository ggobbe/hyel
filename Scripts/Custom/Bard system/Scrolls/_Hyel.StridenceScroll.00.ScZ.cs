/* Créé par Scriptiz pour le livre de sorts de barde (c) Plume */
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class StridenceScroll : SpellScroll
    {
        [Constructable]
        public StridenceScroll()
            : this(1)
        {
        }

        [Constructable]
        public StridenceScroll(int amount)
            : base(305, 0x1F65, amount)
        {
            Hue = 44;
            Name = "Stridence";
        }

        public StridenceScroll(Serial serial)
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