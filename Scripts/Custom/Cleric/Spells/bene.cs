using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Cleric
{
	public class BeneSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Benediction", "Divine reis",
				203,
				9061

			);

        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
		public override int RequiredTithing{ get{ return 40; } }
		public override double RequiredSkill{ get{ return 60.0; } }
		public override int RequiredMana{ get{ return 15; } }
        public override SpellCircle Circle { get { return SpellCircle.Seventh; } }
		public BeneSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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

				SpellHelper.AddStatBonus( Caster, m, StatType.Str, 12, TimeSpan.FromSeconds( 300.0 ) ); SpellHelper.DisableSkillCheck = true;
				SpellHelper.AddStatBonus( Caster, m, StatType.Dex, 12, TimeSpan.FromSeconds( 300.0 ) );
				SpellHelper.AddStatBonus( Caster, m, StatType.Int, 12, TimeSpan.FromSeconds( 300.0 ) ); SpellHelper.DisableSkillCheck = false;


				m.FixedParticles( 0x375A, 1, 30, 9966, 33, 2, EffectLayer.Head );
				m.FixedParticles( 0x37B9, 1, 30, 9502, 43, 3, EffectLayer.Head );
				//m.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Waist );
				m.PlaySound( 0x1EA );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private BeneSpell m_Owner;

			public InternalTarget( BeneSpell owner ) : base( 12, false, TargetFlags.Beneficial )
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
