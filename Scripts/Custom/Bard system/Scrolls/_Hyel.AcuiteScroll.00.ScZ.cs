/* Créé par Scriptiz pour le livre de sorts de barde (c) Plume */
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class AcuiteScroll : SpellScroll
    {
        [Constructable]
        public AcuiteScroll()
            : this(1)
        {
        }

        [Constructable]
        public AcuiteScroll(int amount)
            : base(310, 0x1F65, amount)
        {
            Hue = 44;
            Name = "Acuite";
        }

        public AcuiteScroll(Serial serial)
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