using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class DaemonicFeuzoneScroll : SpellScroll
   {
      [Constructable]
      public DaemonicFeuzoneScroll() : this( 1 )
      {
      }

      [Constructable]
      public DaemonicFeuzoneScroll( int amount ) : base( 133, 0xE39 )
      {
         Name = "Vague de Feu";
         Hue = 34;
      }

      public DaemonicFeuzoneScroll(Serial serial)
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
      //   return base.Dupe( new FeuzoneScroll( amount ), amount );
      //}
   }
}
