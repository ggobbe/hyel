using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
   public class SomnisScroll : SpellScroll
   {
      [Constructable]
      public SomnisScroll() : this( 1 )
      {
      }

      [Constructable]
      public SomnisScroll( int amount ) : base( 724, 0xE39 )
      {
         Name = "Somnis";
         Hue = 0x58B;
      }

      public SomnisScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new SomnisScroll( amount ), amount );
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
