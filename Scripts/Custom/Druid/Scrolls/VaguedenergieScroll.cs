using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class VaguedenergieScroll : SpellScroll
	{
		[Constructable]
		public VaguedenergieScroll() : this( 1 )
		{
		}

		[Constructable]
		public VaguedenergieScroll( int amount ) : base( 746, 0x226D, amount )
		{
		}

		public VaguedenergieScroll( Serial serial ) : base( serial )
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
        //    return base.Dupe( new VaguedenergieScroll( amount ), amount );
        //}
	}
}