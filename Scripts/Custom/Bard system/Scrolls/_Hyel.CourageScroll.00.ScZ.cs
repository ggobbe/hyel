/* Créé par Scriptiz pour le livre de sorts de barde (c) Plume */
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class CourageScroll : SpellScroll
    {
        [Constructable]
        public CourageScroll()
            : this(1)
        {
        }

        [Constructable]
        public CourageScroll(int amount)
            : base(314, 0x1F65, amount)
        {
            Hue = 44;
            Name = "Courage";
        }

        public CourageScroll(Serial serial)
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