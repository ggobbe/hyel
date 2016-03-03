using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class cometeScroll : SpellScroll
   {
      [Constructable]
      public cometeScroll() : this( 1 )
      {
      }

      [Constructable]
      public cometeScroll( int amount ) : base( 906, 0xE39 )
      {
         Name = "La Comete";
         Hue = 0x27;
      }

      public cometeScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new cometeScroll( amount ), amount );
      //}
   }
}
