using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Druid
{
    public class AuraProtectionSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Aura de Protection", "Re Min Sat",
				203,
				9061,
				Reagent.Garlic,
				Reagent.SpringWater
			);
        public override SpellCircle Circle { get { return SpellCircle.Third; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2.0); } }
      public override double RequiredSkill{ get{ return 25.0; } }
      public override int RequiredMana{ get{ return 10; } }			

		public AuraProtectionSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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

				SpellHelper.AddStatBonus( Caster, m, StatType.Str ); SpellHelper.DisableSkillCheck = true;
				SpellHelper.AddStatBonus( Caster, m, StatType.Dex );
				SpellHelper.AddStatBonus( Caster, m, StatType.Int ); SpellHelper.DisableSkillCheck = false;

				m.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Waist );
				m.PlaySound( 0x15 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private AuraProtectionSpell m_Owner;

			public InternalTarget( AuraProtectionSpell owner ) : base( 12, false, TargetFlags.Beneficial )
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
