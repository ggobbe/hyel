/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class DesarmerSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Desarmer",
            "Jette tes gants et ton arme mon frere"
            );
        public override SpellCircle Circle { get { return SpellCircle.Fourth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2 - ((double)Caster.Int / 120)); } }

        public override double RequiredSkill { get { return 30.0; } }
        public override int RequiredMana { get { return 20; } }

        public DesarmerSpell(Mobile caster, Item scroll)
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

                //m.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                //m.PlaySound(0x1E6);

                Item toDisarmOne = m.FindItemOnLayer(Layer.OneHanded);
                Item toDisarmTwo = m.FindItemOnLayer(Layer.TwoHanded);

                Skill provo = Caster.Skills[SkillName.Provocation];
                provo.Update();

                Container pack = m.Backpack;

                int dis = (int)Utility.Random(100);
                bool disarming = false;

                if (toDisarmTwo != null && ((int)provo.Value - 60) >= dis)
                {
                        disarming = true;
                        pack.DropItem(toDisarmTwo);
                }
                else if (toDisarmOne != null && ((int)provo.Value) >= dis)
                {
                    disarming = true;
                    pack.DropItem(toDisarmOne);
                }
                else
                {
                    Caster.SendMessage("Votre tentative de désarmement échoue.");
                    Caster.PlaySound(0x1E6);
                }

                if (disarming == true)
                {
                    m.PlaySound(0x3B9);
                    m.FixedParticles(0x37BE, 232, 25, 9948, EffectLayer.LeftHand);

                    m.SendMessage("Votre arme glisse de votre main.");
                }
            }
            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private DesarmerSpell m_Owner;

            public InternalTarget(DesarmerSpell owner)
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