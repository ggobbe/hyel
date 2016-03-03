using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class cloneScroll : SpellScroll
   {
      [Constructable]
      public cloneScroll() : this( 1 )
      {
      }

      [Constructable]
      public cloneScroll( int amount ) : base( 907, 0xE39 )
      {
         Name = "CloneMagus";
         Hue = 0x27;
      }

      public cloneScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new cloneScroll( amount ), amount );
      //}
   }
}
