/*Créé par Scriptiz pour le livre de barde */
using System;
using Server.Network;
using Server.Gumps;
using Server.Spells;

namespace Server.Items
{
    public class BardeSpellbook : Spellbook
    {
        public override SpellbookType SpellbookType { get { return SpellbookType.Bard; } }
        public override int BookOffset { get { return 301; } }
        public override int BookCount { get { return 16; } }


        [Constructable]
        public BardeSpellbook()
            : this((ulong)0)
        {
        }

        [Constructable]
        public BardeSpellbook(ulong content)
            : base(content, 0xEFA)
        {
            Hue = 44;
            Name = "Livre de Barde";
        }

        public override void OnDoubleClick(Mobile from)
        {
            Container pack = from.Backpack;

            if (Parent == from || (pack != null && Parent == pack))
            //DisplayTo(from);

            //if ( from.InRange( GetWorldLocation(), 1 ) )
            {
                from.CloseGump(typeof(BardeSpellbookGump));
                from.SendGump(new BardeSpellbookGump(from, this));
            }
            else from.SendLocalizedMessage(500207); // The spellbook must be in your backpack (and not in a container within) to open.


        }

        public BardeSpellbook(Serial serial)
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
