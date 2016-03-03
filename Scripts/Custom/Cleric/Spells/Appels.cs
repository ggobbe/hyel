using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server;

namespace Server.Spells.Cleric
{
	public class AppelsSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Appeliumis", "Venita tollas Ancianis",
				236,
				9031

			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(8.0); } }
		public override int RequiredTithing{ get{ return 9000; } }
		public override double RequiredSkill{ get{ return 150.0; } }//159
		public override int RequiredMana{ get{ return 120; } }
        public override SpellCircle Circle { get { return SpellCircle.First; } }

		public AppelsSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
					SpellHelper.Summon( new Gancien2(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.SpiritSpeak].Value ), false, false );
					SpellHelper.Summon( new Gancien2(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.SpiritSpeak].Value ), false, false );
					SpellHelper.Summon( new Gancien2(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.SpiritSpeak].Value ), false, false );
					SpellHelper.Summon( new Gancien2(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.SpiritSpeak].Value ), false, false );


					}

			FinishSequence();
		}


		
	}
}
