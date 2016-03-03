using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1f2d, 0x1f2e )]
	public class TrialByFireScroll : SpellScroll
	{
		[Constructable]
		public TrialByFireScroll() : this( 1 )
		{
			
		}

		[Constructable]
		public TrialByFireScroll( int amount ) : base( 812, 0x1f2d, amount )
		{
		         Name = "Halo de flamme";
		         Hue = 0x53;			
		}

		public TrialByFireScroll( Serial serial ) : base( serial )
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
        //    return base.Dupe( new TrialByFireScroll( amount ), amount );
        //}
	}
}