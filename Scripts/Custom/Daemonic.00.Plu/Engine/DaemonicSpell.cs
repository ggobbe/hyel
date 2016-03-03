using System;
using Server;

namespace Server.Spells.Daemonic
{
	public abstract class DaemonicSpell : Spell
	{
		public abstract double RequiredSkill{ get; }
		public abstract int RequiredMana{ get; }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(4.0); } }
		public override SkillName CastSkill{ get{ return SkillName.Necromancy; } }
		public override SkillName DamageSkill{ get{ return SkillName.SpiritSpeak; } }
        public abstract SpellCircle Circle { get; }
		public override bool ClearHandsOnCast{ get{ return false; } }

		public override double CastDelayFastScalar{ get{ return 0; } } // Necromancer spells are not effected by fast cast items, though they are by fast cast recovery

        public DaemonicSpell(Mobile caster, Item scroll, SpellInfo info)
            : base(caster, scroll, info)
		{
		}

		public override int ComputeKarmaAward()
		{
			return -(70 + (5 * (int)Circle));
			
		}

		public override void GetCastSkills( out double min, out double max )
		{
			min = RequiredSkill;
			max = RequiredSkill + 40.0;
		}

		public override int GetMana()
		{
			return RequiredMana;
		}
        
        public virtual bool CheckResisted(Mobile target)
        {
            double n = GetResistPercent(target);

            n /= 100.0;

            if (n <= 0.0)
                return false;

            if (n >= 1.0)
                return true;

            int maxSkill = (1 + (int)Circle) * 10;
            maxSkill += (1 + ((int)Circle / 6)) * 25;

            if (target.Skills[SkillName.MagicResist].Value < maxSkill)
                target.CheckSkill(SkillName.MagicResist, 0.0, 120.0);

            return (n >= Utility.RandomDouble());
        }

        public virtual double GetResistPercentForCircle(Mobile target, SpellCircle circle)
        {
            double firstPercent = target.Skills[SkillName.MagicResist].Value / 5.0;
            double secondPercent = target.Skills[SkillName.MagicResist].Value - (((Caster.Skills[CastSkill].Value - 20.0) / 5.0) + (1 + (int)circle) * 5.0);

            return (firstPercent > secondPercent ? firstPercent : secondPercent) / 2.0; // Seems should be about half of what stratics says.
        }

        public virtual double GetResistPercent(Mobile target)
        {
            return GetResistPercentForCircle(target, Circle);
        }
	}
}
