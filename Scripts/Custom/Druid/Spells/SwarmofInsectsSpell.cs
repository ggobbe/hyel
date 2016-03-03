using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells;


namespace Server.Spells.Druid
{
    public class SwarmOfInsectsSpell : DruidSpell
   {
      private static SpellInfo m_Info = new SpellInfo(
            "Swarm Of Insects", "Ess Ohm En Sec Tia",
            263,
            9032,
            Reagent.DestroyingAngel
         );
      public override SpellCircle Circle { get { return SpellCircle.Seventh; } }
      public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
      public override double RequiredSkill{ get{ return 30.0; } }
      public override int RequiredMana{ get{ return 20; } }

		public SwarmOfInsectsSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
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
			else if ( CheckHSequence( m ) )
			{

				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

				if ( m.Spell != null )
					m.Spell.OnCasterHurt();

				m.Paralyzed = false;

				if ( CheckResisted( m ) )
				{
					m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
				}
				else
				{
					if ( !m_Table.Contains( m ) )
				{
					Timer t = new InternalTimer( m, Caster );
					t.Start();

					m_Table[m] = t;
				}
				
					m.SendMessage("Une nue d'insectes vous attaque et vous pique!");
			m.FixedParticles( 0x91B, 1, 240, 9916, 0, 3, EffectLayer.Head );
            m.PlaySound( 0x230 );

				}
			}

			FinishSequence();
		}
private static Hashtable m_Table = new Hashtable();
		public static void RemoveCurse( Mobile m )
		{
			Timer t = (Timer)m_Table[m];

			if ( t == null )
				return;

			t.Stop();
			m.SendMessage( "La nue d'insecte disparait." ); 

			m_Table.Remove( m );
		}
	private class InternalTimer : Timer
		{
			private Mobile m_Target, m_From;
			private double m_MinBaseDamage, m_MaxBaseDamage;

			private DateTime m_NextHit;
			private int m_HitDelay;

			private int m_Count, m_MaxCount;

			public InternalTimer( Mobile target, Mobile from ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_Target = target;
				m_From = from;

				double timeLevel = from.Skills[SkillName.Magery].Value / 15;

				m_MinBaseDamage = timeLevel - 5;
				m_MaxBaseDamage = timeLevel + 5;

				m_HitDelay = 5;
				m_NextHit = DateTime.Now + TimeSpan.FromSeconds( m_HitDelay );

				m_Count = (int)timeLevel;

				if ( m_Count < 4 )
					m_Count = 4;

				m_MaxCount = m_Count;
			}

			protected override void OnTick()
			{
				if ( !m_Target.Alive )
				{
					m_Table.Remove( m_Target );
					Stop();
				}

				if ( !m_Target.Alive || DateTime.Now < m_NextHit )
					return;

				--m_Count;

				if ( m_HitDelay > 1 )
				{
						m_Target.FixedParticles( 0x91B, 1, 240, 9916, 0, 3, EffectLayer.Head );
            m_Target.PlaySound( 0x230 );
					if ( m_MaxCount < 5 )
					{
						--m_HitDelay;
					}
					else
					{
						int delay = (int)(Math.Ceiling( (1.0 + (5 * m_Count)) / m_MaxCount ) );

						if ( delay <= 5 )
							m_HitDelay = delay;
						else
							m_HitDelay = 5;
					}
				}

				if ( m_Count == 0 )
				{
					m_Target.SendMessage( "La nue d'insecte disparait." );
					m_Table.Remove( m_Target );
					Stop();
				}
				else
				{
					m_NextHit = DateTime.Now + TimeSpan.FromSeconds( m_HitDelay );

					double damage = ((m_From.Skills[SkillName.Magery].Value + m_From.Skills[SkillName.AnimalLore].Value) / 10); //m_MinBaseDamage + (Utility.RandomDouble() * (m_MaxBaseDamage - m_MinBaseDamage));

					damage *= (3 - (((double)m_Target.Stam / m_Target.StamMax) * 2));

					if ( damage < 1 )
						damage = 1;
					else if ( damage > 90 )
						damage = 90;
					if ( !m_Target.Player )
						damage *= 2.00;

					AOS.Damage( m_Target, m_From, (int)damage, 0, 0, 0, 100, 0 );
				}
			}
		}
		private class InternalTarget : Target
		{
			private SwarmOfInsectsSpell m_Owner;

			public InternalTarget( SwarmOfInsectsSpell owner ) : base( 12, false, TargetFlags.Harmful )
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
	}
}
