using System;
using Server;
using Server.Items;

namespace Server.Items
{

	[FlipableAttribute( 0x1F2D, 0x1f2e )]
	public class repScroll : SpellScroll
	{
		
		
		[Constructable]
		public repScroll() : this( 1 )
		{
		}

		[Constructable]
		public repScroll( int amount ) : base( 815, 0x1F2D, amount )
		{
		         Name = "Bouclier Divin";
		         Hue = 0x53;					
			
		}

		public repScroll( Serial ser ) : base(ser)
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
        //    return base.Dupe( new repScroll( amount ), amount );
        //}
	}
}