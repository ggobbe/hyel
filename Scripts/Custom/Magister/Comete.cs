using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Magister
{
    public class Comete : MagisterSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"La Comete", "Ka Vas Orh",
				212,
				9041,
				Reagent.Katyl,
				Reagent.Onax,				
				Reagent.MandrakeRoot				
				
			);
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
		private static Hashtable m_Table = new Hashtable();
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
		//public override int RequiredTithing{ get{ return 100; } }
		public override double RequiredSkill{ get{ return 125.0; } }
		public override int RequiredMana{ get{ return 70; } }
		public override bool BlocksMovement{ get{ return true; } }
        public Comete(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
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
				//source.MovingParticles( m, 4963, 7, 1, false, true, 132, 5, 4963, 4963, 0x160 , 0 );
				source.MovingParticles( m, 4963, 7, 1, false, true, 132, 5, 4963, 4963, 0x160 , 0 );
				source.MovingParticles( m, 14000, 7, 1, false, true, 132, 5, 14000, 14000, 0x160 , 0 );
				source.MovingParticles( m, 14027, 6, 1, false, true, 0, 4, 14013, 14013, 0x160 , 0 );

				source.MovingParticles( m, 14000, 6, 1, false, true, 0, 4, 14000, 14000, 0x160 , 0 );
				source.MovingParticles( m, 14013, 5, 1, false, true, 0, 4, 14013, 14013, 0x160 , 0 );
				source.MovingParticles( m, 14000, 5, 1, false, true, 0, 4, 14027, 14027, 0x160 , 0 );				
				source.MovingParticles( m, 14027, 4, 1, false, true, 0, 4, 14027, 14027, 0x160 , 0 );
			
				source.PlaySound( Core.AOS ? 0x15E : 0x44B );

				if ( m is PlayerMobile)
					m.Stam = m.Stam /2;
				else
					m.Stam = -1;

				SpellHelper.Damage( this, m, damage, 50, 50, 0, 0, 0 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private Comete m_Owner;

            public InternalTarget(Comete owner)
                : base(12, false, TargetFlags.Harmful)
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
                Expire = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
    
                 else if  ( source.Skills[SkillName.Magery].Value > 149.9 && source.Skills[SkillName.Magery].Value < 160.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 8.0 );   
    
                else if  ( source.Skills[SkillName.Magery].Value > 139.9 && source.Skills[SkillName.Magery].Value < 150.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 6.0 );    
    
                 else if  ( source.Skills[SkillName.Magery].Value > 129.9 && source.Skills[SkillName.Magery].Value < 140.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 4.0 );    
    

                 else if  ( source.Skills[SkillName.Magery].Value > 119.9 && source.Skills[SkillName.Magery].Value < 130.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 2.0 );

                 //else if  ( source.Skills[SkillName.Magery].Value > 109.9 && source.Skills[SkillName.Magery].Value < 120.0 )
                //Expire = DateTime.Now + TimeSpan.FromSeconds( 6.0 );


                 //else if  ( source.Skills[SkillName.Magery].Value > 99.9 && source.Skills[SkillName.Magery].Value < 110.0 )
                //Expire = DateTime.Now + TimeSpan.FromSeconds( 4.0 );
    
            //Expire = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
			}

			protected override void OnTick()
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
				if ( !dest.InRange( source, 15 ) )
				{
					Stop();
					m_Table.Remove( dest );
				}

				if ( DateTime.Now < NextTick )
					return;

				if ( DateTime.Now >= NextTick )
				{

				double damage = ( ( source.Skills[SkillName.Magery].Value + (source.Skills[SkillName.EvalInt].Value)) /4 );

				if ( dest is BaseCreature )
					damage = damage * 3;


				if ( Core.AOS )
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage, 50, 100, 0, 0, 0 );//100
				}
				else
				{
					SpellHelper.Damage( TimeSpan.Zero, dest, source, damage );
				}
				//source.MovingParticles( dest, 4963, 7, 1, false, true, 132, 5, 4963, 4963, 0x160 , 0 );
				source.MovingParticles( dest, 4963, 7, 1, false, true, 132, 5, 4963, 4963, 0x160 , 0 );
				source.MovingParticles( dest, 14000, 6, 1, false, true, 0, 4, 14000, 14000, 0x160 , 0 );
				source.MovingParticles( dest, 14013, 6, 1, false, true, 0, 4, 14013, 14013, 0x160 , 0 );
				source.MovingParticles( dest, 14027, 5, 1, false, true, 0, 4, 14013, 14013, 0x160 , 0 );				
				source.MovingParticles( dest, 14013, 5, 1, false, true, 0, 4, 14013, 14013, 0x160 , 0 );
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
		}
	}
}
