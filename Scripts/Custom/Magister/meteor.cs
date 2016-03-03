using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Magister
{
    public class meteor : MagisterSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Poussieres D'etoile", "Nam Vas Kor",
				212,
				9041,
				Reagent.SulfurousAsh,
				Reagent.Katyl,
				Reagent.Bloodmoss,
				Reagent.Onax				
			);
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
		private static Hashtable m_Table = new Hashtable();
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2.0); } }
		//public override int RequiredTithing{ get{ return 100; } }
		public override double RequiredSkill{ get{ return 140.0; } }
		public override int RequiredMana{ get{ return 120; } }
		public override bool BlocksMovement{ get{ return true; } }		
		public meteor( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}
        
		public static bool HasEffect( Mobile m )
		{
			return ( m_Table[m] != null );
		}

		public static void RemoveEffect( Mobile m )
		{
			Timer t = (Timer)m_Table[m];

			if ( t != null )
			{
				t.Stop();
				m_Table.Remove( m );
			} 
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}

			if ( m_Table.Contains( m ) )
			{
				Caster.LocalOverheadMessage( MessageType.Regular, 0x481, false, "Votre cible est deja soumis a cet effet." );
			}

			else if ( CheckHSequence( m ) ) //, false ) )
			{
				//SpellHelper.Turn( Caster, m );
				Mobile source = Caster;

				SpellHelper.Turn( source, m );
				Timer t = new InternalTimer( m, Caster );
				t.Start();
				m_Table[m] = t;


				SpellHelper.CheckReflect( (int)this.Circle, ref source, ref m );

				double damage;

                //if ( Core.AOS )
                //{
                //    damage = GetAosDamage( 6, 3, 5.5 );
                //}
                //else
				{
					damage = Utility.Random( 10, 7 );

					if ( CheckResisted( m ) )
					{
						damage *= 0.75;

						m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
					}

					damage *= GetDamageScalar( m );
				}
				Caster.PlaySound( 0x207 );
				m.PlaySound( 0x207 );				
				//Caster.PlaySound( soundID );
				Caster.FixedParticles( 0x3779, 1, 30, 9964, 3, 3, EffectLayer.Waist );
				//int boum = Caster.FixedParticles( 0x3779, 1, 30, 9964, 3, 3, EffectLayer.Waist );

				if ( m is PlayerMobile)
					m.Stam = m.Stam /2;
				else
					m.Stam = -1;
				
				IEntity from = new Entity( Serial.Zero, new Point3D( m.X, m.Y, m.Z + 100 ), m.Map );
				IEntity to = new Entity( Serial.Zero, new Point3D( m.X, m.Y, m.Z + 2), m.Map );
				Effects.SendMovingParticles( from, to, 0x1358, 10, 0, false, true, 132, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 4973, 10, 0, false, true, 132, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 4963, 10, 0, false, true, 132, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
		

				//SendMovingParticles( IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, EffectLayer layer, int unknown )
		

				Effects.SendMovingParticles( from, to, 14089, 10, 0, false, true, 0, 3, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14027, 9, 0, false, true, 0, 3, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 9, 0, false, true, 0, 3, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14000, 8, 0, false, true, 0, 3, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14027, 8, 0, false, true, 0, 3, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 7, 0, false, true, 0, 3, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 7, 0, false, true, 0, 3, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14000, 6, 0, false, true, 0, 3, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14027, 5, 0, false, true, 0, 3, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 5, 0, false, true, 0, 3, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );

			Effects.SendLocationEffect( new Point3D( m.X - 3, m.Y - 2, m.Z  ), m.Map, 0x1CF9, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 3, m.Y - 1, m.Z  ), m.Map, 0x1CF8, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 3, m.Y + 0, m.Z  ), m.Map, 0x1CF7, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 3, m.Y + 1, m.Z  ), m.Map, 0x1CF6, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 3, m.Y + 2, m.Z  ), m.Map, 0x1CF5, 30 );

			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y -3, m.Z  ), m.Map, 0x1CFB, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y - 2, m.Z  ), m.Map, 0x1CFA, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y - 1, m.Z  ), m.Map, 0x1D09, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y + 0, m.Z  ), m.Map, 0x1D08, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y + 1, m.Z  ), m.Map, 0x1D07, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y + 2, m.Z  ), m.Map, 0x1CF4, 30 );

			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y - 3, m.Z  ), m.Map, 0x1CFC, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y - 2, m.Z  ), m.Map, 0x1D0A, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y - 1, m.Z  ), m.Map, 0x1D11, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y + 0, m.Z  ), m.Map, 0x1D10, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y + 1, m.Z  ), m.Map, 0x1D06, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y + 2, m.Z  ), m.Map, 0x1CF3, 30 );

			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y - 3, m.Z  ), m.Map, 0x1CFD, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y - 2, m.Z  ), m.Map, 0x1D0B, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y - 1, m.Z  ), m.Map, 0x1D12, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y + 0, m.Z  ), m.Map, 0x1D0F, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y + 1, m.Z  ), m.Map, 0x1D05, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y + 2, m.Z  ), m.Map, 0x1CF2, 30 );

			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y - 3, m.Z  ), m.Map, 0x1CFE, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y - 2, m.Z  ), m.Map, 0x1D0C, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y - 1, m.Z  ), m.Map, 0x1D0D, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 0, m.Z  ), m.Map, 0x1D0E, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z  ), m.Map, 0x1D04, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 2, m.Z  ), m.Map, 0x1CF1, 30 );

			Effects.SendLocationEffect( new Point3D( m.X + 2, m.Y - 3, m.Z  ), m.Map, 0x1CFF, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 2, m.Y - 2, m.Z  ), m.Map, 0x1D00, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 2, m.Y - 1, m.Z  ), m.Map, 0x1D01, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 2, m.Y + 0, m.Z  ), m.Map, 0x1D02, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 2, m.Y + 1, m.Z  ), m.Map, 0x1D03, 30 );

