using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1f2d, 0x1f2e )]
	public class PurgeScroll : SpellScroll
	{
		[Constructable]
		public PurgeScroll() : this( 1 )
		{
			
		}

		[Constructable]
		public PurgeScroll( int amount ) : base( 806, 0x1f2d, amount )
		{
		         Name = "Exorcisme";
		         Hue = 0x53;			
		}

		public PurgeScroll( Serial serial ) : base( serial )
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
        //    return base.Dupe( new PurgeScroll( amount ), amount );
        //}
	}
}