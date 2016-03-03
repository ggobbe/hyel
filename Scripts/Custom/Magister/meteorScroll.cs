using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class meteorScroll : SpellScroll
   {
      [Constructable]
      public meteorScroll() : this( 1 )
      {
      }

      [Constructable]
      public meteorScroll( int amount ) : base( 908, 0xE39 )
      {
         Name = "Poussieres d'etoiles";
         Hue = 0x27;
      }

      public meteorScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new meteorScroll( amount ), amount );
      //}
   }
}
