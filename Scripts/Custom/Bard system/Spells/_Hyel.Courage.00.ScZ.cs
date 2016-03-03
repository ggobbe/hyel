/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class CourageSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Courage",
            "Sechons nos pleurs et aguerrissons notre coeur"
            );
        public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(6 - (Caster.Int / 120)); } }

        public override double RequiredSkill { get { return 45.0; } }
        public override int RequiredMana { get { return 20; } }

        public CourageSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (Caster.Spell != null)
                Caster.Spell.OnCasterHurt();
            
            Skill music = Caster.Skills[SkillName.Musicianship];
            Skill peace = Caster.Skills[SkillName.Peacemaking];
            music.Update();
            peace.Update();

            int nbre = (int)(music.Value / 15);
            int r_Hits = (int)(peace.Value / 20);
            int r_Mana = (int)(peace.Value / 40);

            Caster.Hits += r_Hits * nbre;
            Caster.Mana += r_Mana * nbre;

            Caster.FixedParticles(0x376A, 10, 15, 5045, EffectLayer.Waist);
            Caster.PlaySound(0x3C4);

            /*
            for (int i = 1; i <= nbre; i++)
            {
                Caster.Hits += r_Hits;
                Caster.Mana += r_Mana;
                Caster.FixedParticles(0x376A, 10, 15, 5045, EffectLayer.Waist);
                Caster.PlaySound(0x3C4);
                new InternalTimer(Caster).Start();
            }
            */
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Caster;

            public InternalTimer(Mobile caster)
                : base(TimeSpan.FromSeconds(0))
            {
                int time = 5;

                Delay = TimeSpan.FromSeconds(time);
                Priority = TimerPriority.OneSecond;

                m_Caster = caster;
            }

            protected override void OnTick()
            {
            }
        }
    }
}
