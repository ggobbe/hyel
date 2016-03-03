using System;	
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
   public class MushroomCircleScroll : SpellScroll
   {
      [Constructable]
      public MushroomCircleScroll() : this( 1 )
      {
      }

      [Constructable]
      public MushroomCircleScroll( int amount ) : base( 710, 0xE39 )
      {
         Name = "Stone Circle";
         Hue = 0x58B;
      }

      public MushroomCircleScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new MushroomCircleScroll( amount ), amount );
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
