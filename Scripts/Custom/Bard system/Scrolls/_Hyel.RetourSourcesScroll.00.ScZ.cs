/* Créé par Scriptiz pour le livre de sorts de barde (c) Plume */
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class RetourSourcesScroll : SpellScroll
    {
        [Constructable]
        public RetourSourcesScroll()
            : this(1)
        {
        }

        [Constructable]
        public RetourSourcesScroll(int amount)
            : base(313, 0x1F65, amount)
        {
            Hue = 44;
            Name = "Retour Aux Sources";
        }

        public RetourSourcesScroll(Serial serial)
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