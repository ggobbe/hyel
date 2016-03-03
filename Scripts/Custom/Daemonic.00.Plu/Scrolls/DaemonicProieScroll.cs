using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DaemonicProieScroll : SpellScroll
   {
      [Constructable]
      public DaemonicProieScroll() : this( 1 )
      {
      }

      [Constructable]
      public DaemonicProieScroll( int amount ) : base( 131, 0xE39 )
      {
         Name = "Proie";
         Hue = 34;
      }

      public DaemonicProieScroll(Serial serial)
          : base(serial)
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
      //   return base.Dupe( new ProieScroll( amount ), amount );
      //}
   }
}
