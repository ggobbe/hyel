using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class MarqueScroll : SpellScroll
	{
		[Constructable]
		public MarqueScroll() : this( 1 )
		{
		}

		[Constructable]
		public MarqueScroll( int amount ) : base( 731, 0xE39 )
		{
			         Name = "Marque";
        			 Hue = 0x58B;
		}
		public MarqueScroll( Serial serial ) : base( serial )
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
        //    return base.Dupe( new MarqueScroll( amount ), amount );
        //}
		
		public override void OnDoubleClick( Mobile from )
		{
            if (from is PlayerMobile)// && ((PlayerMobile)from).Druidisme )
			{
				base.OnDoubleClick(from);
			}
			else
			{
				from.SendMessage ("Vous devez �tre druide pour pouvoir lancer cela");
				return;
			}
		}
		
	}
}
