/* Créé part Scriptiz pour le livre de barde de Plume 
*17/02/08: Plume: Retrait du CastDelay
*/
using System;
using Server;

namespace Server.Spells.Barde
{
    public abstract class BardeSpell : Spell
    {
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(4.0); } }
        public abstract double RequiredSkill { get; }
        public abstract int RequiredMana { get; }
        public abstract SpellCircle Circle { get; }
        public override SkillName CastSkill { get { return SkillName.Musicianship; } }
        public override SkillName DamageSkill { get { return SkillName.Provocation; } }

        public override bool ClearHandsOnCast { get { return false; } }

        public BardeSpell(Mobile caster, Item scroll, SpellInfo info)
            : base(caster, scroll, info)
        {
        }

        public override void GetCastSkills(out double min, out double max)
        {
            min = RequiredSkill;
            max = RequiredSkill + 30.0;
        }

        public override int GetMana()
        {
            return RequiredMana;
        }

    }
}