//remplacer caster par m



				SpellHelper.Damage( this, m, damage, 50, 100, 0, 0, 0 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private meteor m_Owner;

			public InternalTarget( meteor owner ) : base( 12, false, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
				{
					m_Owner.Target( (Mobile)o );
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}

		private class InternalTimer : Timer
		{
			private Mobile dest, source;
			private DateTime NextTick;
			private DateTime Expire;

			public InternalTimer( Mobile m, Mobile from ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
			{
				dest = m;
				source = from;
				Priority = TimerPriority.FiftyMS;
				
                if  ( source.Skills[SkillName.Magery].Value > 159.9 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 12.0 );
    
                 else if  ( source.Skills[SkillName.Magery].Value > 149.9 && source.Skills[SkillName.Magery].Value < 160.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 8.0 );   
    
                else if  ( source.Skills[SkillName.Magery].Value > 139.9 && source.Skills[SkillName.Magery].Value < 150.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 4.0 );    
    
                /* else if  ( source.Skills[SkillName.Magery].Value > 129.9 && source.Skills[SkillName.Magery].Value < 140.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 10.0 );    
    

                 else if  ( source.Skills[SkillName.Magery].Value > 119.9 && source.Skills[SkillName.Magery].Value < 130.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 8.0 );

                 else if  ( source.Skills[SkillName.Magery].Value > 109.9 && source.Skills[SkillName.Magery].Value < 120.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 6.0 );


                 else if  ( source.Skills[SkillName.Magery].Value > 99.9 && source.Skills[SkillName.Magery].Value < 110.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 4.0 );*/
    
            //Expire = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
			}

			protected override void OnTick()
			{
				if ( !dest.CheckAlive() || !source.CanSee( dest ) )
				{
					Stop();
					m_Table.Remove( dest );
				}
				if ( !dest.InRange( source, 15 ) )
				{
					Stop();
					m_Table.Remove( dest );
				}


				if ( DateTime.Now < NextTick )
					return;

				if ( DateTime.Now >= NextTick )
				{

				double damage = ( ( source.Skills[SkillName.Magery].Value + (source.Skills[SkillName.EvalInt].Value)) /2 );

				if ( dest is BaseCreature )
					damage = damage * 4;

				if ( Core.AOS )
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage, 100, 100, 0, 0, 0 );//100
				}
				else
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage );
				}
				source.PlaySound( 0x207 );
				dest.PlaySound( 0x207 );
				//Caster.PlaySound( soundID );
				source.FixedParticles( 0x3779, 1, 30, 9964, 3, 3, EffectLayer.Waist );
				//int boum = Caster.FixedParticles( 0x3779, 1, 30, 9964, 3, 3, EffectLayer.Waist );


				IEntity from = new Entity( Serial.Zero, new Point3D( dest.X, dest.Y, dest.Z + 100 ), dest.Map );
				IEntity to = new Entity( Serial.Zero, new Point3D( dest.X, dest.Y, dest.Z + 2), dest.Map );
				Effects.SendMovingParticles( from, to, 0x1358, 7, 0, true, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 0x1358, 7, 0, false, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33

				Effects.SendMovingParticles( from, to, 4964, 7, 0, true, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 4973, 6, 0, true, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 6004, 5, 0, true, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 4963, 4, 0, true, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33
				source.PlaySound( 0x207 );
				dest.PlaySound( 0x207 );		

				//SendMovingParticles( IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, EffectLayer layer, int unknown )
		

				Effects.SendMovingParticles( from, to, 14089, 7, 0, false, true, 0, 3, 14000, 14000, 0x207, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14027, 7, 0, true, true, 132, 3, 14013, 14013, 0x207, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 6, 0, false, true, 0, 3, 14000, 14000, 0x207, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14000, 6, 0, true, true, 0, 3, 14078, 14078, 0x207, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14027, 5, 0, true, true, 132, 3, 14089, 14089, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 5, 0, false, true, 0, 3, 14000, 14000, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 4, 0, false, true, 132, 3, 14078, 14078, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14000, 5, 0, true, true, 0, 3, 14089, 14089, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14027, 3, 0, false, true, 132, 3, 14013, 14013, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 3, 0, true, true, 0, 3, 14089, 14089, 0, EffectLayer.LeftFoot, 0x100 );

			/*Effects.SendLocationEffect( new Point3D( dest.X - 3, dest.Y - 2, dest.Z  ), dest.Map, 0x1CF9, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 3, dest.Y - 1, dest.Z  ), dest.Map, 0x1CF8, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 3, dest.Y + 0, dest.Z  ), dest.Map, 0x1CF7, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 3, dest.Y + 1, dest.Z  ), dest.Map, 0x1CF6, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 3, dest.Y + 2, dest.Z  ), dest.Map, 0x1CF5, 30 );

			Effects.SendLocationEffect( new Point3D( dest.X - 2, dest.Y -3, dest.Z  ), dest.Map, 0x1CFB, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 2, dest.Y - 2, dest.Z  ), dest.Map, 0x1CFA, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 2, dest.Y - 1, dest.Z  ), dest.Map, 0x1D09, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 2, dest.Y + 0, dest.Z  ), dest.Map, 0x1D08, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 2, dest.Y + 1, dest.Z  ), dest.Map, 0x1D07, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 2, dest.Y + 2, dest.Z  ), dest.Map, 0x1CF4, 30 );

			Effects.SendLocationEffect( new Point3D( dest.X - 1, dest.Y - 3, dest.Z  ), dest.Map, 0x1CFC, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 1, dest.Y - 2, dest.Z  ), dest.Map, 0x1D0A, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 1, dest.Y - 1, dest.Z  ), dest.Map, 0x1D11, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 1, dest.Y + 0, dest.Z  ), dest.Map, 0x1D10, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 1, dest.Y + 1, dest.Z  ), dest.Map, 0x1D06, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X - 1, dest.Y + 2, dest.Z  ), dest.Map, 0x1CF3, 30 );

			Effects.SendLocationEffect( new Point3D( dest.X + 0, dest.Y - 3, dest.Z  ), dest.Map, 0x1CFD, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 0, dest.Y - 2, dest.Z  ), dest.Map, 0x1D0B, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 0, dest.Y - 1, dest.Z  ), dest.Map, 0x1D12, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 0, dest.Y + 0, dest.Z  ), dest.Map, 0x1D0F, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 0, dest.Y + 1, dest.Z  ), dest.Map, 0x1D05, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 0, dest.Y + 2, dest.Z  ), dest.Map, 0x1CF2, 30 );

			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y - 3, dest.Z  ), dest.Map, 0x1CFE, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y - 2, dest.Z  ), dest.Map, 0x1D0C, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y - 1, dest.Z  ), dest.Map, 0x1D0D, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y + 0, dest.Z  ), dest.Map, 0x1D0E, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y + 1, dest.Z  ), dest.Map, 0x1D04, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y + 2, dest.Z  ), dest.Map, 0x1CF1, 30 );

			Effects.SendLocationEffect( new Point3D( dest.X + 2, dest.Y - 3, dest.Z  ), dest.Map, 0x1CFF, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 2, dest.Y - 2, dest.Z  ), dest.Map, 0x1D00, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 2, dest.Y - 1, dest.Z  ), dest.Map, 0x1D01, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 2, dest.Y + 0, dest.Z  ), dest.Map, 0x1D02, 30 );
			Effects.SendLocationEffect( new Point3D( dest.X + 2, dest.Y + 1, dest.Z  ), dest.Map, 0x1D03, 30 );*/

				source.PlaySound( 0x207 );
				dest.PlaySound( 0x207 );
// remplacer m par la cible



				//SpellHelper.Damage( this, dest, damage, 100, 100, 0, 0, 0 );
					NextTick = DateTime.Now + TimeSpan.FromSeconds( 2 );
				}

				if ( DateTime.Now >= Expire )
				{
					Stop();
					if ( m_Table.Contains( dest ) )
						m_Table.Remove( dest );
				}
			}
		}
	}
}
