using System;
using Server.Network;
using Server.Gumps;
using Server.Spells;
using Server.Mobiles;
namespace Server.Items
{
   public class ClercSpellbook : Spellbook
   {
      public override SpellbookType SpellbookType{ get{ return SpellbookType.Clerc; } }
      public override int BookOffset{ get{ return 801; } }
      public override int BookCount{ get{ return 25; } }

      //public override Item Dupe( int amount )
      //{
      //   Spellbook book = new ClercSpellbook();

      //   book.Content = this.Content;

      //   return base.Dupe( book, amount );
      //}

      [Constructable]
      public ClercSpellbook() : this( (ulong)0 )
      {
 			LootType = LootType.Newbied;     	
      }

      [Constructable]
      public ClercSpellbook( ulong content ) : base( content, 3834 )
      {
         Hue = 0x54D;
         Name = "Livre Saint";
         LootType = LootType.Newbied;
      }

      public override void OnDoubleClick( Mobile from )
      {

   	    if ( from is PlayerMobile)// && (((PlayerMobile)from).PAnim ))
		{
         	if ( from.InRange( GetWorldLocation(), 1 ) )
        	 
         	    		
          		from.CloseGump( typeof( ClercSpellbookGump ) );
          		from.SendGump( new ClercSpellbookGump( from, this ) );
          	}

        else if (from is PlayerMobile)// && ((PlayerMobile)from).Pretre ))
		{
         	if ( from.InRange( GetWorldLocation(), 1 ) )
        	 
         	    		
          		from.CloseGump( typeof( ClercSpellbookGump ) );
          		from.SendGump( new ClercSpellbookGump( from, this ) );
          	}	    	 
         	 
         	 
         else from.SendMessage("Vous n'etes pas Pretre vous ne savez pas lire ce livre");
	 
      }

      public ClercSpellbook( Serial serial ) : base( serial )
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
      }
   }
}
