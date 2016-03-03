using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells.Cleric
{
	public class SmiteSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Foudre Divine", "Flam Sanctis",
				212,
				9041
			);
		private static Hashtable m_Table = new Hashtable();
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3.0); } }
		public override int RequiredTithing{ get{ return 500; } }
		public override double RequiredSkill{ get{ return 120.0; } }
		public override int RequiredMana{ get{ return 100; } }
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
		public SmiteSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
	
	   	 if ( Caster is PlayerMobile)// && !(((PlayerMobile)Caster).Tspell ))
	   	 {
			Caster.Target = new InternalTarget( this );
	   	 }
	   	 else Caster.SendMessage("Vous devez attendre la fin de votre Sort");
	   	 
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

				PlayerMobile pm = Caster as PlayerMobile;
				//pm.Tspell = true;

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


				IEntity from = new Entity( Serial.Zero, new Point3D( m.X + 10, m.Y, m.Z + 20 ), m.Map );
				IEntity from2 = new Entity( Serial.Zero, new Point3D( m.X + 0, m.Y + 10, m.Z + 20 ), m.Map );
				IEntity from3 = new Entity( Serial.Zero, new Point3D( m.X - 10, m.Y + 0, m.Z + 20 ), m.Map );
				IEntity from4 = new Entity( Serial.Zero, new Point3D( m.X, m.Y - 10, m.Z + 20 ), m.Map );
				IEntity to = new Entity( Serial.Zero, new Point3D( m.X, m.Y, m.Z + 2), m.Map );

				Caster.MovingParticles( m, 14361, 5, 5, false, true, 1153, 2, 0x37C4, 4019, 0x160, EffectLayer.LeftFoot, 0 );//3 couleur

				Effects.SendMovingParticles( from, to, 14695, 4, 0, false, false, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from2, to, 14695, 4, 0, false, false, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from3, to, 14695, 4, 0, false, false, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from4, to, 14695, 4, 0, false, false, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );


				//source.MovingParticles( m, 0x37C4, 5, 5, false, true, 3, 2, 0x37C4, 4019, 0x160, EffectLayer.LeftFoot, 0 );
				source.PlaySound( Core.AOS ? 0x15E : 0x44B );

				SpellHelper.Damage( this, m, damage, 0, 0, 0, 0, 100 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private SmiteSpell m_Owner;

			public InternalTarget( SmiteSpell owner ) : base( 12, false, TargetFlags.Harmful )
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
                Expire = DateTime.Now + TimeSpan.FromSeconds( 12.0 );
    
                 else if  ( source.Skills[SkillName.Magery].Value > 149.9 && source.Skills[SkillName.Magery].Value < 160.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 10.0 );   
    
                else if  ( source.Skills[SkillName.Magery].Value > 139.9 && source.Skills[SkillName.Magery].Value < 150.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 8.0 );    
    
                 else if  ( source.Skills[SkillName.Magery].Value > 129.9 && source.Skills[SkillName.Magery].Value < 140.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 6.0 );    
    

                 else if  ( source.Skills[SkillName.Magery].Value > 119.9 && source.Skills[SkillName.Magery].Value < 130.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 4.0 );

                // else if  ( source.Skills[SkillName.Magery].Value > 109.9 && source.Skills[SkillName.Magery].Value < 120.0 )
                //Expire = DateTime.Now + TimeSpan.FromSeconds( 2.0 );


                 //else if  ( source.Skills[SkillName.Magery].Value > 99.9 && source.Skills[SkillName.Magery].Value < 110.0 )
                //Expire = DateTime.Now + TimeSpan.FromSeconds( 4.0 );
    
            //Expire = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
			}

			protected override void OnTick()
			{
				Point3D oldWorldLoc = source.Location; //bi.m_WorldLoc;

				PlayerMobile pm = source as PlayerMobile;

				if ( oldWorldLoc.X != newWorldLoc.X || oldWorldLoc.Y != newWorldLoc.Y )
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

				double damage = ( ( source.Skills[SkillName.Magery].Value + (source.Skills[SkillName.SpiritSpeak].Value)) /4 );
				//damage += ((source.Karma / 1200)* +1);
				if ( dest is BaseCreature )
					damage = damage * 2.0 ;

				else if ( dest is PlayerMobile )
					damage = damage / 1.8 ;

				newWorldLoc = source.Location;

				if ( Core.AOS )
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage, 0, 0, 0, 0, 100 );//100
				}
				else
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage );
				}
			/*Effects.SendLocationEffect( new Point3D( dest.X + 3, dest.Y, dest.Z ), dest.Map, 3676, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X - 3, dest.Y, dest.Z ), dest.Map, 3679, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X, dest.Y + 3, dest.Z ), dest.Map, 3682, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X, dest.Y - 3, dest.Z ), dest.Map, 3685, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X + 2, dest.Y, dest.Z ), dest.Map, 3676, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X - 2, dest.Y, dest.Z ), dest.Map, 3679, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X + 2, dest.Y + 2, dest.Z ), dest.Map, 3676, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X - 2, dest.Y - 2, dest.Z ), dest.Map, 3679, 13 );


			Effects.SendLocationEffect( new Point3D( dest.X - 2, dest.Y + 2, dest.Z ), dest.Map, 3682, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X + 2, dest.Y - 2, dest.Z ), dest.Map, 3685, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X + 1, dest.Y, dest.Z ), dest.Map, 3676, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X - 1, dest.Y, dest.Z ), dest.Map, 3679, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X, dest.Y + 1, dest.Z ), dest.Map, 3682, 13 );
			Effects.SendLocationEffect( new Point3D( dest.X, dest.Y - 1, dest.Z ), dest.Map, 3685, 13 );*/
				//source.MovingParticles( dest, 0x37C4, 5, 5, false, true, 3, 2, 0x37C4, 4019, 0x160, EffectLayer.LeftFoot, 0 );
				source.PlaySound( Core.AOS ? 0x15E : 0x44B );




				IEntity from = new Entity( Serial.Zero, new Point3D( dest.X + 6, dest.Y, dest.Z + 20 ), dest.Map );
				IEntity from2 = new Entity( Serial.Zero, new Point3D( dest.X + 0, dest.Y + 6, dest.Z + 20 ), dest.Map );
				IEntity from3 = new Entity( Serial.Zero, new Point3D( dest.X - 6, dest.Y + 0, dest.Z + 20 ), dest.Map );
				IEntity from4 = new Entity( Serial.Zero, new Point3D( dest.X, dest.Y - 6, dest.Z + 20 ), dest.Map );
				IEntity to = new Entity( Serial.Zero, new Point3D( dest.X, dest.Y, dest.Z + 2), dest.Map );
				source.MovingParticles( dest, 14361, 5, 5, false, false, 1153, 5, 0x37C4, 4019, 0x160, EffectLayer.LeftFoot, 0x100 );//3 couleur



				//Effects.SendMovingParticles( from, to, 14361, 8, 0, false, false, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				//Effects.SendMovingParticles( from2, to, 14361, 8, 0, false, false, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				//Effects.SendMovingParticles( from3, to, 14361, 8, 0, false, false, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				//Effects.SendMovingParticles( from4, to, 14361, 8, 0, false, false, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14695, 4, 0, true, false, 1153, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from2, to, 14695, 4, 0, true, false, 1153, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from3, to, 14695, 4, 0, true, false, 1153, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from4, to, 14695, 4, 0, true, false, 1153, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );



				//SpellHelper.Damage( this, dest, damage, 0, 0, 0, 0, 100 );
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
		}
	}
}
