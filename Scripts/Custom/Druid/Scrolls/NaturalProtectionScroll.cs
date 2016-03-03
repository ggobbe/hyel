using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
   public class NaturalProtectionScroll : SpellScroll
   {
      [Constructable]
      public NaturalProtectionScroll() : this( 1 )
      {
      }

      [Constructable]
      public NaturalProtectionScroll( int amount ) : base( 740, 0xE39 )
      {
         Name = "Protection Naturelle";
         Hue = 0x58B;
      }

      public NaturalProtectionScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new NaturalProtectionScroll( amount ), amount );
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
