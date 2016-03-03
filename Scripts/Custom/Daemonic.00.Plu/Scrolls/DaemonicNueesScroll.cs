using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DaemonicNueesScroll : SpellScroll
   {
      [Constructable]
      public DaemonicNueesScroll() : this( 1 )
      {
      }

      [Constructable]
      public DaemonicNueesScroll( int amount ) : base( 137, 0xE39 )
      {
         Name = "Nuees Malefique";
         Hue = 34;
      }

      public DaemonicNueesScroll(Serial serial)
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
      //   return base.Dupe( new NueesDScroll( amount ), amount );
      //}
   }
}
