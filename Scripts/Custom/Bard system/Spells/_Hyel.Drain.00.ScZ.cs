/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class DrainSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Drain",
            "Endort toi, revigore moi"
            );
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(4.0); } }
        public override double RequiredSkill { get { return 85.0; } }
        public override int RequiredMana { get { return 50; } }

        public DrainSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                if (m.Spell != null)
                    m.Spell.OnCasterHurt();

                if (m.BeginAction(typeof(DrainSpell)))
                {
                    m.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                    m.PlaySound(0x1E6);

                    m.BeginAction(typeof(DrainSpell));

                    Skill provo = Caster.Skills[SkillName.Provocation];
                    provo.Update();

                    //Vie : x=50+(n-110)			où	x= Vie perdue/healée & n= valeur du skill provocation
                    int r_vie = 50 + ((int)provo.Value - 110);

                    //Mana : x=n/5	                où n = int
                    int r_mana = Caster.Int / 5;

                    m.Damage(r_vie);

                    if (m.Mana < r_mana)
                        r_mana = m.Mana;

                    m.Mana -= r_mana;

                    Caster.Hits += r_vie;
                    Caster.Mana += r_mana;

                    if (Caster.Hits > Caster.HitsMax)
                        Caster.Hits = Caster.HitsMax;
                    
                    m.SendMessage("Vos forces vitales sont absorbées.");
                    m.EndAction(typeof(DrainSpell));
                }
                else
                {
                    Caster.SendMessage("Votre cible est déjà sous l'effet de ce sort !");
                }
            }
            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private DrainSpell m_Owner;

            public InternalTarget(DrainSpell owner)
                : base(12, true, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target((Mobile)o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
