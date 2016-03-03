using System;
using Server;

namespace Server.Spells.Magister
{
   public abstract class MagisterSpell : Spell
   {
       public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(4.0); } }
      public abstract double RequiredSkill{ get; }
      public abstract int RequiredMana { get; }

      /*public override SkillName CastSkill{ get{ return SkillName.AnimalLore; } }
      public override SkillName DamageSkill{ get{ return SkillName.AnimalTaming; } }*/
	public override SkillName CastSkill{ get{ return SkillName.Magery; } }
      public override bool ClearHandsOnCast{ get{ return true; } }
      public abstract SpellCircle Circle { get; }
      public MagisterSpell(Mobile caster, Item scroll, SpellInfo info)
          : base(caster, scroll, info)
      {
      }
      
      public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( Caster.Skills[CastSkill].Value < RequiredSkill )
			{
				Caster.SendMessage( "Vous devez avoir " + RequiredSkill + " Magie pour invoquer" );
				return false;
			}
			
			else if ( Caster.Mana < ScaleMana( GetMana() ) )
			{
				Caster.SendMessage( "Vous devez avoir " + GetMana() + " Mana pour invoquer." );
				return false;
			}

			return true;
		}

		public override bool CheckFizzle()
		{
			if ( !base.CheckFizzle() )
				return false;

			double min, max;

			GetCastSkills( out min, out max );


			int mana = ScaleMana( GetMana() );

			if ( Caster.Skills[CastSkill].Value < RequiredSkill )
			{
				Caster.SendMessage( "Vous devez avoir " + RequiredSkill + " Magie pour invoquer." );
				return false;
			}
			
			else if ( Caster.Mana < mana )
			{
				Caster.SendMessage( "Vous devez avoir " + mana + " Mana pour invoquer." );
				return false;
			}


			return true;
		}

        public override int GetMana()
        {
            return 0;
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

      public override void GetCastSkills( out double min, out double max )
      {
         min = RequiredSkill;
         max = RequiredSkill + 25.0;
      }

     /* public override int GetMana()
      {
         return RequiredMana;
      }*/
   }
}
