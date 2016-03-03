using System;
using Server.Items;

namespace Server.Engines.Craft
{
    public class DefBoneSewing : CraftSystem
    {
        public override SkillName MainSkill
        {
            get { return SkillName.Tailoring; }
        }

        public override int GumpTitleNumber
        {
            get { return 1044005; } // <CENTER>TAILORING MENU</CENTER>
        }

        private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefBoneSewing();

                return m_CraftSystem;
            }
        }

        public override CraftECA ECA { get { return CraftECA.ChanceMinusSixtyToFourtyFive; } }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.5; // 50%
        }

        private DefBoneSewing()
            : base(1, 1, 1.25)// base( 1, 1, 4.5 )
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
            from.PlaySound(0x248);
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
                if (quality == 0)
                    return 502785; // You were barely able to make this item.  It's quality is below average.
                else if (makersMark && quality == 2)
                    return 1044156; // You create an exceptional quality item and affix your maker's mark.
                else if (quality == 2)
                    return 1044155; // You create an exceptional quality item.
                else
                    return 1044154; // You create the item.
            }
        }

        public override void InitCraftList()
        {
            int index = -1;

            #region Bone Armor
            index = AddCraft(typeof(BoneHelm), 1049149, 1025206, 85.0, 110.0, typeof(Bones), 1049064, 4, 1049063);

            index = AddCraft(typeof(BoneGloves), 1049149, 1025205, 89.0, 114.0, typeof(Bones), 1049064, 6, 1049063);

            index = AddCraft(typeof(BoneArms), 1049149, 1025203, 92.0, 117.0, typeof(Bones), 1049064, 8, 1049063);

            index = AddCraft(typeof(BoneLegs), 1049149, 1025202, 95.0, 120.0, typeof(Bones), 1049064, 10, 1049063);

            index = AddCraft(typeof(BoneChest), 1049149, 1025199, 96.0, 121.0, typeof(Bones), 1049064, 12, 1049063);

            #endregion

            // Set the overridable material
            SetSubRes(typeof(Bones), 1063650);

            AddSubRes(typeof(Bones), 1063650, 00.0, 1049064, 1063652);
            AddSubRes(typeof(DaemonBones), 1063651, 65.0, 1049064, 1063652);
            AddSubRes(typeof(OgreBones), 1063654, 65.0, 1049064, 1063652);
            AddSubRes(typeof(DragonBones), 1063656, 65.0,  1049064, 1063652);

            MarkOption = true;
            Repair = Core.AOS;
            CanEnhance = Core.AOS;
        }
    }
}