using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1f2d, 0x1f2e )]
	public class LumiereScroll : SpellScroll
	{
		[Constructable]
		public LumiereScroll() : this( 1 )
		{
		}

		[Constructable]
		public LumiereScroll( int amount ) : base( 813, 0x1f2d, amount )
		{
		         Name = "Divine luminosite";
		         Hue = 0x53;			
		}

		public LumiereScroll( Serial ser ) : base(ser)
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
        //    return base.Dupe( new LumiereScroll( amount ), amount );
        //}
	}
}