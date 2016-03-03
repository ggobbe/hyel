/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class DecouragementSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Decouragement",
            "Que ma musique alourdisse tes pas"
            );
        public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2.0); } }
        public override double RequiredSkill { get { return 50.0; } }
        public override int RequiredMana { get { return 30; } }

        public DecouragementSpell(Mobile caster, Item scroll)
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

                m.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                m.PlaySound(0x1E6);

                Skill provo = Caster.Skills[SkillName.Provocation];
                provo.Update();

                m.Stam -= ((int)provo.Value / 2);

                m.SendMessage("Votre volonté s'affaibli.");

            }
            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private DecouragementSpell m_Owner;

            public InternalTarget(DecouragementSpell owner)
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