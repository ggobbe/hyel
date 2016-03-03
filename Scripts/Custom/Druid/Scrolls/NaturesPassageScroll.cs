using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
   public class NaturesPassageScroll : SpellScroll
   {
      [Constructable]
      public NaturesPassageScroll() : this( 1 )
      {
      }

      [Constructable]
      public NaturesPassageScroll( int amount ) : base( 713, 0xE39 )
      {
         Name = "Nature's Passage";
         Hue = 0x58B;
      }

      public NaturesPassageScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new NaturesPassageScroll( amount ), amount );
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
