using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1f2d, 0x1f2e )]
	public class HammerOfFaithScroll : SpellScroll
	{
		[Constructable]
		public HammerOfFaithScroll() : this( 1 )
		{
			
		}

		[Constructable]
		public HammerOfFaithScroll( int amount ) : base( 805, 0x1f2d, amount )
		{
		         Name = "Marteau Divin";
		         Hue = 0x53;			
		}

		public HammerOfFaithScroll( Serial serial ) : base( serial )
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
        //    return base.Dupe( new HammerOfFaithScroll( amount ), amount );
        //}
	}
}