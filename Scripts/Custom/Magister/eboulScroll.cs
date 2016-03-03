using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class eboulScroll : SpellScroll
   {
      [Constructable]
      public eboulScroll() : this( 1 )
      {
      }

      [Constructable]
      public eboulScroll( int amount ) : base( 904, 0xE39 )
      {
         Name = "Eboulement";
         Hue = 0x27;
      }

      public eboulScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new eboulScroll( amount ), amount );
      //}
   }
}
