using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class glaceScroll : SpellScroll
   {
      [Constructable]
      public glaceScroll() : this( 1 )
      {
      }

      [Constructable]
      public glaceScroll( int amount ) : base( 905, 0xE39 )
      {
         Name = "Blizard";
         Hue = 0x27;
      }

      public glaceScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new glaceScroll( amount ), amount );
      //}
   }
}
