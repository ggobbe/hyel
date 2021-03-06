using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1f2d, 0x1f2e )]
	public class ImmobileScroll : SpellScroll
	{
		[Constructable]
		public ImmobileScroll() : this( 1 )
		{
		}

		[Constructable]
		public ImmobileScroll( int amount ) : base( 817, 0x1f2d, amount )
		{
		         Name = "Immobilium";
		         Hue = 0x53;			
		}

		public ImmobileScroll( Serial ser ) : base(ser)
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
        //    return base.Dupe( new ImmobileScroll( amount ), amount );
        //}
	}
}