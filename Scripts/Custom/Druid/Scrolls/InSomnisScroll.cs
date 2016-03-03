using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
   public class InSomnisScroll : SpellScroll
   {
      [Constructable]
      public InSomnisScroll() : this( 1 )
      {
      }

      [Constructable]
      public InSomnisScroll( int amount ) : base( 725, 0xE39 )
      {
         Name = "InSomnis";
         Hue = 0x58B;
      }

      public InSomnisScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new InSomnisScroll( amount ), amount );
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
