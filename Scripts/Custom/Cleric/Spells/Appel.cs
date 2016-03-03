using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server;

namespace Server.Spells.Cleric
{
	public class AppelSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Appelium", "Venita Ancianis",
				236,
				9031

			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(5.0); } }
		public override int RequiredTithing{ get{ return 500; } }
		public override double RequiredSkill{ get{ return 130.0; } }
		public override int RequiredMana{ get{ return 105; } }
        public override SpellCircle Circle { get { return SpellCircle.First; } }
		public AppelSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
					SpellHelper.Summon( new Gancien(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.SpiritSpeak].Value ), false, false );
					}

			FinishSequence();
		}


		
	}
}
