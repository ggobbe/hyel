using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a water vortex corpse " )]
	public class watervortex : BaseCreature
	{
		public override bool DeleteCorpseOnDeath{ get{ return Summoned; } }
		public override double DispelDifficulty{ get{ return 120.0; } }
		public override double DispelFocus{ get{ return 100.0; } }

        //public override double GetValueFrom( Mobile m, FightMode acqType, bool bPlayerOnly )
        //{
        //    return (m.Int + m.Skills[SkillName.Magery].Value) / Math.Max( GetDistanceToSqrt( m ), 1.0 );
        //}

		[Constructable]
		public watervortex() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
			Name = "water vortex";
			Body = 573;
			

//			SetStr( 150 );
//			SetDex( 150 );
//			SetInt( 200 );

//			SetHits( 100 );

			SetStr( 326, 355 );
			SetDex( 266, 285 );
			SetInt( 171, 195 );

			SetHits( 196, 213 );
			SetStam( 200 );
			SetMana( 200 );

			SetDamage( 16, 24 );	//11,19

			SetDamageType( ResistanceType.Physical, 130 );	//75
			SetDamageType( ResistanceType.Fire, 0 );
			SetDamageType( ResistanceType.Cold, 0 );
			SetDamageType( ResistanceType.Poison, 0 );
			SetDamageType( ResistanceType.Energy, 0 );

			SetResistance( ResistanceType.Physical, 75, 100 );
			SetResistance( ResistanceType.Fire, 10, 40 );
			SetResistance( ResistanceType.Cold, 10, 40 );
			SetResistance( ResistanceType.Poison, 60, 70 );	// 10, 40 
			SetResistance( ResistanceType.Energy, 10, 40 );

			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 120.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 120.0 );

			Fame = 4500;
			Karma = 4500;

			VirtualArmor = 55;	//35
			ControlSlots = 2;
			CanSwim = true;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override int GetAngerSound()
		{
			return 0x15;
		}

		public override int GetAttackSound()
		{
			return 0x28;
		}

		public watervortex( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 0;
		}
	}
}
