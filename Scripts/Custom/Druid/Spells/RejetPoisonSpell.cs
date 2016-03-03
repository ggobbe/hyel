using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Druid
{
    public class RejetPoisonSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Rejet du poison", "Nox Nei",
				212,
				9061,
				Reagent.Garlic,
				Reagent.SpringWater
			);

        public override SpellCircle Circle { get { return SpellCircle.Second; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.5); } }
      	public override double RequiredSkill{ get{ return 25.0; } }
      	public override int RequiredMana{ get{ return 15; } }

		public RejetPoisonSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
			else if ( CheckBSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				if ( m.CurePoison( Caster ) )
				{
					if ( Caster != m )
						Caster.SendMessage( "Dame Nature a gueri votre cible du poison" ); // You have cured the target of all poisons!

					m.SendMessage( "Dame Nature vous a gueri du poison" ); // You have been cured of all poisons.
				}

				m.FixedParticles( 0x375A, 10, 15, 5012, EffectLayer.Waist );
				m.PlaySound( 0x477 );
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private RejetPoisonSpell m_Owner;

			public InternalTarget( RejetPoisonSpell owner ) : base( 12, false, TargetFlags.Beneficial )
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
