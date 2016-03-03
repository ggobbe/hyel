using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class foudreScroll : SpellScroll
   {
      [Constructable]
      public foudreScroll() : this( 1 )
      {
      }

      [Constructable]
      public foudreScroll( int amount ) : base( 903, 0xE39 )
      {
         Name = "Foudre Celeste";
         Hue = 0x27;
      }

      public foudreScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new foudreScroll( amount ), amount );
      //}
   }
}
