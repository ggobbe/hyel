using System;
using Server.Network;
using Server.Gumps;
using Server.Spells;
using Server.Mobiles;
namespace Server.Items
{
   public class MagisterSpellbook : Spellbook
   {
      public override SpellbookType SpellbookType{ get{ return SpellbookType.Magister; } }
      public override int BookOffset{ get{ return 901; } }
      public override int BookCount{ get{ return 10; } }

      //public override Item Dupe( int amount )
      //{
      //   Spellbook book = new magiSpellbook();

      //   book.Content = this.Content;

      //   return base.Dupe( book, amount );
      //}

      [Constructable]
      public MagisterSpellbook() : this( (ulong)0 )
      {
 			LootType = LootType.Newbied;     	
      }

      [Constructable]
      public MagisterSpellbook( ulong content ) : base( content, 3834 )
      {
         Hue = 1861;
         Name = "Livre du Magister";
         LootType = LootType.Newbied;
      }

      public override void OnDoubleClick( Mobile from )
      {

   	    if ( from is PlayerMobile)// && (((PlayerMobile)from).PAnim ))
        
        {
        	if ( from.InRange( GetWorldLocation(), 1 ) )
        	         	    		
          		from.CloseGump( typeof( MagisterSpellbookGump ) );
            from.SendGump(new MagisterSpellbookGump(from, this));
        }
        
        else if ( from is PlayerMobile && (from.Skills[SkillName.Necromancy].Value <= 70))//retrait du from.Mage
		{
 
        	if ( from.InRange( GetWorldLocation(), 1 ) )


                from.CloseGump(typeof(MagisterSpellbookGump));
            from.SendGump(new MagisterSpellbookGump(from, this));
        }	    	 
         	 
         	 
         else from.SendMessage("Vous n'etes pas Mage vous ne savez pas lire ce livre");
	 
      }

      public MagisterSpellbook( Serial serial ) : base( serial )
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
