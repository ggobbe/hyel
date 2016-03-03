using System;
using Server.Network;
using Server.Spells;
using Server.Mobiles;
using Server.Gumps;
namespace Server.Items
{
	public class DarkPaladinSpellBook : Spellbook
	{
		public override SpellbookType SpellbookType{ get{ return SpellbookType.DarkPaladin; } }
		public override int BookOffset{ get{ return 220; } }
		public override int BookCount{ get{ return 10; } }

        //public override Item Dupe( int amount )
        //{
        //    Spellbook book = new DarkPaladinSpellBook();

        //    book.Content = this.Content;

        //    return base.Dupe( book, amount );
        //}

		[Constructable]
		public DarkPaladinSpellBook() : this( (ulong)0 ) //0x3ff
		{
			Name = "Livre du Paladin Maudit";
			Hue = 0x835;
		}

		[Constructable]
		public DarkPaladinSpellBook( ulong content ) : base( content, 8788 )
		{
			Layer = Layer.Invalid;
		}

     public override void OnDoubleClick( Mobile from )
      {
         if ( from is PlayerMobile && (from.Skills[SkillName.Chivalry].Value >= 40))
		{
         	if ( from.InRange( GetWorldLocation(), 1 ) )


                from.CloseGump(typeof(DarkPaladinSpellBookGump));
            from.SendGump(new DarkPaladinSpellBookGump(from, this));
          	}	    	 
         	 
         	 
         else from.SendMessage("Vous n'etes pas Paladin vous ne savez pas lire ce livre");
	 
      }


     public DarkPaladinSpellBook(Serial serial)
         : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			Layer = Layer.Invalid;
		}
	}
}
