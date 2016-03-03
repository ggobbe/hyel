/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class StridenceSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Stridence",
            "Cacophonie aigue, voila ce que je te jouerai"
            );

        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
        public override double RequiredSkill { get { return 40.0; } }
        public override int RequiredMana { get { return 25; } }
        public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
        public StridenceSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
                    ArrayList targets = new ArrayList();

                    Map map = Caster.Map;

                    if (map != null)
                    {
                        foreach (Mobile m in Caster.GetMobilesInRange(3))
                        {
                            if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && (!Core.AOS || Caster.InLOS(m)))
                                targets.Add(m);
                        }
                    }

                    Caster.PlaySound(0x2F3);

                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];

                        int damage;

                        Skill provo = Caster.Skills[SkillName.Provocation];
                        provo.Update();

                        if (Core.AOS)
                        {
                            damage = (int)(provo.Value / 2);

                            if (!m.Player)
                                damage = Math.Max(Math.Min(damage, 100), 15);
                            damage += Utility.RandomMinMax(0, 15);

                        }
                        else
                        {
                            damage = (int)(provo.Value / 2);

                            if (!m.Player && damage < 10)
                                damage = 10;
                            else if (damage > 75)
                                damage = 75;
                        }

                        Caster.DoHarmful(m);

                        SpellHelper.Damage(TimeSpan.Zero, m, Caster, damage, 100, 0, 0, 0, 0);
                    }
            FinishSequence();
        }
    }
}
