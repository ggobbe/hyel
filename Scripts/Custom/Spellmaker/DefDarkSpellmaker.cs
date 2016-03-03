using System;
using Server.Items;
using Server.Mobiles;
using Server.Spells;


namespace Server.Engines.Craft
{
    public class DefDarkSpellmaker : CraftSystem
    {
        public override SkillName MainSkill
        {
            get { return SkillName.Inscribe; }
        }

        public override int GumpTitleNumber
        {
            get { return 1061739; } // <CENTER>SPELLMAKER MENU</CENTER>
        }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.0; // 0%
        }

        private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefDarkSpellmaker();

                return m_CraftSystem;
            }
        }

        private DefDarkSpellmaker()
            : base(1, 1, 1.25)// base( 1, 1, 3.0 )
        {
        }

        public override int CanCraft(Mobile from, BaseTool tool, Type itemType)
        {
            if (tool == null || tool.Deleted || tool.UsesRemaining < 0)
                return 1044038; // You have worn out your tool!
            else if (!BaseTool.CheckAccessible(tool, from))
                return 1044263; // The tool must be on your person to use.

            return 0;
        }

        public override void PlayCraftEffect(Mobile from)
        {
            from.PlaySound(0x249);
        }

        public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
        {
            if (toolBroken)
                from.SendLocalizedMessage(1044038); // You have worn out your tool

            if (failed)
            {
                if (lostMaterial)
                    return 1044043; // You failed to create the item, and some of your materials are lost.
                else
                    return 1044157; // You failed to create the item, but no materials were lost.
            }
            else
            {
                return 1044154; // You create the item.
            }
        }

        public override void InitCraftList()
        {
           #region Necromancer
            AddCraft(typeof(WraithFormScroll), 1061677, 1060524, 10.0, 50.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(PainSpikeScroll), 1061677, 1060517, 10.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(AnimateDeadScroll), 1061677, 1060509, 30.0, 60.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(HorrificBeastScroll), 1061677, 1060514, 30.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(LichFormScroll), 1061677, 1060515, 40.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(MindRotScroll), 1061677, 1060516, 40.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(WitherScroll), 1061677, 1060523, 40.0, 90.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(BloodOathScroll), 1061677, 1060510, 50.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SummonFamiliarScroll), 1061677, 1060520, 50.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(CorpseSkinScroll), 1061677, 1060511, 50.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(CurseWeaponScroll), 1061677, 1060512, 60.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(EvilOmenScroll), 1061677, 1060513, 60.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(StrangleScroll), 1061677, 1060519, 70.0, 90.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(PoisonStrikeScroll), 1061677, 1060518, 90.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(VampiricEmbraceScroll), 1061677, 1060521, 90.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(VengefulSpiritScroll), 1061677, 1060522, 100.0, 140.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ExorcismScroll), 1061677, 1060525, 100.0, 140.0, typeof(BlankScroll), 1061740, 1, 1061741);

            #endregion

            #region Ninja

            AddCraft(typeof(FocusAttackScroll), 1060609, 1060610, 0.0, 20.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DeathStrikeScroll), 1060609, 1060611, 0.0, 20.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(AnimalFormScroll), 1060609, 1060612, 20.0, 50.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(KiAttackScroll), 1060609, 1060613, 20.0, 60.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SurpriseAttackScroll), 1060609, 1060614, 40.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(BackstabScroll), 1060609, 1060615, 60.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ShadowjumpScroll), 1060609, 1060616, 90.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(MirrorImageScroll), 1060609, 1060617, 90.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            #endregion

            #region Daemonic

            AddCraft(typeof(DaemonicPoisonScroll), 1063566, 1063567, 80.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DaemonicProieScroll), 1063566, 1063568, 80.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DaemonicDrainVieScroll), 1063566, 1063569, 90.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DaemonicFeuzoneScroll), 1063566, 1063570, 90.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DaemonicCarapaceScroll), 1063566, 1063571, 100.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DaemonicVampireScroll), 1063566, 1063572, 100.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DaemonicMaleficioScroll), 1063566, 1063573, 100.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DaemonicNueesScroll), 1063566, 1063574, 100.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            //AddCraft(typeof(DaemonicMedusaScroll), 1063566, 1063575, 110.0, 140.0, typeof(BlankScroll), 1061740, 1, 1061741);
            //AddCraft(typeof(DaemonicDracoScroll), 1063566, 1063576, 110.0, 140.0, typeof(BlankScroll), 1061740, 1, 1061741);
            #endregion


            #region DarkPaladin

            AddCraft(typeof(DPCleanseByFireScroll), 1060602, 1060585, -10.0, 20.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DPCloseWoundsScroll), 1060602, 1060586, 0.0, 30.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DPConsecrateWeaponScroll), 1060602, 1060587, 10.0, 40.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DPDispelEvilScroll), 1060602, 1060588, 20.0, 50.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DPDivineFuryScroll), 1060602, 1060589, 40.0, 60.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DPEnemyOfOneScroll), 1060602, 1060590, 50.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DPHolyLightScroll), 1060602, 1060591, 70.0, 90.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DPNobleSacrificeScroll), 1060602, 1060592, 90.0, 105.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DPRemoveCurseScroll), 1060602, 1060593, 100.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DPSacredJourneyScroll), 1060602, 1060594, 110.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);

            #endregion

        }
    }
}