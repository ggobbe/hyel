using System;
using Server.Items;
using Server.Mobiles;
using Server.Spells;


namespace Server.Engines.Craft
{
    public class DefSpellmaker : CraftSystem
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
                    m_CraftSystem = new DefSpellmaker();

                return m_CraftSystem;
            }
        }

        private DefSpellmaker()
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
            int index = -1;
            #region Mage
            //1er cercle primary fait
    index = AddCraft(typeof(ClumsyScroll), 1061742, 3002011, -5.0, 25.0, typeof(BlankScroll), 1061740, 1, 1061741);//Male
            AddSkill(index, SkillName.ArmsLore, -10.0, 15.0);
    
    index = AddCraft(typeof(CreateFoodScroll), 1061742, 3002012, -10.0, 15.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div
            AddSkill(index, SkillName.Cooking, -10.0, 10.0);
            AddSkill(index, SkillName.Fishing, -10.0, 10.0);
            
    index = AddCraft(typeof(FeeblemindScroll), 1061742, 3002013, -5.0, 25.0, typeof(BlankScroll), 1061740, 1, 1061741);//Male
            AddSkill(index, SkillName.EvalInt, -10.0, 15.0);
    
    index = AddCraft(typeof(HealScroll), 1061742, 3002014, -10.0, 20.0, typeof(BlankScroll), 1061740, 1, 1061741);//Bene
            AddSkill(index, SkillName.Anatomy, 0.0, 20.0);
            AddSkill(index, SkillName.Healing, 10.0, 30.0);

    index = AddCraft(typeof(MagicArrowScroll), 1061742, 3002015, 0.0, 25.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddSkill(index, SkillName.Archery, -10.0, 20.0);
            AddSkill(index, SkillName.ItemID, 0.0, 25.0);
            
    index = AddCraft(typeof(NightSightScroll), 1061742, 3002016, -10.0, 15.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div
            AddSkill(index, SkillName.Anatomy, 0.0, 25.0);

    index = AddCraft(typeof(ReactiveArmorScroll), 1061742, 3002017, -10.0, 15.0, typeof(BlankScroll), 1061740, 1, 1061741); //Prot
            AddSkill(index, SkillName.Parry, 0.0, 25.0);
            AddSkill(index, SkillName.Tactics, -10.0, 10.0);
    
    index = AddCraft(typeof(WeakenScroll), 1061742, 3002018, -5.0, 25.0, typeof(BlankScroll), 1061740, 1, 1061741);//Male
            AddSkill(index, SkillName.Anatomy, 0.0, 20.0);
            
            //2e cercle primary fait
    index = AddCraft(typeof(AgilityScroll), 1061742, 3002019, 5.0, 35.0, typeof(BlankScroll), 1061740, 1, 1061741);//Bene

    index = AddCraft(typeof(CunningScroll), 1061742, 3002020, 5.0, 35.0, typeof(BlankScroll), 1061740, 1, 1061741);//Bene
            AddSkill(index, SkillName.EvalInt, -10.0, 15.0);
    index = AddCraft(typeof(CureScroll), 1061742, 3002021, 5.0, 35.0, typeof(BlankScroll), 1061740, 1, 1061741);//Bene

    index = AddCraft(typeof(HarmScroll), 1061742, 3002022, 15.0, 40.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att

    index = AddCraft(typeof(MagicTrapScroll), 1061742, 3002023, 10.0, 40.0, typeof(BlankScroll), 1061740, 1, 1061741);//Male

    index = AddCraft(typeof(MagicUnTrapScroll), 1061742, 3002024, 5.0, 30.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div

    index = AddCraft(typeof(ProtectionScroll), 1061742, 3002025, 5.0, 30.0, typeof(BlankScroll), 1061740, 1, 1061741);//Prot

    index = AddCraft(typeof(StrengthScroll), 1061742, 3002026, 5.0, 35.0, typeof(BlankScroll), 1061740, 1, 1061741);//Bene
            
            //3e cercle
            AddCraft(typeof(BlessScroll), 1061742, 3002027, 20.0, 55.0, typeof(BlankScroll), 1061740, 1, 1061741);//Bene
            AddCraft(typeof(FireballScroll), 1061742, 3002028, 30.0, 55.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(MagicLockScroll), 1061742, 3002029, 20.0, 45.0, typeof(BlankScroll), 1061740, 1, 1061741);//Prot
            AddCraft(typeof(PoisonScroll), 1061742, 3002030, 30.0, 55.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(TelekinisisScroll), 1061742, 3002031, 20.0, 45.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div
            AddCraft(typeof(TeleportScroll), 1061742, 3002032, 20.0, 45.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div
            AddCraft(typeof(UnlockScroll), 1061742, 3002033, 20.0, 45.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div
            AddCraft(typeof(WallOfStoneScroll), 1061742, 3002034, 20.0, 45.0, typeof(BlankScroll), 1061740, 1, 1061741);//Prot
            
            //4e cercle
            AddCraft(typeof(ArchCureScroll), 1061742, 3002035, 40.0, 65.0, typeof(BlankScroll), 1061740, 1, 1061741);//Bene
            AddCraft(typeof(ArchProtectionScroll), 1061742, 3002036, 40.0, 60.0, typeof(BlankScroll), 1061740, 1, 1061741);//Prot
            AddCraft(typeof(CurseScroll), 1061742, 3002037, 45.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);//Male
            AddCraft(typeof(FireFieldScroll), 1061742, 3002038, 50.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
    
    index = AddCraft(typeof(GreaterHealScroll), 1061742, 3002039, 40.0, 65.0, typeof(BlankScroll), 1061740, 1, 1061741);//Bene
            AddSkill(index, SkillName.Anatomy, 50.0, 80.0);
            AddSkill(index, SkillName.Healing, 20.0, 60.0);
            
            AddCraft(typeof(LightningScroll), 1061742, 3002040, 50.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(ManaDrainScroll), 1061742, 3002041, 50.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(RecallScroll), 1061742, 3002042, 40.0, 60.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div
            
            //5e cercle primary fait
            AddCraft(typeof(BladeSpiritsScroll), 1061742, 3002043, 70.0, 85.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(DispelFieldScroll), 1061742, 3002044, 60.0, 75.0, typeof(BlankScroll), 1061740, 1, 1061741);//Prot
            AddCraft(typeof(IncognitoScroll), 1061742, 3002045, 60.0, 75.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div
            AddCraft(typeof(MagicReflectScroll), 1061742, 3002046, 60.0, 75.0, typeof(BlankScroll), 1061740, 1, 1061741);//Prot
            AddCraft(typeof(MindBlastScroll), 1061742, 3002047, 70.0, 85.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(ParalyzeScroll), 1061742, 3002048, 70.0, 85.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(PoisonFieldScroll), 1061742, 3002049, 70.0, 85.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(SummonCreatureScroll), 1061742, 3002050, 70.0, 85.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            
            //6e cercle primary fait
            AddCraft(typeof(DispelScroll), 1061742, 3002051, 75.0, 90.0, typeof(BlankScroll), 1061740, 1, 1061741);//Prot
            AddCraft(typeof(EnergyBoltScroll), 1061742, 3002052, 85.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(ExplosionScroll), 1061742, 3002053, 85.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(InvisibilityScroll), 1061742, 3002054, 10.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(MarkScroll), 1061742, 3002055, 75.0, 90.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div
            AddCraft(typeof(MassCurseScroll), 1061742, 3002056, 80.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);//Male
            AddCraft(typeof(ParalyzeFieldScroll), 1061742, 3002057, 85.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(RevealScroll), 1061742, 3002058, 75.0, 90.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div
            
            //7e cercle primary fait
            AddCraft(typeof(ChainLightningScroll), 1061742, 3002059, 90.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(EnergyFieldScroll), 1061742, 3002060, 80.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);//Prot
            AddCraft(typeof(FlamestrikeScroll), 1061742, 3002061, 90.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(GateTravelScroll), 1061742, 3002062, 80.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div
            AddCraft(typeof(ManaVampireScroll), 1061742, 3002063, 90.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(MassDispelScroll), 1061742, 3002064, 80.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);//Prot
            AddCraft(typeof(MeteorSwarmScroll), 1061742, 3002065, 90.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(PolymorphScroll), 1061742, 3002066, 80.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);//Div

            //8e cercle primary fait
            AddCraft(typeof(EarthquakeScroll), 1061742, 3002067, 110.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(EnergyVortexScroll), 1061742, 3002068, 110.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(ResurrectionScroll), 1061742, 3002069, 100.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);//Bene
            AddCraft(typeof(SummonDaemonScroll), 1061742, 3002071, 110.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(SummonAirElementalScroll), 1061742, 3002070, 110.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(SummonEarthElementalScroll), 1061742, 3002072, 110.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(SummonFireElementalScroll), 1061742, 3002073, 110.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
            AddCraft(typeof(SummonWaterElementalScroll), 1061742, 3002074, 110.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);//Att
           
            #endregion
            
            #region Paladin

            AddCraft(typeof(CleanseByFireScroll), 1060602, 1060585, -10.0, 20.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(CloseWoundsScroll), 1060602, 1060586, 0.0, 30.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ConsecrateWeaponScroll), 1060602, 1060587, 10.0, 40.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DispelEvilScroll), 1060602, 1060588, 20.0, 50.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DivineFuryScroll), 1060602, 1060589, 40.0, 60.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(EnemyOfOneScroll), 1060602, 1060590, 50.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(HolyLightScroll), 1060602, 1060591, 70.0, 90.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(NobleSacrificeScroll), 1060602, 1060592, 90.0, 105.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(RemoveCurseScroll), 1060602, 1060593, 100.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SacredJourneyScroll), 1060602, 1060594, 110.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);

            #endregion

            #region Spellweaver

            AddCraft(typeof(ArcaneCircleScroll), 1071067, 1071026, 20.0, 65.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(GiftOfRenewalScroll), 1071067, 1071027, 20.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ImmolatingWeaponScroll), 1071067, 1071028, 30.0, 75.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(AttuneWeaponScroll), 1071067, 1071029, 30.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ThunderstormScroll), 1071067, 1071030, 40.0, 85.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(NatureFuryScroll), 1071067, 1071031, 40.0, 90.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SummonFeyScroll), 1071067, 1071032, 50.0, 95.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SummonFiendScroll), 1071067, 1071033, 50.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ReaperFormScroll), 1071067, 1071034, 60.0, 105.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(EssenceOfWindScroll), 1071067, 1071035, 60.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(WildfireScroll), 1071067, 1071036, 700.0, 115.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DryadAllureScroll), 1071067, 1071037, 70.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(EtherealVoyageScroll), 1071067, 1071038, 80.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(WordOfDeathScroll), 1071067, 1071039, 80.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(GiftOfLifeScroll), 1071067, 1071040, 90.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ArcaneEmpowermentScroll), 1071067, 1071041, 90.0, 140.0, typeof(BlankScroll), 1061740, 1, 1061741);

            #endregion

            #region Bard

            AddCraft(typeof(AffaiblissementScroll), 1061722, 1061723, 10.0, 50.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(AveuglementScroll), 1061722, 1061724, 30.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ParalysieScroll), 1061722, 1061725, 40.0, 70.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DesarmerScroll), 1061722, 1061726, 50.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(StridenceScroll), 1061722, 1061727, 50.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DecouragementScroll), 1061722, 1061728, 60.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(RatsScroll), 1061722, 1061729, 60.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DrainScroll), 1061722, 1061730, 70.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ProtectionBScroll), 1061722, 1061731, 70.0, 90.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(AcuiteScroll), 1061722, 1061732, 80.0, 90.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DiscretionScroll), 1061722, 1061733, 80.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(CarapaceScroll), 1061722, 1061734, 90.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(AttractionScroll), 1061722, 1061735, 95.0, 140.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ApaisementScroll), 1061722, 1061736, 100.0, 140.0, typeof(BlankScroll), 1061740, 1, 1061741);

            #endregion

            #region Samurai

            AddCraft(typeof(HonorableExecutionScroll), 1060601, 1060595, 0.0, 20.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ConfidenceScroll), 1060601, 1060596, 10.0, 40.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(EvasionScroll), 1060601, 1060597, 30.0, 60.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(CounterAttackScroll), 1060601, 1060598, 60.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(LightningStrikeScroll), 1060601, 1060599, 90.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(MomentumStrikeScroll), 1060601, 1060600, 90.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            
            #endregion

            #region Druide

            //Cercle1
            AddCraft(typeof(DruidfocusScroll), 1061743, 1063509, 10.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(CreateFruitScroll), 1061743, 1063517, 10.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ColerecielScroll), 1061743, 1063508, 10.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ArbremorphScroll), 1061743, 1063511, 10.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(NaturaliaScroll), 1061743, 1063506, 10.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ProtScroll), 1061743, 1063507, 10.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(RefluxScroll), 1061743, 1063523, 10.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ShieldOfEarthScroll), 1061743, 1063490, 10.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(FireflyScroll), 1061743, 1063505, 10.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(VieScroll), 1061743, 1063510, 10.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            //Cercle2
            AddCraft(typeof(HollowReedScroll), 1061743, 1063491, 20.0, 105.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(LureStoneScroll), 1061743, 1063501, 20.0, 105.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(RejetPoisonScroll), 1061743, 1063524, 20.0, 105.0, typeof(BlankScroll), 1061740, 1, 1061741);
            //Cercle3
            AddCraft(typeof(AuraProtectionScroll), 1061743, 1063516, 30.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DonnerFaimScroll), 1061743, 1063518, 30.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(flowerOfEarthScroll), 1061743, 1063519, 30.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(PackOfBeastScroll), 1061743, 1063492, 30.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(PortanceduVentScroll), 1061743, 1063522, 30.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(NaturesPassageScroll), 1061743, 1063502, 30.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(NaturalProtectionScroll), 1061743, 1063529, 30.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(RonceVirulanteScroll), 1061743, 1063527, 30.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            //Cercle4
            AddCraft(typeof(HollowReedScroll), 1061743, 1063491, 40.0, 115.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(InSomnisScroll), 1061743, 1063514, 40.0, 115.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(RejetPoisonMasseScroll), 1061743, 1063525, 40.0, 115.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SomnisScroll), 1061743, 1063513, 40.0, 115.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SpringOfLifeScroll), 1061743, 1063493, 40.0, 115.0, typeof(BlankScroll), 1061740, 1, 1061741);
            //Cercle5
            AddCraft(typeof(ApparenceAnimaleScroll), 1061743, 1063515, 50.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(AntiMatraFieldScroll), 1061743, 1063536, 50.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(GraspingRootsScroll), 1061743, 1063494, 50.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(MurCactusScroll), 1061743, 1063521, 50.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(TreefellowScroll), 1061743, 1063498, 50.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            //Cercle6
            AddCraft(typeof(AntiMatraScroll), 1061743, 1063538, 60.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(BlendWithForestScroll), 1061743, 1063495, 60.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(MushroomCircleScroll), 1061743, 1063499, 60.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(MarqueScroll), 1061743, 1063520, 60.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(NaturalParalyzeFieldScroll), 1061743, 1063528, 60.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(RevelationScroll), 1061743, 1063526, 60.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(VaguedenergieScroll), 1061743, 1063535, 60.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            //Cercle7
            AddCraft(typeof(AntiMatraMassScroll), 1061743, 1063537, 70.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(MushroomGatewayScroll), 1061743, 1063503, 70.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SwarmOfInsectsScroll), 1061743, 1063496, 70.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);
            //Cercle8
            AddCraft(typeof(airvortexScroll), 1061743, 1063533, 80.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(firevortexScroll), 1061743, 1063530, 80.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(watervortexScroll), 1061743, 1063531, 80.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(earthvortexScroll), 1061743, 1063532, 80.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(MassAbeillesScroll), 1061743, 1063534, 80.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(EnchantedGroveScroll), 1061743, 1063500, 80.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(RestorativeSoilScroll), 1061743, 1063504, 80.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(Tree4Scroll), 1061743, 1063512, 80.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(VolcanicEruptionScroll), 1061743, 1063497, 80.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            
            #endregion

            #region Clerc

            AddCraft(typeof(AngelicFaithScroll), 1063539, 1063540, -20.0, 75.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(BanishEvilScroll), 1063539, 1063541, -15.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DampenSpiritScroll), 1063539, 1063542, -10.0, 80.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(DivineFocusScroll), 1063539, 1063543, -5.0, 85.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(HammerOfFaithScroll), 1063539, 1063544, 0.0, 85.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(PurgeScroll), 1063539, 1063545, 35.0, 5.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ResurectionScroll), 1063539, 1063546, 10.0, 90.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SacredBoonScroll), 1063539, 1063547, 15.0, 95.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SacrificeScroll), 1063539, 1063548, 20.0, 95.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SmiteScroll), 1063539, 1063549, 25.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(TouchOfLifeScroll), 1063539, 1063550, 30.0, 100.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(TrialByFireScroll), 1063539, 1063551, 35.0, 105.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(LumiereScroll), 1063539, 1063552, 40.0, 105.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(BeneScroll), 1063539, 1063553, 45.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(repScroll), 1063539, 1063554, 50.0, 110.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(SanctuaireScroll), 1063539, 1063555, 55.0, 115.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ImmobileScroll), 1063539, 1063556, 60.0, 115.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(BouclierScroll), 1063539, 1063557, 65.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(MontureScroll), 1063539, 1063558, 70.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(RobeScroll), 1063539, 1063559, 75.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(AppelScroll), 1063539, 1063560, 80.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(InviteScroll), 1063539, 1063561, 85.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(AppelsScroll), 1063539, 1063562, 90.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(ResutousScroll), 1063539, 1063563, 95.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(MassoinScroll), 1063539, 1063564, 100.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);

            #endregion

            #region Magister

            AddCraft(typeof(feufScroll), 1063588, 1063589, 80.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(foudreScroll), 1063588, 1063590, 80.0, 120.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(FireRainScroll), 1063588, 1063591, 90.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(eboulScroll), 1063588, 1063592, 90.0, 125.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(glaceScroll), 1063588, 1063593, 100.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(cometeScroll), 1063588, 1063594, 100.0, 130.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(cloneScroll), 1063588, 1063595, 100.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(meteorScroll), 1063588, 1063596, 100.0, 135.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(meteorzScroll), 1063588, 1063597, 110.0, 140.0, typeof(BlankScroll), 1061740, 1, 1061741);
            AddCraft(typeof(seismeScroll), 1063588, 1063598, 110.0, 140.0, typeof(BlankScroll), 1061740, 1, 1061741);

            #endregion

        }
    }
}