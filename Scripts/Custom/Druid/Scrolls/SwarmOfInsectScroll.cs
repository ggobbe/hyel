using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
   public class SwarmOfInsectsScroll : SpellScroll
   {
      [Constructable]
      public SwarmOfInsectsScroll() : this( 1 )
      {
      }

      [Constructable]
      public SwarmOfInsectsScroll( int amount ) : base( 707, 0xE39 )
      {
         Name = "Swarm Of Insects";
         Hue = 0x58B;
      }

      public SwarmOfInsectsScroll( Serial serial ) : base( serial )
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
      //   return base.Dupe( new SwarmOfInsectsScroll( amount ), amount );
      //}
      public override void OnDoubleClick( Mobile from )
		{
            if (from is PlayerMobile)// && ((PlayerMobile)from).Druidisme )
			{
				base.OnDoubleClick(from);
			}
			else
			{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
			}
		}
   }
}
