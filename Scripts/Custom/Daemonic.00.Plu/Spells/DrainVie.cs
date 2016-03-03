using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Daemonic
{
    public class DrainVie : DaemonicSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Drain Vie", "Harr'Ts Rhee",
				-1,
				9031,
				Reagent.Onax,
				Reagent.GraveDust,	
				Reagent.Katyl				
			);

		private static Hashtable m_Table = new Hashtable();
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
		//public override int RequiredTithing{ get{ return 5; } }
		public override double RequiredSkill{ get{ return 120.0; } }
		public override int RequiredMana{ get{ return 40; } }
		public override bool BlocksMovement{ get{ return false; } }
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
		public DrainVie( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
			Caster.PlaySound( 0x301 );
	
	
		if ( Caster is PlayerMobile )
		{
            if (Caster is PlayerMobile)// && !(((PlayerMobile)Caster).Tspell ))
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

				source.MovingParticles( m, 0x37C4, 1, 2, false, true, 34, 7, 0x37C4, 4019, 0x160, EffectLayer.LeftFoot, 0 );//3 couleur
//pentacle
			Effects.SendLocationEffect( new Point3D( source.X - 1, source.Y - 3, source.Z + 1 ), source.Map, 6229, 45, 0xba4, 0 );
			Effects.SendLocationEffect( new Point3D( source.X + 2, source.Y - 2, source.Z + 1 ), source.Map, 6229, 45, 0xba4, 0 );
			Effects.SendLocationEffect( new Point3D( source.X + 1, source.Y + 1, source.Z + 1 ), source.Map, 6229, 45, 0xba4, 0 );
			Effects.SendLocationEffect( new Point3D( source.X - 2, source.Y + 2, source.Z + 1 ), source.Map, 6229, 45, 0xba4, 0 );
			Effects.SendLocationEffect( new Point3D( source.X - 3, source.Y - 1, source.Z + 1 ), source.Map, 6229, 45, 0xba4, 0 );				

			Effects.SendLocationEffect( new Point3D( source.X - 3, source.Y - 2, source.Z  ), source.Map, 0x1CF9, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 3, source.Y - 1, source.Z  ), source.Map, 0x1CF8, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 3, source.Y + 0, source.Z  ), source.Map, 0x1CF7, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 3, source.Y + 1, source.Z  ), source.Map, 0x1CF6, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 3, source.Y + 2, source.Z  ), source.Map, 0x1CF5, 45, 2406, 5 );

			Effects.SendLocationEffect( new Point3D( source.X - 2, source.Y -3, source.Z  ), source.Map, 0x1CFB, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 2, source.Y - 2, source.Z  ), source.Map, 0x1CFA, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 2, source.Y - 1, source.Z  ), source.Map, 0x1D09, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 2, source.Y + 0, source.Z  ), source.Map, 0x1D08, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 2, source.Y + 1, source.Z  ), source.Map, 0x1D07, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 2, source.Y + 2, source.Z  ), source.Map, 0x1CF4, 45, 2406, 5 );

			Effects.SendLocationEffect( new Point3D( source.X - 1, source.Y - 3, source.Z  ), source.Map, 0x1CFC, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 1, source.Y - 2, source.Z  ), source.Map, 0x1D0A, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 1, source.Y - 1, source.Z  ), source.Map, 0x1D11, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 1, source.Y + 0, source.Z  ), source.Map, 0x1D10, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 1, source.Y + 1, source.Z  ), source.Map, 0x1D06, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X - 1, source.Y + 2, source.Z  ), source.Map, 0x1CF3, 45, 2406, 5 );

			Effects.SendLocationEffect( new Point3D( source.X + 0, source.Y - 3, source.Z  ), source.Map, 0x1CFD, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 0, source.Y - 2, source.Z  ), source.Map, 0x1D0B, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 0, source.Y - 1, source.Z  ), source.Map, 0x1D12, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 0, source.Y + 0, source.Z  ), source.Map, 0x1D0F, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 0, source.Y + 1, source.Z  ), source.Map, 0x1D05, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 0, source.Y + 2, source.Z  ), source.Map, 0x1CF2, 45, 2406, 5 );

			Effects.SendLocationEffect( new Point3D( source.X + 1, source.Y - 3, source.Z  ), source.Map, 0x1CFE, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 1, source.Y - 2, source.Z  ), source.Map, 0x1D0C, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 1, source.Y - 1, source.Z  ), source.Map, 0x1D0D, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 1, source.Y + 0, source.Z  ), source.Map, 0x1D0E, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 1, source.Y + 1, source.Z  ), source.Map, 0x1D04, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 1, source.Y + 2, source.Z  ), source.Map, 0x1CF1, 45, 2406, 5 );

			Effects.SendLocationEffect( new Point3D( source.X + 2, source.Y - 3, source.Z  ), source.Map, 0x1CFF, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 2, source.Y - 2, source.Z  ), source.Map, 0x1D00, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 2, source.Y - 1, source.Z  ), source.Map, 0x1D01, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 2, source.Y + 0, source.Z  ), source.Map, 0x1D02, 45, 2406, 5 );
			Effects.SendLocationEffect( new Point3D( source.X + 2, source.Y + 1, source.Z  ), source.Map, 0x1D03, 45, 2406, 5 );

