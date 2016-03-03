using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Corp de Dragon" )]
	public class DracoLich : BaseCreature
	{
		[Constructable]
		public DracoLich () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Draco Lich";
			Body = 104;
			BaseSoundID = 0x488;

			SetStr( 898, 1030 );
			SetDex( 68, 200 );
			SetInt( 488, 620 );

			SetHits( 558, 599 );

			SetDamage( 29, 35 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 75, 80 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 40, 60 );

			SetSkill( SkillName.EvalInt, 80.1, 100.0 );
			SetSkill( SkillName.Magery, 200.0 );
			SetSkill( SkillName.MagicResist, 100.3, 130.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 97.6, 100.0 );

			//Fame = 22500;
			//Karma = -22500;
			ControlSlots = 4;
			VirtualArmor = 40;

			//for ( int i = 0; i < 5; ++i )
			//	PackGem();

			//PackGold( 1000, 1200 );
			//PackMagicItems( 1, 5, 0.70, 0.55 );
		}

		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x480; } }
		public override double DispelDifficulty{ get{ return 0.0; } }
		public override double DispelFocus{ get{ return 0.0; } }
		// TODO: Undead summoning?

		//public override bool AutoDispel{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int Meat{ get{ return 19; } } // where's it hiding these? :)
		//public override int Hides{ get{ return 20; } }
		//public override HideType HideType{ get{ return HideType.Barbed; } }

		public DracoLich( Serial serial ) : base( serial )
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
