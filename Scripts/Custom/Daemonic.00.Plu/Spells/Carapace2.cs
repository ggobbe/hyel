using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Daemonic 
{
    public class Carapace : DaemonicSpell 
	{
      private static SpellInfo m_Info = new SpellInfo( 
            "Carapace", "Hot'N Shass", 
            -1, 
            9002, 
            false, 
				Reagent.Onax,
				Reagent.BatWing,
				Reagent.DaemonBlood
         ); 

		private static Hashtable m_Table = new Hashtable();
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(0.0); } }
		//public override int RequiredTithing{ get{ return 25; } }
		public override double RequiredSkill{ get{ return 125.0; } }
		public override int RequiredMana{ get{ return 50; } }
		public override bool BlocksMovement{ get{ return false; } }
        public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
		public Carapace( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public static bool HasEffect( Mobile Caster )
		{
			return ( m_Table[Caster] != null );
		}

		public static void RemoveEffect( Mobile Caster )
		{
			Timer t = (Timer)m_Table[Caster];

			if ( t != null )
			{
				t.Stop();
				m_Table.Remove( Caster );
			} 
		}

		public override void OnCast()
		{
			//Caster.Target = new InternalTarget( this );
	
	
	
			if ( m_Table.Contains( Caster ) )
			{
				Caster.LocalOverheadMessage( MessageType.Regular, 0x481, false, "Votre cible est deja soumis a cet effet." );
			}

			else if ( CheckHSequence( Caster ) ) //, false ) )
			{
				ArrayList targets = new ArrayList();

				Caster.FixedParticles( 0x3709, 10, 30, 5052, 0x480, 0, EffectLayer.LeftFoot );
				Caster.PlaySound( 0x1a1 );

				//SpellHelper.Turn( source, m );
				Timer t = new InternalTimer( Caster );
				t.Start();
				m_Table[Caster] = t;

				foreach ( Mobile m in Caster.GetMobilesInRange( 1 ) )
				{
					if ( Caster != m && SpellHelper.ValidIndirectTarget( Caster, m ) && Caster.CanBeHarmful( m, false ) )
						targets.Add( m );
				}

				Caster.PlaySound( 0x207 );


				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];

			            double damage = ( ( Caster.Skills[SkillName.Necromancy].Value + (Caster.Skills[SkillName.SpiritSpeak].Value)) /16); //Utility.Random( 27, 50 ); metre * 4 en relle

				damage += ((Caster.Karma / 4000)* -1);
				if ( m is BaseCreature )
					damage = damage * 1.8;

				else if ( m is PlayerMobile )
					damage = damage / 1.8 ;
					Caster.DoHarmful( m );
					SpellHelper.Damage( this, m, damage, 0, 0, 100, 0, 100 );
				}
			}

			FinishSequence();				
				
				
				
		}

		private class InternalTimer : Timer
		{
			private Mobile source;
			private DateTime NextTick;
			private DateTime Expire;

			public InternalTimer( Mobile from ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
			{
				//dest = m;
				source = from;
				Priority = TimerPriority.FiftyMS;
				
                if  ( source.Skills[SkillName.Magery].Value == 160.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 40.0 );
    
                 else if  ( source.Skills[SkillName.Magery].Value > 149.9 && source.Skills[SkillName.Magery].Value < 160.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 35.0 );   
    
                else if  ( source.Skills[SkillName.Magery].Value > 139.9 && source.Skills[SkillName.Magery].Value < 150.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 30.0 );    
    
                 else if  ( source.Skills[SkillName.Magery].Value < 140.0 )
                Expire = DateTime.Now + TimeSpan.FromSeconds( 25.0 );    
    


    
            //Expire = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
			}

			protected override void OnTick()
			{
				if ( !source.CheckAlive() )
				{
					Stop();
					m_Table.Remove( source );
				}
				if ( DateTime.Now < NextTick )
					return;

				if ( DateTime.Now >= NextTick )
				{
				source.FixedParticles( 14170, 1, 3, 9964, 3, 3, EffectLayer.Waist );//(0x444,1,30
				
				ArrayList targets = new ArrayList();

				foreach ( Mobile dest in source.GetMobilesInRange( 1 ) )
				{
					if ( source != dest && SpellHelper.ValidIndirectTarget( source, dest ) && source.CanBeHarmful( dest, false ) )
						targets.Add( dest );
				}

				//source.PlaySound( 0x207 );


				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile dest = (Mobile)targets[i];

			            double damage = ( ( source.Skills[SkillName.Necromancy].Value + (source.Skills[SkillName.SpiritSpeak].Value)) /16); //Utility.Random( 27, 50 ); metre * 4 en relle

				damage += ((source.Karma / 4000)* -1);
				if ( dest is BaseCreature )
					damage = damage * 1.8;

				else if ( dest is PlayerMobile )
					damage = damage / 1.8 ;

					source.DoHarmful( dest );
					//SpellHelper.Damage( this, dest, damage, 100, 0, 0, 0, 0 );
				if ( Core.AOS )
				{
					//dest.ApplyPoison( source, Poison.GetPoison( level ) );
					SpellHelper.Damage( TimeSpan.Zero, dest, damage, 0, 0, 100, 0, 100 );//100
				}
				else
				{
					//dest.ApplyPoison( source, Poison.GetPoison( level ) );
					SpellHelper.Damage( TimeSpan.Zero, dest, damage );
				}		
			
					NextTick = DateTime.Now + TimeSpan.FromSeconds( 3 );
				}

				if ( DateTime.Now >= Expire )
				{
					Stop();
					if ( m_Table.Contains( source ) )
						m_Table.Remove( source );
				}
			}
		}
	}
}
}
