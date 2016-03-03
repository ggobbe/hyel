using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1f2d, 0x1f2e )]
	public class MassoinScroll : SpellScroll
	{
		[Constructable]
		public MassoinScroll() : this( 1 )
		{
		}

		[Constructable]
		public MassoinScroll( int amount ) : base( 825, 0x1f2d, amount )
		{
		         Name = "Pluie Divine";
		         Hue = 0x53;			
		}

		public MassoinScroll( Serial ser ) : base(ser)
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
        //    return base.Dupe( new MassoinScroll( amount ), amount );
        //}
	}
}