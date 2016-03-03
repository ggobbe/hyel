using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Regions;

namespace Server.Spells.Daemonic
{
    public class LVampire : DaemonicSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Arme Vampire", "Vanish'Hor Tes",
				-1,
				14154,
				Reagent.Katyl,
				Reagent.BatWing,
				Reagent.GraveDust					
			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(0.0); } }
		//public override int RequiredTithing{ get{ return 5; } }
		public override double RequiredSkill{ get{ return 130.0; } }
		public override int RequiredMana{ get{ return 60; } }
        public override SpellCircle Circle { get { return SpellCircle.First; } }
		public override bool BlocksMovement{ get{ return false; } }
private int m_Hue;
		private string m_Name;
		public LVampire( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.PlaySound( 0x300 );
			m_Name=null;
			BaseWeapon weapon = Caster.Weapon as BaseWeapon;
			
			if ( weapon == null || weapon is Fists )
			{
				Caster.SendLocalizedMessage( 501078 ); // You must be holding a weapon.
			}
			else if ( CheckSequence() )
			{

			if ( weapon.Name == "Arme Vampire")
			{
				Caster.SendMessage( "Votre Arme Explose" );
				weapon.Delete();
			}
				if ( Caster.BeginAction( typeof( LVampire ) ) )
				{
					if(this.Scroll!=null)
				Scroll.Consume();
				m_Hue=weapon.Hue;
				m_Name=weapon.Name;
				weapon.Name="Arme Vampire";
				weapon.Hue=2981;
				weapon.Attributes.WeaponDamage += 20;
				weapon.Attributes.AttackChance += 100;
				weapon.Cursed = true;
				weapon.Consecrated = true;					
				Caster.PlaySound( 0xff );
				//Caster.PlaySound( 0x108 );
				Caster.FixedParticles( 0x373A, 1, 15, 9913, 67, 7, EffectLayer.Head );



//pentacle
			Effects.SendLocationEffect( new Point3D( Caster.X - 1, Caster.Y - 3, Caster.Z  ), Caster.Map, 6229, 45, 0, 0 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 2, Caster.Y - 2, Caster.Z  ), Caster.Map, 6229, 45, 0, 0 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 1, Caster.Y + 1, Caster.Z  ), Caster.Map, 6229, 45, 0, 0 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 2, Caster.Y + 2, Caster.Z  ), Caster.Map, 6229, 45, 0, 0 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 3, Caster.Y - 1, Caster.Z  ), Caster.Map, 6229, 45, 0, 0 );				

			Effects.SendLocationEffect( new Point3D( Caster.X - 3, Caster.Y - 2, Caster.Z  ), Caster.Map, 0x1CF9, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 3, Caster.Y - 1, Caster.Z  ), Caster.Map, 0x1CF8, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 3, Caster.Y + 0, Caster.Z  ), Caster.Map, 0x1CF7, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 3, Caster.Y + 1, Caster.Z  ), Caster.Map, 0x1CF6, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 3, Caster.Y + 2, Caster.Z  ), Caster.Map, 0x1CF5, 45, 2406, 5 );

			Effects.SendLocationEffect( new Point3D( Caster.X - 2, Caster.Y -3, Caster.Z  ), Caster.Map, 0x1CFB, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 2, Caster.Y - 2, Caster.Z  ), Caster.Map, 0x1CFA, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 2, Caster.Y - 1, Caster.Z  ), Caster.Map, 0x1D09, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 2, Caster.Y + 0, Caster.Z  ), Caster.Map, 0x1D08, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 2, Caster.Y + 1, Caster.Z  ), Caster.Map, 0x1D07, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 2, Caster.Y + 2, Caster.Z  ), Caster.Map, 0x1CF4, 45, 2406, 5 );

			Effects.SendLocationEffect( new Point3D( Caster.X - 1, Caster.Y - 3, Caster.Z  ), Caster.Map, 0x1CFC, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 1, Caster.Y - 2, Caster.Z  ), Caster.Map, 0x1D0A, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 1, Caster.Y - 1, Caster.Z  ), Caster.Map, 0x1D11, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 1, Caster.Y + 0, Caster.Z  ), Caster.Map, 0x1D10, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 1, Caster.Y + 1, Caster.Z  ), Caster.Map, 0x1D06, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X - 1, Caster.Y + 2, Caster.Z  ), Caster.Map, 0x1CF3, 45, 2406, 5 );

			Effects.SendLocationEffect( new Point3D( Caster.X + 0, Caster.Y - 3, Caster.Z  ), Caster.Map, 0x1CFD, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 0, Caster.Y - 2, Caster.Z  ), Caster.Map, 0x1D0B, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 0, Caster.Y - 1, Caster.Z  ), Caster.Map, 0x1D12, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 0, Caster.Y + 0, Caster.Z  ), Caster.Map, 0x1D0F, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 0, Caster.Y + 1, Caster.Z  ), Caster.Map, 0x1D05, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 0, Caster.Y + 2, Caster.Z  ), Caster.Map, 0x1CF2, 45, 2406, 5 );

			Effects.SendLocationEffect( new Point3D( Caster.X + 1, Caster.Y - 3, Caster.Z  ), Caster.Map, 0x1CFE, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 1, Caster.Y - 2, Caster.Z  ), Caster.Map, 0x1D0C, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 1, Caster.Y - 1, Caster.Z  ), Caster.Map, 0x1D0D, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 1, Caster.Y + 0, Caster.Z  ), Caster.Map, 0x1D0E, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 1, Caster.Y + 1, Caster.Z  ), Caster.Map, 0x1D04, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 1, Caster.Y + 2, Caster.Z  ), Caster.Map, 0x1CF1, 45, 2406, 5 );

			Effects.SendLocationEffect( new Point3D( Caster.X + 2, Caster.Y - 3, Caster.Z  ), Caster.Map, 0x1CFF, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 2, Caster.Y - 2, Caster.Z  ), Caster.Map, 0x1D00, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 2, Caster.Y - 1, Caster.Z  ), Caster.Map, 0x1D01, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 2, Caster.Y + 0, Caster.Z  ), Caster.Map, 0x1D02, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( Caster.X + 2, Caster.Y + 1, Caster.Z  ), Caster.Map, 0x1D03, 45, 2406, 5 );

