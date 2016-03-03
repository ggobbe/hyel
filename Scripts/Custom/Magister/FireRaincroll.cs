using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class FireRainScroll : SpellScroll
   {
      [Constructable]
      public FireRainScroll() : this( 1 )
      {
      }

      [Constructable]
      public FireRainScroll( int amount ) : base( 902, 0xE39 )
      {
         Name = "Pluie de Feu Scroll";
         Hue = 0x27;
      }

      public FireRainScroll(Serial serial): base(serial)
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
      //   return base.Dupe( new bdfsScroll( amount ), amount );
      //}
   }
}
