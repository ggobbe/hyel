using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Druid
{
    public class VaguedenergieSpell : DruidSpell
	{
	
		private static SpellInfo m_Info = new SpellInfo(
				"Vague energie", "Kes En Por",
				230,
				9022,
				Reagent.BlackPearl,
				Reagent.Nightshade,
				Reagent.DestroyingAngel
			);
        public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
		public VaguedenergieSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(5.0); } }
		public override double RequiredSkill{ get{ return 100.0; } }
		public override int RequiredMana{ get{ return 30; } }

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if (Caster == m)
			{
				Caster.SendMessage("Vous ne pouvez vous visez vous meme !");
			}
			else if ( CheckHSequence( m ) )
			{
				Mobile source = Caster;

				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, ref source, ref m );

				double damage;

                //if ( Core.AOS )
                //{
                //    damage = GetAosDamage( 31, 3, 2.0 ); //11, 3, 2.75 
                //}
                //else
				{
					damage = Utility.Random( 24, 18 );

					if ( CheckResisted( m ) )
					{
						damage *= 0.75;

						m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
					}

					// Scale damage based on evalint and resist
					damage *= GetDamageScalar( m );
				}

				// Do the effects
				source.MovingParticles( m, 0x37C2, 7, 0, false, true, 3043, 4043, 0x211 );
				source.PlaySound( 0x20A );

				// Deal the damage
				SpellHelper.Damage( this, m, damage, 0, 0, 0, 0, 100 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private VaguedenergieSpell m_Owner;

			public InternalTarget( VaguedenergieSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}