using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DaemonicMedusaScroll : SpellScroll
   {
      [Constructable]
      public DaemonicMedusaScroll() : this( 1 )
      {
      }

      [Constructable]
      public DaemonicMedusaScroll( int amount ) : base( 138, 0xE39 )
      {
         Name = "Medusa";
         Hue = 34;
      }

      public DaemonicMedusaScroll(Serial serial)
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
      //   return base.Dupe( new MedusaScroll( amount ), amount );
      //}
   }
}
