/* Créé par Scriptiz pour le livre de sorts de barde (c) Plume */
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class ProtectionBScroll : SpellScroll
    {
        [Constructable]
        public ProtectionBScroll()
            : this(1)
        {
        }

        [Constructable]
        public ProtectionBScroll(int amount)
            : base(309, 0x1F65, amount)
        {
            Hue = 44;
            Name = "Protection";
        }

        public ProtectionBScroll(Serial serial)
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