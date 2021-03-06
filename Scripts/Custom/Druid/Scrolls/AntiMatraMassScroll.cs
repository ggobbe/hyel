using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class AntiMatraMassScroll : SpellScroll
	{
		[Constructable]
		public AntiMatraMassScroll() : this( 1 )
		{
		}

		[Constructable]
		public AntiMatraMassScroll( int amount ) : base( 748, 0xE39 )
		{
			Name = "AntiMatra de masse";
         Hue = 0x58B;
		}

		public AntiMatraMassScroll( Serial serial ) : base( serial )
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
        //    return base.Dupe( new AntiMatraMassScroll( amount ), amount );
        //}
		public override void OnDoubleClick( Mobile from )
		{
            if (from is PlayerMobile)// && ((PlayerMobile)from).Druidisme )
			{
				base.OnDoubleClick(from);
			}
			else
			{
				from.SendMessage ("Vous devez �tre druide pour pouvoir lancer cela");
				return;
			}
		}
	}
}