/* Créé par Scriptiz pour le livre de sorts de barde (c) Plume */
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class CarapaceScroll : SpellScroll
    {
        [Constructable]
        public CarapaceScroll()
            : this(1)
        {
        }

        [Constructable]
        public CarapaceScroll(int amount)
            : base(312, 0x1F65, amount)
        {
            Hue = 44;
            Name = "Carapace";
        }

        public CarapaceScroll(Serial serial)
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