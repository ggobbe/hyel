/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class ProtectionBSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Protection",
            "Tu ne feras de mal a la beaute"
            );
        public override SpellCircle Circle { get { return SpellCircle.Second; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2 - ((double)Caster.Int / 120)); } }
       
        public override double RequiredSkill { get { return 5.0; } }
        public override int RequiredMana { get { return 15; } }

        public ProtectionBSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (Caster.Spell != null)
                Caster.Spell.OnCasterHurt();

            if (Caster.BeginAction(typeof(ProtectionBSpell)))
            {
                Caster.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                Caster.PlaySound(0x1E6);

                Caster.BeginAction(typeof(ProtectionBSpell));

                Skill peace = Caster.Skills[SkillName.Peacemaking];

                peace.Update();

                //x=  5+(n/10)
                int resist = (int)(5 + ((int)peace.Value / 10));
                
                ResistanceMod physique = new ResistanceMod(ResistanceType.Physical, resist);
                ResistanceMod poison = new ResistanceMod(ResistanceType.Poison, resist);
                ResistanceMod energie = new ResistanceMod(ResistanceType.Energy, resist);
                ResistanceMod feu = new ResistanceMod(ResistanceType.Fire, resist);
                ResistanceMod froid = new ResistanceMod(ResistanceType.Cold, resist);

                Caster.AddResistanceMod(physique);
                Caster.AddResistanceMod(poison);
                Caster.AddResistanceMod(energie);
                Caster.AddResistanceMod(feu);
                Caster.AddResistanceMod(froid);

                Caster.SendMessage("Votre peau se durcit.");

                new InternalTimer(Caster, resist).Start();
            }
            else
            {
                Caster.SendMessage("Votre cible est déjà sous l'effet de ce sort !");
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Caster;
            private int m_Resist;

            public InternalTimer(Mobile caster, int resist)
                : base(TimeSpan.FromSeconds(0))
            {
                int time = 30;

                Delay = TimeSpan.FromSeconds(time);
                Priority = TimerPriority.OneSecond;

                m_Caster = caster;
                m_Resist = resist;
            }

            protected override void OnTick()
            {
                ResistanceMod physique = new ResistanceMod(ResistanceType.Physical, m_Resist);
                ResistanceMod poison = new ResistanceMod(ResistanceType.Poison, m_Resist);
                ResistanceMod energie = new ResistanceMod(ResistanceType.Energy, m_Resist);
                ResistanceMod feu = new ResistanceMod(ResistanceType.Fire, m_Resist);
                ResistanceMod froid = new ResistanceMod(ResistanceType.Cold, m_Resist);

                m_Caster.RemoveResistanceMod(physique);
                m_Caster.RemoveResistanceMod(poison);
                m_Caster.RemoveResistanceMod(energie);
                m_Caster.RemoveResistanceMod(feu);
                m_Caster.RemoveResistanceMod(froid);

                m_Caster.SendMessage("Votre peau revient à la normale !");
                m_Caster.EndAction(typeof(ProtectionBSpell));
                m_Caster.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                m_Caster.PlaySound(0x1E6);
            }
        }
    }
}
