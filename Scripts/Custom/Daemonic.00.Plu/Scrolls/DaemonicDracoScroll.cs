using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DaemonicDracoScroll : SpellScroll
   {
      [Constructable]
      public DaemonicDracoScroll() : this( 1 )
      {
      }

      [Constructable]
      public DaemonicDracoScroll( int amount ) : base( 139, 0xE39 )
      {
         Name = "DracoLich";
         Hue = 34;
      }

      public DaemonicDracoScroll(Serial serial)
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
      //   return base.Dupe( new DracoScroll( amount ), amount );
      //}
   }
}
