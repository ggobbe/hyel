using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server;

namespace Server.Spells.Cleric
{
	public class LumiereSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Luminoos", "Illuminaty",
				236,
				9031
				

			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
		public override int RequiredTithing{ get{ return 20; } }
		public override double RequiredSkill{ get{ return 30.0; } }
		public override int RequiredMana{ get{ return 10; } }
        public override SpellCircle Circle { get { return SpellCircle.First; } }
		public LumiereSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
						int level = (int)Math.Abs( LightCycle.DungeonLevel * ( m_Spell.Caster.Skills[SkillName.SpiritSpeak].Base / 5) );

						if ( level > 25 || level < 0 )
							level = 25;

						targ.LightLevel = level;

				targ.FixedParticles( 0x3709, 10, 30, 5052, 0x480, 0, EffectLayer.LeftFoot );
				targ.PlaySound( 0x208 );
									}
					else
					{
						from.SendMessage( "{0} Dja illumin.", from == targ ? "Vous etes" : "ils sont" );
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
