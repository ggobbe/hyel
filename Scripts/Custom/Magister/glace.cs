using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Magister
{
    public class glace : MagisterSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Blizard", "Man Dor Tich",
				212,
				9041,
				Reagent.Garlic,
				Reagent.Katyl				
			);
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
		private static Hashtable m_Table = new Hashtable();
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3.0); } }
		//public override int RequiredTithing{ get{ return 100; } }
		public override double RequiredSkill{ get{ return 120.0; } }
		public override int RequiredMana{ get{ return 50; } }
		public override bool BlocksMovement{ get{ return false; } }		
		public glace( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
	
		if ( Caster is PlayerMobile )
		{
	   		 if ( Caster is PlayerMobile) //&& !(((PlayerMobile)Caster).Tspell ))
	   		 {
				Caster.Target = new InternalTarget( this );
	   		 }
	   	 	
	   	 	else Caster.SendMessage("Vous devez attendre la fin de votre Sort");

		}
		
		else 
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
				if (Caster is PlayerMobile)
				{
				PlayerMobile pm = Caster as PlayerMobile;
                    //pm.Tspell = true;
				}

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

//(static) void SendLocationEffect( IPoint3D p, Map map, int itemID, int duration, int hue, int renderMode )

				//source.MovingParticles( m, 4963, 7, 1, false, true, 132, 5, 4963, 4963, 0x160 , 0 );
				source.MovingParticles( m, 14120, 7, 0, false, true, 1153, 2,9502, 4019, 0x160, 0 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z + 4 ), m.Map, 0x3728, 25, 1153, 2 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z ), m.Map, 0x3728, 25, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z - 4 ), m.Map, 0x3728, 25, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z + 4 ), m.Map, 0x3728, 25, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z ), m.Map, 0x3728, 25, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z - 4 ), m.Map, 0x3728, 25, 1153, 2  );

			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 11 ), m.Map, 0x3728, 25, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 7 ), m.Map, 0x3728, 25, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 3 ), m.Map, 0x3728, 25, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z - 1 ), m.Map, 0x3728, 25, 1153, 2  );

				if ( m is PlayerMobile)
					m.Stam = m.Stam /2;
				else
					m.Stam = -1;

				Caster.PlaySound( Core.AOS ? 0x15E : 0x44B );

				SpellHelper.Damage( this, m, damage, 0, 0, 100, 0, 0 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private glace m_Owner;

			public InternalTarget( glace owner ) : base( 12, false, TargetFlags.Harmful )
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
			private Point3D oldWorldLoc;
			private Point3D newWorldLoc;

			public InternalTimer( Mobile m, Mobile from ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
			{
				dest = m;
				source = from;
				Priority = TimerPriority.FiftyMS;
				oldWorldLoc = from.Location; //bi.m_WorldLoc;
				newWorldLoc = source.Location;	
				
                if  ( source.Skills[SkillName.Magery].Value > 159.9 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
    
                 else if  ( source.Skills[SkillName.Magery].Value > 149.9 && source.Skills[SkillName.Magery].Value < 160.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 8.0 );   
    
                else if  ( source.Skills[SkillName.Magery].Value > 139.9 && source.Skills[SkillName.Magery].Value < 150.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 6.0 );    
    
                 else if  ( source.Skills[SkillName.Magery].Value > 129.9 && source.Skills[SkillName.Magery].Value < 140.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 4.0 );    
    

                 else if  ( source.Skills[SkillName.Magery].Value > 119.9 && source.Skills[SkillName.Magery].Value < 130.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 2.0 );

                // else if  ( source.Skills[SkillName.Magery].Value > 109.9 && source.Skills[SkillName.Magery].Value < 120.0 )
               // Expire = DateTime.Now + TimeSpan.FromSeconds( 6.0 );


                // else if  ( source.Skills[SkillName.Magery].Value > 99.9 && source.Skills[SkillName.Magery].Value < 110.0 )
               // Expire = DateTime.Now + TimeSpan.FromSeconds( 4.0 );
    
            //Expire = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
			}

			protected override void OnTick()
			{
			
			if ( source is PlayerMobile )
			{
				Point3D oldWorldLoc = source.Location; //bi.m_WorldLoc;

    	 		if ( source is PlayerMobile)// && !(((PlayerMobile)source).PAnim ))
    	 			source.Hidden = false;

				PlayerMobile pm = source as PlayerMobile;

				if ( source is PlayerMobile && ( oldWorldLoc.X != newWorldLoc.X || oldWorldLoc.Y != newWorldLoc.Y ) )
				{
					Stop();
					m_Table.Remove( dest );
                    //	pm.Tspell = false;
				}
				
				if ( !dest.CheckAlive() )
				{
					Stop();
					m_Table.Remove( dest );
                    //pm.Tspell = false;
				}




				if ( !source.CanSee( dest ) )
				{
					Stop();
					m_Table.Remove( dest );
                    //pm.Tspell = false;
				}

				if ( !dest.InRange( source, 12 ) )
				{
					Stop();
					m_Table.Remove( dest );
                    //pm.Tspell = false;
				}

				if ( DateTime.Now < NextTick )
					return;

				if ( DateTime.Now >= NextTick )
				{

				double damage = ( ( source.Skills[SkillName.Magery].Value + (source.Skills[SkillName.EvalInt].Value)) /5 );

				if ( dest is BaseCreature )
					damage = damage * 3;
				newWorldLoc = source.Location;


				if ( Core.AOS )
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage, 0, 0, 100, 0, 0 );//100
				}
				else
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage );
				}

				source.MovingParticles( dest, 14120, 7, 0, false, true, 1153, 2,9502, 4019, 0x160, 0 );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y, dest.Z + 4 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y, dest.Z ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y, dest.Z - 4 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X, dest.Y + 1, dest.Z + 4 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X, dest.Y + 1, dest.Z ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X, dest.Y + 1, dest.Z - 4 ), dest.Map, 0x3728, 13, 1153, 2  );

			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y + 1, dest.Z + 11 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y + 1, dest.Z + 7 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y + 1, dest.Z + 3 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y + 1, dest.Z - 1 ), dest.Map, 0x3728, 13, 1153, 2  );

				source.PlaySound( Core.AOS ? 0x15E : 0x44B );

				//SpellHelper.Damage( this, dest, damage, 0, 100, 0, 0, 0 );
					NextTick = DateTime.Now + TimeSpan.FromSeconds( 2 );
				}

				if ( DateTime.Now >= Expire )
				{
					Stop();
					if ( m_Table.Contains( dest ) )
						m_Table.Remove( dest );
                    //pm.Tspell = false;
				}
				
			}
				
			else
			{
				
				if ( !dest.CheckAlive() )
				{
					Stop();
					m_Table.Remove( dest );
					
				}




				if ( !source.CanSee( dest ) )
				{
					Stop();
					m_Table.Remove( dest );
					
				}

				if ( !dest.InRange( source, 12 ) )
				{
					Stop();
					m_Table.Remove( dest );
					
				}

				if ( DateTime.Now < NextTick )
					return;

				if ( DateTime.Now >= NextTick )
				{

				double damage = ( ( source.Skills[SkillName.Magery].Value + (source.Skills[SkillName.EvalInt].Value)) /5 );

				if ( dest is BaseCreature )
					damage = damage * 3;
				


				if ( Core.AOS )
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage, 0, 0, 100, 0, 0 );//100
				}
				else
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage );
				}

				source.MovingParticles( dest, 14120, 7, 0, false, true, 1153, 2,9502, 4019, 0x160, 0 );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y, dest.Z + 4 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y, dest.Z ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y, dest.Z - 4 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X, dest.Y + 1, dest.Z + 4 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X, dest.Y + 1, dest.Z ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X, dest.Y + 1, dest.Z - 4 ), dest.Map, 0x3728, 13, 1153, 2  );

			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y + 1, dest.Z + 11 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y + 1, dest.Z + 7 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y + 1, dest.Z + 3 ), dest.Map, 0x3728, 13, 1153, 2  );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y + 1, dest.Z - 1 ), dest.Map, 0x3728, 13, 1153, 2  );

				source.PlaySound( Core.AOS ? 0x15E : 0x44B );

				//SpellHelper.Damage( this, dest, damage, 0, 100, 0, 0, 0 );
					NextTick = DateTime.Now + TimeSpan.FromSeconds( 2 );
				}

				if ( DateTime.Now >= Expire )
				{
					Stop();
					if ( m_Table.Contains( dest ) )
						m_Table.Remove( dest );
					
				}
				
			}			
				
				
			}// fin ot
		}
	}
}
