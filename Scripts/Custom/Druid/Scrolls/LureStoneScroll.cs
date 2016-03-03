using System;	
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
   public class LureStoneScroll : SpellScroll
   {
      [Constructable]
      public LureStoneScroll() : this( 1 )
      {
      }

      [Constructable]
      public LureStoneScroll( int amount ) : base( 712, 0xE39 )
      {
         Name = "Lure Stone";
         Hue = 0x58B;
      }

      public LureStoneScroll( Serial serial ) : base( serial )
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

      //public override Item Dupe( int amount )
      //{
      //   return base.Dupe( new LureStoneScroll( amount ), amount );
      //}
      public override void OnDoubleClick( Mobile from )
		{
            if (from is PlayerMobile)// && ((PlayerMobile)from).Druidisme )
			{
				base.OnDoubleClick(from);
			}
			else
			{
				from.SendMessage ("Vous devez �tre druide pour pouvoir lancer cela");
				return;
			}
		}
   }
}
