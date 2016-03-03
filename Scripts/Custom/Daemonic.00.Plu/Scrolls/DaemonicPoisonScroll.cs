using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DaemonicPoisonScroll : SpellScroll
   {
      [Constructable]
      public DaemonicPoisonScroll() : this( 1 )
      {
      }

      [Constructable]
      public DaemonicPoisonScroll( int amount ) : base( 130, 0xE39 )
      {
         Name = "Boule de Poison";
         Hue = 34;
      }

      public DaemonicPoisonScroll(Serial serial)
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
      //   return base.Dupe( new BpoisonScroll( amount ), amount );
      //}
   }
}
