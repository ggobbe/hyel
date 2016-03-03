using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Druid
{
    public class FireflySpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Summon Firefly", "Kes En Crur",
				269,
				9020,
				Reagent.DestroyingAngel
			);

        public override SpellCircle Circle { get { return SpellCircle.First; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
      public override double RequiredSkill{ get{ return 1.0; } }
      public override int RequiredMana{ get{ return 5; } }

		public FireflySpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new LumiereTarget( this );
		}

		private class LumiereTarget : Target
		{
			private Spell m_Spell;

			public LumiereTarget( Spell spell ) : base( 10, false, TargetFlags.None )
			{
				m_Spell = spell;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Mobile && m_Spell.CheckSequence() )
				{
					Mobile targ = (Mobile)targeted;

					SpellHelper.Turn( m_Spell.Caster, targ );

					if ( targ.BeginAction( typeof( LightCycle ) ) )
					{
						new LightCycle.NightSightTimer( targ ).Start();
						int level = (int)Math.Abs( LightCycle.DungeonLevel * ( m_Spell.Caster.Skills[SkillName.Magery].Base / 5) );

						if ( level > 25 || level < 0 )
							level = 25;

						targ.LightLevel = level;

				targ.FixedParticles( 14170, 10, 30, 5052, 0x480, 0, EffectLayer.LeftFoot );
				targ.PlaySound( 0x208 );
									}
					else
					{
						from.SendMessage( "{0} Déja illuminé.", from == targ ? "Vous etes" : "ils sont" );
					}
				}

				m_Spell.FinishSequence();
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Spell.FinishSequence();
			}
		}
	}
}