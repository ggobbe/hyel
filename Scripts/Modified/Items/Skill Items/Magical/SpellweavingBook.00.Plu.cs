using System;
using Server.Network;
using Server.Spells;
using Server.Gumps;

namespace Server.Items
{
	public class SpellweavingBook : Spellbook
	{
		public override SpellbookType SpellbookType{ get{ return SpellbookType.Arcanist; } }
		public override int BookOffset{ get{ return 600; } }
		public override int BookCount{ get{ return 16; } }

		[Constructable]
		public SpellweavingBook() : this( (ulong)0 )
		{
		}

		[Constructable]
		public SpellweavingBook( ulong content ) : base( content, 0x3637 )
		{
			Hue = 0x8A2;

			Layer = Layer.OneHanded;
		}
        public override void OnDoubleClick(Mobile from)
        {
            Container pack = from.Backpack;

            if (Parent == from || (pack != null && Parent == pack))
            //DisplayTo(from);

            //if ( from.InRange( GetWorldLocation(), 1 ) )
            {
                from.CloseGump(typeof(BardeSpellbookGump));
                from.SendGump(new SpellweavingBookGump(from, this));
            }
            else from.SendLocalizedMessage(500207); // The spellbook must be in your backpack (and not in a container within) to open.


        }

		public SpellweavingBook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}