//pentacle


				//IEntity from = new Entity( Serial.Zero, new Point3D( Caster.X, Caster.Y, Caster.Z ), Caster.Map );
				//IEntity to = new Entity( Serial.Zero, new Point3D( Caster.X, Caster.Y, Caster.Z + 50 ), Caster.Map );
				//Effects.SendMovingParticles( from, to, 0x13B1, 1, 0, false, false, 33, 3, 9501, 1, 0, EffectLayer.Head, 0x100 );
				StopTimer( Caster );

						Timer t = new InternalTimer( Caster, weapon, m_Hue, m_Name );

						m_Timers[Caster] = t;

						t.Start();
				}
					else if ( !Caster.CanBeginAction( typeof( LVampire )))
					{
				DoFizzle();
					}
			}

			FinishSequence();
			//Caster.Target = new InternalTarget( this );
		}

		/*public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			return SpellHelper.CheckTravel( Caster, TravelCheckType.Mark );
		}*/


		private static Hashtable m_Timers = new Hashtable();

		public static bool StopTimer( Mobile m )
		{
			Timer t = (Timer)m_Timers[m];

			if ( t != null )
			{
				t.Stop();
				m_Timers.Remove( m );
			}

			return ( t != null );
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Owner;
			private BaseWeapon m_Weapon;
			private int m_weaponhue;
			private string m_Name;

			public InternalTimer( Mobile owner, BaseWeapon weapon, int m_Hue, string m_WeaponName ) : base( TimeSpan.FromSeconds( 0 ) )
			{
				m_Owner = owner;
				m_Weapon=weapon;
				m_weaponhue=m_Hue;
				m_Name=m_WeaponName;

				int val = (int)owner.Skills[SkillName.Necromancy].Value;

				if ( val > 100 )
					val = 100;

				Delay = TimeSpan.FromSeconds( val );
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				if ( !m_Owner.CanBeginAction( typeof( LVampire ) ) )
				{
				m_Weapon.Cursed = false;
				m_Weapon.Consecrated = false;					
				m_Weapon.Hue=m_weaponhue;
				m_Weapon.Name=m_Name;
				m_Owner.PlaySound( 0x108 );
				m_Weapon.Attributes.WeaponDamage -= 20;
				m_Weapon.Attributes.AttackChance -= 100;
					m_Owner.EndAction( typeof( LVampire ) );

				}
			}
		}
	}
}
