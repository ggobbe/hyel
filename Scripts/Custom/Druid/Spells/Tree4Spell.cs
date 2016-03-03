using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Druid
{
    public class Tree4Spell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Appel les Gardiens de la foret", "Kes En Sepa Ohm Mas",
				269,
				9020,
				Reagent.PetrafiedWood
			);
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
		public Tree4Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(8.0); } }
      public override double RequiredSkill{ get{ return 140.0; } }
      public override int RequiredMana{ get{ return 90; } }

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			/*if ( (Caster.Followers + 2) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}*/

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				if ( Core.AOS )
					{
					SpellHelper.Summon( new SummonedTreefellow2(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.Magery].Value ), false, false );
					SpellHelper.Summon( new SummonedTreefellow2(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.Magery].Value ), false, false );
					SpellHelper.Summon( new SummonedTreefellow2(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.Magery].Value ), false, false );
					SpellHelper.Summon( new SummonedTreefellow2(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.Magery].Value ), false, false );
					}
				else
					{
					SpellHelper.Summon( new Treefellow(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.Magery].Value ), false, false );
					SpellHelper.Summon( new Treefellow(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.Magery].Value ), false, false );
					SpellHelper.Summon( new Treefellow(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.Magery].Value ), false, false );
					SpellHelper.Summon( new Treefellow(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.Magery].Value ), false, false );
					}
			}

			FinishSequence();
		}
	}
}
