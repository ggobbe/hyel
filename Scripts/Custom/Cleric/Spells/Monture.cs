using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server;

namespace Server.Spells.Cleric
{
	public class MontureSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Destrium", "Venita Destrium",
				236,
				9031,
				false

			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(8.0); } }
		public override int RequiredTithing{ get{ return 500; } }
		public override double RequiredSkill{ get{ return 100.0; } }
		public override int RequiredMana{ get{ return 80; } }
        public override SpellCircle Circle { get { return SpellCircle.First; } }
		public MontureSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

		

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
					SpellHelper.Summon( new CoMWarHorse(), Caster, 0x217, TimeSpan.FromSeconds( 12.0 * Caster.Skills[SkillName.SpiritSpeak].Value ), false, false );
					}

			FinishSequence();
		}


		
	}
}
