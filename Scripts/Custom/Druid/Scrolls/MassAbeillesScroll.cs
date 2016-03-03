using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class MassAbeillesScroll : SpellScroll
	{
		[Constructable]
		public MassAbeillesScroll() : this( 1 )
		{
		}

		[Constructable]
		public MassAbeillesScroll( int amount ) : base( 745, 0x226D, amount )
		{
		}

		public MassAbeillesScroll( Serial serial ) : base( serial )
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
        //    return base.Dupe( new MassAbeillesScroll( amount ), amount );
        //}
	}
}