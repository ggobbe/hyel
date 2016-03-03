using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
   public class MushroomGatewayScroll : SpellScroll
   {
      [Constructable]
      public MushroomGatewayScroll() : this( 1 )
      {
      }

      [Constructable]
      public MushroomGatewayScroll( int amount ) : base( 714, 0xE39 )
      {
         Name = "Mushroom Gateway";
         Hue = 0x58B;
      }

      public MushroomGatewayScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new MushroomGatewayScroll( amount ), amount );
      //}
      public override void OnDoubleClick( Mobile from )
		{
            if (from is PlayerMobile)// && ((PlayerMobile)from).Druidisme )
			{
				base.OnDoubleClick(from);
			}
			else
			{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
			}
		}
   }
}
