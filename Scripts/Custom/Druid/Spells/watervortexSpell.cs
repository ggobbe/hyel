using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Druid
{
    public class watervortexSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Vortex d eau", "Kes En An Flam",
				269,
				9020,
				Reagent.SpidersSilk,
				Reagent.Bloodmoss,
				Reagent.SpringWater
			);

		public watervortexSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
		public override double RequiredSkill{ get{ return 120.0; } }
		public override int RequiredMana{ get{ return 50; } }

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 2) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				if ( Core.AOS )
					SpellHelper.Summon( new watervortex(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.Magery].Value ), false, false );
				else
					SpellHelper.Summon( new watervortex(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.Magery].Value ), false, false );
			}

			FinishSequence();
		}
	}
}