//pentacle

				if ( m is PlayerMobile)
					m.Stam = m.Stam /2;
				else
					m.Stam = 0;

				//source.MovingParticles( m, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160 );
				Caster.PlaySound( 0x214 );
		//		source.PlaySound( Core.AOS ? 0x15E : 0x44B );
				source.Hits = source.Hits + 30;
				SpellHelper.Damage( this, m, damage, 0, 0, 0, 100, 0 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private DrainVie m_Owner;

			public InternalTarget( DrainVie owner ) : base( 12, false, TargetFlags.Harmful )
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
				
                if  ( source.Skills[SkillName.Necromancy].Value == 160.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 8.0 );
    
                 else if  ( source.Skills[SkillName.Necromancy].Value > 149.9 && source.Skills[SkillName.Necromancy].Value < 160.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 7.0 );   
    
                else if  ( source.Skills[SkillName.Necromancy].Value > 139.9 && source.Skills[SkillName.Necromancy].Value < 150.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 6.0 );    
    
                 else if  ( source.Skills[SkillName.Necromancy].Value > 129.9 && source.Skills[SkillName.Necromancy].Value < 140.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 5.0 );    
    

                 else if  ( source.Skills[SkillName.Necromancy].Value > 119.9 && source.Skills[SkillName.Necromancy].Value < 130.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 4.0 );

                 else if  ( source.Skills[SkillName.Necromancy].Value > 109.9 && source.Skills[SkillName.Necromancy].Value < 120.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 3.0 );


                 else if  ( source.Skills[SkillName.Necromancy].Value > 99.9 && source.Skills[SkillName.Necromancy].Value < 110.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 2.0 );
    
            //Expire = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
			}

			protected override void OnTick()
			{
				
				if ( source is PlayerMobile )
				{
				
				Point3D oldWorldLoc = source.Location; //bi.m_WorldLoc;

                if (source is PlayerMobile)// && !(((PlayerMobile)source).PAnim ))
    	 			source.Hidden = false;

				PlayerMobile pm = source as PlayerMobile;

				if ( source is PlayerMobile && ( oldWorldLoc.X != newWorldLoc.X || oldWorldLoc.Y != newWorldLoc.Y ) )
				{
					Stop();
					m_Table.Remove( dest );
                    //pm.Tspell = false;
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
				
				double damage = ((source.Karma / 600)* -1) + ( ( source.Skills[SkillName.Necromancy].Value + (source.Skills[SkillName.SpiritSpeak].Value)) /8 );

				newWorldLoc = source.Location;

				if ( dest is PlayerMobile)
					dest.Stam = dest.Stam /2;
				else
					dest.Stam = 0;


				if ( dest is BaseCreature )
					damage = damage * 2;

			
			
				if ( Core.AOS )
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage, 0, 100, 0, 0, 0 );//100
				}
				else
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage );
				}


				source.MovingParticles( dest, 0x37C4, 5, 2, false, true, 34, 7, 0x37C4, 4019, 0x160, EffectLayer.LeftFoot, 0 );//3 couleur
				source.Hits = source.Hits + ( 20 + (int)((source.Skills[SkillName.Necromancy].Value)/5));
				//source.MovingParticles( m, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160 );
				//source.PlaySound( Core.AOS ? 0x15E : 0x44B );
				source.PlaySound( 0x214 );
				//SpellHelper.Damage( this, dest, damage, 0, 100, 0, 0, 0 );
					NextTick = DateTime.Now + TimeSpan.FromSeconds( 1 );
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
				
				double damage = ((source.Karma / 600)* -1) + ( ( source.Skills[SkillName.Necromancy].Value + (source.Skills[SkillName.SpiritSpeak].Value)) /8 );

				

				if ( dest is PlayerMobile)
					dest.Stam = dest.Stam /2;
				else
					dest.Stam = 0;


				if ( dest is BaseCreature )
					damage = damage * 2;

			
			
				if ( Core.AOS )
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage, 0, 100, 0, 0, 0 );//100
				}
				else
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage );
				}


				source.MovingParticles( dest, 0x37C4, 5, 2, false, true, 34, 7, 0x37C4, 4019, 0x160, EffectLayer.LeftFoot, 0 );//3 couleur
				source.Hits = source.Hits + ( 20 + (int)((source.Skills[SkillName.Necromancy].Value)/5));
				//source.MovingParticles( m, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160 );
				//source.PlaySound( Core.AOS ? 0x15E : 0x44B );
				source.PlaySound( 0x214 );
				//SpellHelper.Damage( this, dest, damage, 0, 100, 0, 0, 0 );
					NextTick = DateTime.Now + TimeSpan.FromSeconds( 1 );
				}

				if ( DateTime.Now >= Expire )
				{
					Stop();
					if ( m_Table.Contains( dest ) )
						m_Table.Remove( dest );
										
				}
			}
			
			
			
			
		}//fin ontick
		}
	}
}
