using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DaemonicVampireScroll : SpellScroll
   {
      [Constructable]
      public DaemonicVampireScroll() : this( 1 )
      {
      }

      [Constructable]
      public DaemonicVampireScroll( int amount ) : base( 135, 0xE39 )
      {
         Name = "Lame Vampire";
         Hue = 34;
      }

      public DaemonicVampireScroll(Serial serial)
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
      //   return base.Dupe( new LVampireScroll( amount ), amount );
      //}
   }
}
