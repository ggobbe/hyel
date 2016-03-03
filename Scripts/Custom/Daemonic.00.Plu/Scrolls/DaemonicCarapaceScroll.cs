using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DaemonicCarapaceScroll : SpellScroll
   {
      [Constructable]
      public DaemonicCarapaceScroll() : this( 1 )
      {
      }

      [Constructable]
      public DaemonicCarapaceScroll( int amount ) : base( 134, 0xE39 )
      {
         Name = "Carapace";
         Hue = 34;
      }

      public DaemonicCarapaceScroll(Serial serial)
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
      //   return base.Dupe( new CarapaceScroll( amount ), amount );
      //}
   }
}
