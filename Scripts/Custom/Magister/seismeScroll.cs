using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class seismeScroll : SpellScroll
   {
      [Constructable]
      public seismeScroll() : this( 1 )
      {
      }

      [Constructable]
      public seismeScroll( int amount ) : base( 910, 0xE39 )
      {
         Name = "Seisme";
         Hue = 0x27;
      }

      public seismeScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new seismeScroll( amount ), amount );
      //}
   }
}
