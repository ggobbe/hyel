using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class Clonez : BaseCreature
	{
	
		[Constructable]
		public Clonez() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			
		Body = 777;
			Title = " The Mystic Lama Herder";
			


		
		
		
		}
		[CommandProperty( AccessLevel.GameMaster )] 
public override bool ClickTitle{ get{ return false; } }
        public Clonez(Serial serial)
            : base(serial)
		{
		} 
   

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
