using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DaemonicMaleficioScroll : SpellScroll
   {
      [Constructable]
      public DaemonicMaleficioScroll() : this( 1 )
      {
      }

      [Constructable]
      public DaemonicMaleficioScroll( int amount ) : base( 136, 0xE39 )
      {
         Name = "Maleficio";
         Hue = 34;
      }

      public DaemonicMaleficioScroll(Serial serial)
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
      //   return base.Dupe( new MaleficioScroll( amount ), amount );
      //}
   }
}
