using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Daemonic
{
    public class Draco : DaemonicSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Dracolich", "Dracos'Hem Shor Var",
				236,
				9031,
				false

			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
		//public override int RequiredTithing{ get{ return 5; } }
		public override double RequiredSkill{ get{ return 5.0; } }
		public override int RequiredMana{ get{ return 5; } }
        public override SpellCircle Circle { get { return SpellCircle.First; } }
		public Draco( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

		

			return true;
		}
      public override void GetCastSkills( out double min, out double max )
      {
         min = RequiredSkill;
         max = RequiredSkill + 10.0;
      }
		public override void OnCast()
		{
			if ( CheckSequence() )
			{
					SpellHelper.Summon( new DracoLich(), Caster, 0x217, TimeSpan.FromSeconds( 4.0 * Caster.Skills[SkillName.SpiritSpeak].Value ), false, false );
			}

          Caster.Skills[SkillName.Necromancy].Base =( Caster.Skills[SkillName.Necromancy].Base - 0.2);

			FinishSequence();
		}


		
	}
}
