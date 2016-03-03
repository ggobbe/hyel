/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Barde;
using Server.Mobiles;

namespace Server.Spells.Barde
{
    public class RatsSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Rats",
            "Suivez-moi, freres de la peste"
            );
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(8 - ((double)Caster.Int / 200)); } }


        public override double RequiredSkill { get { return 90.0; } }
        public override int RequiredMana { get { return 40; } }

        public RatsSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        // TODO: Get real list
        private static Type[] m_Types = new Type[]
			{
                typeof( RatmanPoison )
			};

        public override bool CheckCast()
        {
            if (!base.CheckCast())
                return false;

            if ((Caster.Followers + 1) > Caster.FollowersMax)
            {
                Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
                return false;
            }

            return true;
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                try
                {
                    BaseCreature creature1 = (BaseCreature)Activator.CreateInstance(m_Types[Utility.Random(m_Types.Length)]);
                    BaseCreature creature2 = (BaseCreature)Activator.CreateInstance(m_Types[Utility.Random(m_Types.Length)]);
                    BaseCreature creature3 = (BaseCreature)Activator.CreateInstance(m_Types[Utility.Random(m_Types.Length)]);
                    BaseCreature creature4 = (BaseCreature)Activator.CreateInstance(m_Types[Utility.Random(m_Types.Length)]);
                    BaseCreature creature5 = (BaseCreature)Activator.CreateInstance(m_Types[Utility.Random(m_Types.Length)]);

                    creature1.ControlSlots = 1;
                    creature2.ControlSlots = 1;
                    creature3.ControlSlots = 1;
                    creature4.ControlSlots = 1;
                    creature5.ControlSlots = 1;

                    Skill music = Caster.Skills[SkillName.Musicianship];
                    music.Update();

                    int r_nbre = (((int)music.Value / 15) - 5);

                    if (r_nbre <= 0)
                        r_nbre = 1;

                    if (r_nbre >= 5 && r_nbre <= (Caster.FollowersMax - Caster.Followers))
                    {
                        SpellHelper.Summon(creature5, Caster, 0x215, TimeSpan.FromMinutes(4), false, false);
                    }
                    if (r_nbre >= 4 && r_nbre <= (Caster.FollowersMax - Caster.Followers))
                    {
                        SpellHelper.Summon(creature4, Caster, 0x215, TimeSpan.FromMinutes(4), false, false);
                    }
                    if (r_nbre >= 3 && r_nbre <= (Caster.FollowersMax - Caster.Followers))
                    {
                        SpellHelper.Summon(creature3, Caster, 0x215, TimeSpan.FromMinutes(4), false, false);
                    }
                    if (r_nbre >= 2 && r_nbre <= (Caster.FollowersMax - Caster.Followers))
                    {
                        SpellHelper.Summon(creature2, Caster, 0x215, TimeSpan.FromMinutes(4), false, false);
                    }
                    if (r_nbre >= 1 && r_nbre <= (Caster.FollowersMax - Caster.Followers))
                    {
                        SpellHelper.Summon(creature1, Caster, 0x215, TimeSpan.FromMinutes(4), false, false);
                    }
                }
                catch
                {
                }
            }

            FinishSequence();
        }
    }
}