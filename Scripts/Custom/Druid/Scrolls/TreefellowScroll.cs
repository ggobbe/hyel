using System;	
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
   public class TreefellowScroll : SpellScroll
   {
      [Constructable]
      public TreefellowScroll() : this( 1 )
      {
      }

      [Constructable]
      public TreefellowScroll( int amount ) : base( 709, 0xE39 )
      {
         Name = "Summon Treefellow";
         Hue = 0x58B;
      }

      public TreefellowScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new TreefellowScroll( amount ), amount );
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
