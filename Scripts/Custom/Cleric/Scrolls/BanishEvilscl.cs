using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1f2d, 0x1f2e )]
	public class BanishEvilScroll : SpellScroll
	{
		[Constructable]
		public BanishEvilScroll() : this( 1 )
		{
			
		}

		[Constructable]
		public BanishEvilScroll( int amount ) : base( 802, 0x1f2d, amount )
		{
		         Name = "Bannir le Mal";
		         Hue = 0x53;			
		}

		public BanishEvilScroll( Serial serial ) : base( serial )
		{
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
        //    return base.Dupe( new BanishEvilScroll( amount ), amount );
        //}
	}
}
