using System;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.Daemonic
{
    public class Maleficio : DaemonicSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"touche malefik", "Ghor's'Tack",
				-1,
				9051,
				Reagent.Onax,
				Reagent.BatWing,
				Reagent.PigIron
				
			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3.0); } }
		public override double RequiredSkill{ get{ return 135.0; } }
		public override int RequiredMana{ get{ return 60; } }
		//public override int RequiredTithing{ get{ return 5; } }
		//public override double RequiredSkill{ get{ return 90.0; } }
		//public override int RequiredMana{ get{ return 50; } }
        public override SpellCircle Circle { get { return SpellCircle.Fourth; } }
		public override bool BlocksMovement{ get{ return true; } }	
		
		public Maleficio( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.PlaySound( 0x301 );			
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				/* Transmogrifies the flesh of the target creature or player to resemble rotted corpse flesh,
				 * making them more vulnerable to Fire and Poison damage,
				 * but increasing their resistance to Physical and Cold damage.
				 * 
				 * The effect lasts for ((Spirit Speak skill level - target's Resist Magic skill level) / 25 ) + 40 seconds.
				 * 
				 * NOTE: Algorithm above is fixed point, should be:
				 * ((ss-mr)/2.5) + 40
				 * 
				 * NOTE: Resistance is not checked if targeting yourself
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[m];

				if ( timer != null )
					timer.DoExpire();
				else
					//m.SendLocalizedMessage( 1061689 ); // Your skin turns dry and corpselike.

				m.FixedParticles( 0x373A, 1, 15, 9913, 67, 7, EffectLayer.Head );
				m.PlaySound( 0x302 );


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



				//double ss = GetDamageSkill( Caster );
				//double mr = ( Caster == m ? 0.0 : GetResistSkill( m ) );

				TimeSpan duration = TimeSpan.FromSeconds( 30 );

				if ( m is PlayerMobile )
				{
         			 if ( CheckBSequence( m ) )
         			 {
         			SpellHelper.Turn( Caster, m );
    				SpellHelper.AddStatBonus( Caster, m, StatType.Str, -40, TimeSpan.FromSeconds( 30.0 ) );
           			SpellHelper.AddStatBonus( Caster, m, StatType.Dex, -40, TimeSpan.FromSeconds( 30.0 ) );
				}

				ResistanceMod[] mods = new ResistanceMod[4]
					{
						new ResistanceMod( ResistanceType.Fire, -20 ),
						new ResistanceMod( ResistanceType.Poison, -20 ),
						new ResistanceMod( ResistanceType.Cold, -20 ),
						new ResistanceMod( ResistanceType.Physical, -20 )
					};
					
				timer = new ExpireTimer( m, mods, duration );
				timer.Start();

				m_Table[m] = timer;

				for ( int i = 0; i < mods.Length; ++i )
					m.AddResistanceMod( mods[i] );					
				}
			 else if ( m is BaseCreature )
				{
					
          		 if ( CheckBSequence( m ) )
         			 {
         			SpellHelper.Turn( Caster, m );
    				SpellHelper.AddStatBonus( Caster, m, StatType.Str, -40, TimeSpan.FromSeconds( 30.0 ) );
           			SpellHelper.AddStatBonus( Caster, m, StatType.Dex, -40, TimeSpan.FromSeconds( 30.0 ) );
					}
				ResistanceMod[] mods = new ResistanceMod[4]
					{
						new ResistanceMod( ResistanceType.Fire, -30 ),
						new ResistanceMod( ResistanceType.Poison, -40 ),
						new ResistanceMod( ResistanceType.Cold, -40 ),
						new ResistanceMod( ResistanceType.Physical, -50 )
					};
					
				timer = new ExpireTimer( m, mods, duration );
				timer.Start();

				m_Table[m] = timer;

				for ( int i = 0; i < mods.Length; ++i )
					m.AddResistanceMod( mods[i] );					
					
				}				
				
				
				/*timer = new ExpireTimer( m, mods, duration );
				timer.Start();

				m_Table[m] = timer;

				for ( int i = 0; i < mods.Length; ++i )
					m.AddResistanceMod( mods[i] );*/
			}

			FinishSequence();
		}

		private static Hashtable m_Table = new Hashtable();

		public static void RemoveCurse( Mobile m )
		{
			ExpireTimer t = (ExpireTimer)m_Table[m];

			if ( t == null )
				return;

			m.SendLocalizedMessage( 1061688 ); // Your skin returns to normal.
			t.DoExpire();
		}

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private ResistanceMod[] m_Mods;

			public ExpireTimer( Mobile m, ResistanceMod[] mods, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mods = mods;
			}

			public void DoExpire()
			{
				for ( int i = 0; i < m_Mods.Length; ++i )
					m_Mobile.RemoveResistanceMod( m_Mods[i] );

				Stop();
				m_Table.Remove( m_Mobile );
			}

			protected override void OnTick()
			{
				m_Mobile.SendLocalizedMessage( 1061688 ); // Your skin returns to normal.
				m_Mobile.FixedParticles( 0x373A, 1, 15, 9913, 67, 7, EffectLayer.Head );
				m_Mobile.PlaySound( 0x302 );

				DoExpire();
			}
		}

		private class InternalTarget : Target
		{
			private Maleficio m_Owner;

			public InternalTarget( Maleficio owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
