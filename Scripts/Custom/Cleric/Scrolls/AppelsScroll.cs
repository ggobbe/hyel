using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1f2d, 0x1f2e )]
	public class AppelsScroll : SpellScroll
	{
		[Constructable]
		public AppelsScroll() : this( 1 )
		{
		}

		[Constructable]
		public AppelsScroll( int amount ) : base( 822, 0x1f2d, amount )
		{
		         Name = "Appeliumis";
		         Hue = 0x53;			
		}

		public AppelsScroll( Serial ser ) : base(ser)
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
        //    return base.Dupe( new AppelsScroll( amount ), amount );
        //}
	}
}