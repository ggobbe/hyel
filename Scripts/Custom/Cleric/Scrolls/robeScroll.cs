using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1f2d, 0x1f2e )]
	public class RobeScroll : SpellScroll
	{
		[Constructable]
		public RobeScroll() : this( 1 )
		{
		}

		[Constructable]
		public RobeScroll( int amount ) : base( 820, 0x1f2d, amount )
		{
		         Name = "Robe Divine";
		         Hue = 0x53;			
		}

		public RobeScroll( Serial ser ) : base(ser)
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
        //    return base.Dupe( new RobeScroll( amount ), amount );
        //}
	}
}