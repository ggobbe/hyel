using System;
using Server;
using Server.Items;

namespace Server.Items
{

	[FlipableAttribute( 0x1F2D, 0x1f2e )]
	public class InviteScroll : SpellScroll
	{
		
		
		[Constructable]
		public InviteScroll() : this( 1 )
		{
		}

		[Constructable]
		public InviteScroll( int amount ) : base( 823, 0x1F2D, amount )
		{
		         Name = "Invitate Corpus";
		         Hue = 0x53;					
			
		}

		public InviteScroll( Serial ser ) : base(ser)
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
        //    return base.Dupe( new InviteScroll( amount ), amount );
        //}
	}
}