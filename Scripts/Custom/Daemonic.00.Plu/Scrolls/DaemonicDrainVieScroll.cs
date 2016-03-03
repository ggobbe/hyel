using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DaemonicDrainVieScroll : SpellScroll
   {
      [Constructable]
      public DaemonicDrainVieScroll() : this( 1 )
      {
      }

      [Constructable]
      public DaemonicDrainVieScroll( int amount ) : base( 132, 0xE39 )
      {
         Name = "Vampire";
         Hue = 34;
      }

      public DaemonicDrainVieScroll(Serial serial)
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
      //   return base.Dupe( new DrainVieScroll( amount ), amount );
      //}
   }
}
