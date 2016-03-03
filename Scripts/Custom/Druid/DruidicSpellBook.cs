using System;
using Server.Network;
using Server.Gumps;
using Server.Spells;
using Server.Mobiles;
namespace Server.Items
{
   public class DruidSpellbook : Spellbook
   {
      public override SpellbookType SpellbookType{ get{ return SpellbookType.Druid; } }
      public override int BookOffset{ get{ return 701; } }
      public override int BookCount{ get{ return 49; } }

      //public override Item Dupe( int amount )
      //{
      //   Spellbook book = new DruidicSpellbook();

      //   book.Content = this.Content;

      //   return base.Dupe( book, amount );
      //}

      [Constructable]
      public DruidSpellbook() : this( (ulong)0 )
      {
      }

      [Constructable]
      public DruidSpellbook( ulong content ) : base( content, 0xEFA )
      {
         Hue = 0x48C;
         Name = "Livre de la Nature";
      }

      public override void OnDoubleClick( Mobile from )
      {
     
        // if ( from is PlayerMobile && (((PlayerMobile)from).PAnim ))     
        //{
          if (from is PlayerMobile && from.InRange(GetWorldLocation(), 1))
            {
         	    		
          		from.CloseGump( typeof( DruidicSpellbookGump ) );
          		from.SendGump( new DruidicSpellbookGump( from, this ) );
          	}    
     
     
     
        //else  if ((from is PlayerMobile && ((PlayerMobile)from).Druidisme ))
        //{
        //    if ( from.InRange( GetWorldLocation(), 1 ) )
        	 
         	    		
        //        from.CloseGump( typeof( DruidicSpellbookGump ) );
        //        from.SendGump( new DruidicSpellbookGump( from, this ) );
        //    }	    	 
         	 
         	 
        // else from.SendMessage("Vous n'etes pas druide vous ne savez pas lire ce livre");
	 
      }

      public DruidSpellbook(Serial serial)
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
      }
   }
}
