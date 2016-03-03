using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class feufScroll : SpellScroll
   {
      [Constructable]
      public feufScroll() : this( 1 )
      {
      }

      [Constructable]
      public feufScroll( int amount ) : base( 901, 0xE39 )
      {
         Name = "Feu Follet";
         Hue = 0x27;
      }

      public feufScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new feufScroll( amount ), amount );
      //}
   }
}
