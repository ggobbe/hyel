using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
   public class flowerOfEarthScroll : SpellScroll
   {
      [Constructable]
      public flowerOfEarthScroll() : this( 1 )
      {
      }

      [Constructable]
      public flowerOfEarthScroll( int amount ) : base( 730, 0xE39 )
      {
         Name = "FLeurs";
         Hue = 0x58B;
      }

      public flowerOfEarthScroll( Serial serial ) : base( serial )
      {
      		ItemID=0xE39;
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
      //   return base.Dupe( new flowerOfEarthScroll( amount ), amount );
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
