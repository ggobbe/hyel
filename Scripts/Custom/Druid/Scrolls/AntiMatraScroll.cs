using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class AntiMatraScroll : SpellScroll
	{
		[Constructable]
		public AntiMatraScroll() : this( 1 )
		{
		}

		[Constructable]
		public AntiMatraScroll( int amount ) : base( 749, 0xE39 )
		{
			Name = "AntiMatra";
         Hue = 0x58B;
		}

		public AntiMatraScroll( Serial serial ) : base( serial )
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
        //    return base.Dupe( new AntiMatraScroll( amount ), amount );
        //}
		public override void OnDoubleClick( Mobile from )
		{
            if (from is PlayerMobile)// && ((PlayerMobile)from).Druidisme )
			{
				base.OnDoubleClick(from);
			}
			else
			{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
			}
		}
	}
}