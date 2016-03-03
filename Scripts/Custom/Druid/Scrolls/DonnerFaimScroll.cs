using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class DonnerFaimScroll : SpellScroll
	{
		[Constructable]
		public DonnerFaimScroll() : this( 1 )
		{
		}

		[Constructable]
		public DonnerFaimScroll( int amount ) : base( 729, 0xE39 )
		{
			         Name = "Donner faim";
        			 Hue = 0x58B;
		}

		public DonnerFaimScroll( Serial serial ) : base( serial )
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
        //    return base.Dupe( new DonnerFaimScroll( amount ), amount );
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
