using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an earth vortex corpse " )]
	public class earthvortex : BaseCreature
	{
		public override bool DeleteCorpseOnDeath{ get{ return Summoned; } }
		public override double DispelDifficulty{ get{ return 120.0; } }
		public override double DispelFocus{ get{ return 100.0; } }

        //public override double GetValueFrom( Mobile m, FightMode acqType, bool bPlayerOnly )
        //{
        //    return (m.Int + m.Skills[SkillName.Magery].Value) / Math.Max( GetDistanceToSqrt( m ), 1.0 );
        //}

		[Constructable]
		public earthvortex() : base( AIType.AI_Melee, FightMode.Evil, 10, 1, 0.4, 0.6 )
		{
			Name = "earth vortex";
			Body = 573;
			Hue = 2911;

//			SetStr( 150 );
//			SetDex( 150 );
//			SetInt( 100 );

//			SetHits( 100 );
			SetStr( 326, 355 );
			SetDex( 266, 285 );
			SetInt( 171, 195 );

			SetHits( 196, 213 );
			SetStam( 200 );

			SetMana( 0 );

			SetDamage( 16, 24  ); //11, 19 

			SetDamageType( ResistanceType.Physical, 130 );	//100
			//SetDamageType( ResistanceType.Fire, 0 );
			//SetDamageType( ResistanceType.Cold, 0 );
			//SetDamageType( ResistanceType.Poison, 0 );
			//SetDamageType( ResistanceType.Energy, 0 );

			SetResistance( ResistanceType.Physical, 75, 100 );
			SetResistance( ResistanceType.Fire, 10,40 );
			SetResistance( ResistanceType.Cold, 10, 40 );
			SetResistance( ResistanceType.Poison, 10, 70 );// 10, 40
			SetResistance( ResistanceType.Energy, 10, 40 );

			SetSkill( SkillName.MagicResist, 99.9 );
			SetSkill( SkillName.Tactics, 99.9 );
			SetSkill( SkillName.Wrestling, 120.0 );
			SetSkill( SkillName.Tactics, 100.0 );

			Fame = 4500;
			Karma = 4500;

			VirtualArmor = 55; //35
			ControlSlots = 2;
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

		public earthvortex( Serial serial ) : base( serial )
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
