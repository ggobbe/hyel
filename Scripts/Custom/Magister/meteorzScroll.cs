using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class meteorzScroll : SpellScroll
   {
      [Constructable]
      public meteorzScroll() : this( 1 )
      {
      }

      [Constructable]
      public meteorzScroll( int amount ) : base( 909, 0xE39 )
      {
         Name = "Apocalypse";
         Hue = 0x27;
      }

      public meteorzScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new meteorzScroll( amount ), amount );
      //}
   }
}
