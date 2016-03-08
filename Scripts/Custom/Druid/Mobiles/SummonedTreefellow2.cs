using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a treefellow corpse" )]
	public class SummonedTreefellow2 : BaseCreature
	{
		[Constructable]
		public SummonedTreefellow2() : base( AIType.AI_Melee, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "a treefellow";
			Body = 301;
			BaseSoundID = 442;

			SetStr( 196, 220 );
			SetDex( 31, 55 );
			SetInt( 66, 90 );

			SetHits( 200, 300 );

			SetDamage( 12, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 30, 35 );
			SetResistance( ResistanceType.Energy, 20, 30 );

		SetSkill( SkillName.MagicResist, 65.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 90.0 );

			VirtualArmor = 60;
			ControlSlots = 1;
		}

		public SummonedTreefellow2( Serial serial ) : base( serial )
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