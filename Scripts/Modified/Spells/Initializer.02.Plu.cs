/* 
 * Scriptiz 9/11/07 : Ajout des sorts pour le livre de barde (ligne 128 à 146)
 * Plume 14/02/08 : Retrait des sorts de bardes temporaire
 * Plume 14/02/08 : Ajout des sorts de Spellweaver.
 */
using System;
using Server;

namespace Server.Spells
{
	public class Initializer
	{
		public static void Initialize()
		{
			// First circle
			Register( 00, typeof( First.ClumsySpell ) );
			Register( 01, typeof( First.CreateFoodSpell ) );
			Register( 02, typeof( First.FeeblemindSpell ) );
			Register( 03, typeof( First.HealSpell ) );
			Register( 04, typeof( First.MagicArrowSpell ) );
			Register( 05, typeof( First.NightSightSpell ) );
			Register( 06, typeof( First.ReactiveArmorSpell ) );
			Register( 07, typeof( First.WeakenSpell ) );

			// Second circle
			Register( 08, typeof( Second.AgilitySpell ) );
			Register( 09, typeof( Second.CunningSpell ) );
			Register( 10, typeof( Second.CureSpell ) );
			Register( 11, typeof( Second.HarmSpell ) );
			Register( 12, typeof( Second.MagicTrapSpell ) );
			Register( 13, typeof( Second.RemoveTrapSpell ) );
			Register( 14, typeof( Second.ProtectionSpell ) );
			Register( 15, typeof( Second.StrengthSpell ) );

			// Third circle
			Register( 16, typeof( Third.BlessSpell ) );
			Register( 17, typeof( Third.FireballSpell ) );
			Register( 18, typeof( Third.MagicLockSpell ) );
			Register( 19, typeof( Third.PoisonSpell ) );
			Register( 20, typeof( Third.TelekinesisSpell ) );
			Register( 21, typeof( Third.TeleportSpell ) );
			Register( 22, typeof( Third.UnlockSpell ) );
			Register( 23, typeof( Third.WallOfStoneSpell ) );

			// Fourth circle
			Register( 24, typeof( Fourth.ArchCureSpell ) );
			Register( 25, typeof( Fourth.ArchProtectionSpell ) );
			Register( 26, typeof( Fourth.CurseSpell ) );
			Register( 27, typeof( Fourth.FireFieldSpell ) );
			Register( 28, typeof( Fourth.GreaterHealSpell ) );
			Register( 29, typeof( Fourth.LightningSpell ) );
			Register( 30, typeof( Fourth.ManaDrainSpell ) );
			Register( 31, typeof( Fourth.RecallSpell ) );

			// Fifth circle
			Register( 32, typeof( Fifth.BladeSpiritsSpell ) );
			Register( 33, typeof( Fifth.DispelFieldSpell ) );
			Register( 34, typeof( Fifth.IncognitoSpell ) );
			Register( 35, typeof( Fifth.MagicReflectSpell ) );
			Register( 36, typeof( Fifth.MindBlastSpell ) );
			Register( 37, typeof( Fifth.ParalyzeSpell ) );
			Register( 38, typeof( Fifth.PoisonFieldSpell ) );
			Register( 39, typeof( Fifth.SummonCreatureSpell ) );

			// Sixth circle
			Register( 40, typeof( Sixth.DispelSpell ) );
			Register( 41, typeof( Sixth.EnergyBoltSpell ) );
			Register( 42, typeof( Sixth.ExplosionSpell ) );
			Register( 43, typeof( Sixth.InvisibilitySpell ) );
			Register( 44, typeof( Sixth.MarkSpell ) );
			Register( 45, typeof( Sixth.MassCurseSpell ) );
			Register( 46, typeof( Sixth.ParalyzeFieldSpell ) );
			Register( 47, typeof( Sixth.RevealSpell ) );

			// Seventh circle
			Register( 48, typeof( Seventh.ChainLightningSpell ) );
			Register( 49, typeof( Seventh.EnergyFieldSpell ) );
			Register( 50, typeof( Seventh.FlameStrikeSpell ) );
			Register( 51, typeof( Seventh.GateTravelSpell ) );
			Register( 52, typeof( Seventh.ManaVampireSpell ) );
			Register( 53, typeof( Seventh.MassDispelSpell ) );
			Register( 54, typeof( Seventh.MeteorSwarmSpell ) );
			Register( 55, typeof( Seventh.PolymorphSpell ) );

			// Eighth circle
			Register( 56, typeof( Eighth.EarthquakeSpell ) );
			Register( 57, typeof( Eighth.EnergyVortexSpell ) );
			Register( 58, typeof( Eighth.ResurrectionSpell ) );
			Register( 59, typeof( Eighth.AirElementalSpell ) );
			Register( 60, typeof( Eighth.SummonDaemonSpell ) );
			Register( 61, typeof( Eighth.EarthElementalSpell ) );
			Register( 62, typeof( Eighth.FireElementalSpell ) );
			Register( 63, typeof( Eighth.WaterElementalSpell ) );

			if ( Core.AOS )
			{
				// Necromancy spells
				Register( 100, typeof( Necromancy.AnimateDeadSpell ) );
				Register( 101, typeof( Necromancy.BloodOathSpell ) );
				Register( 102, typeof( Necromancy.CorpseSkinSpell ) );
				Register( 103, typeof( Necromancy.CurseWeaponSpell ) );
				Register( 104, typeof( Necromancy.EvilOmenSpell ) );
				Register( 105, typeof( Necromancy.HorrificBeastSpell ) );
				Register( 106, typeof( Necromancy.LichFormSpell ) );
				Register( 107, typeof( Necromancy.MindRotSpell ) );
				Register( 108, typeof( Necromancy.PainSpikeSpell ) );
				Register( 109, typeof( Necromancy.PoisonStrikeSpell ) );
				Register( 110, typeof( Necromancy.StrangleSpell ) );
				Register( 111, typeof( Necromancy.SummonFamiliarSpell ) );
				Register( 112, typeof( Necromancy.VampiricEmbraceSpell ) );
				Register( 113, typeof( Necromancy.VengefulSpiritSpell ) );
				Register( 114, typeof( Necromancy.WitherSpell ) );
				Register( 115, typeof( Necromancy.WraithFormSpell ) );
                if (Core.SE)
                    Register(116, typeof(Necromancy.ExorcismSpell));

                // Necromancy spells 2
                Register(130, typeof(Daemonic.DaemonicPoison));
                Register(131, typeof(Daemonic.Proie));
                Register(122, typeof(Daemonic.DrainVie));
                Register(133, typeof(Daemonic.Feuzone));
                Register(134, typeof(Daemonic.Carapace));
                Register(135, typeof(Daemonic.LVampire));
                Register(136, typeof(Daemonic.Maleficio));
                Register(137, typeof(Daemonic.NueesD));
                Register(138, typeof(Daemonic.Medusa));
                Register(139, typeof(Daemonic.Draco));

                // Paladin abilities
				Register( 200, typeof( Chivalry.CleanseByFireSpell ) );
				Register( 201, typeof( Chivalry.CloseWoundsSpell ) );
				Register( 202, typeof( Chivalry.ConsecrateWeaponSpell ) );
				Register( 203, typeof( Chivalry.DispelEvilSpell ) );
				Register( 204, typeof( Chivalry.DivineFurySpell ) );
				Register( 205, typeof( Chivalry.EnemyOfOneSpell ) );
				Register( 206, typeof( Chivalry.HolyLightSpell ) );
				Register( 207, typeof( Chivalry.NobleSacrificeSpell ) );
				Register( 208, typeof( Chivalry.RemoveCurseSpell ) );
				Register( 209, typeof( Chivalry.SacredJourneySpell ) );

                // Paladin sombre
                Register(220, typeof(DarkPaladin.DPCleanseByFireSpell));
                Register(221, typeof(DarkPaladin.DPCloseWoundsSpell));
                Register(222, typeof(DarkPaladin.DPConsecrateWeaponSpell));
                Register(223, typeof(DarkPaladin.DPDispelEvilSpell));
                Register(224, typeof(DarkPaladin.DPDivineFurySpell));
                Register(225, typeof(DarkPaladin.DPEnemyOfOneSpell));
                Register(226, typeof(DarkPaladin.DPHolyLightSpell));
                Register(227, typeof(DarkPaladin.DPNobleSacrificeSpell));
                Register(228, typeof(DarkPaladin.DPRemoveCurseSpell));
                Register(229, typeof(DarkPaladin.DPSacredJourneySpell));

                // Scriptiz[ (livre de barde) > rajout des sorts (sorts_barde)
                // Barde abilities
                Register(301, typeof(Barde.AffaiblissementSpell));
                Register(302, typeof(Barde.AveuglementSpell));
                Register(303, typeof(Barde.ParalysieSpell));
                Register(304, typeof(Barde.DesarmerSpell));
                Register(305, typeof(Barde.StridenceSpell));
                Register(306, typeof(Barde.DecouragementSpell));
                Register(307, typeof(Barde.RatsSpell));
                Register(308, typeof(Barde.DrainSpell));
                Register(309, typeof(Barde.ProtectionBSpell));
                Register(310, typeof(Barde.AcuiteSpell));
                Register(311, typeof(Barde.DiscretionSpell));
                Register(312, typeof(Barde.CarapaceSpell));
                Register(313, typeof(Barde.RetourSourcesSpell));
                Register(314, typeof(Barde.CourageSpell));
                Register(315, typeof(Barde.AttractionSpell));
                Register(316, typeof(Barde.ApaisementSpell));
                // ]Scriptiz

                if ( Core.SE )
				{
					// Samurai abilities
					Register( 400, typeof( Bushido.HonorableExecution ) );
					Register( 401, typeof( Bushido.Confidence ) );
					Register( 402, typeof( Bushido.Evasion ) );
					Register( 403, typeof( Bushido.CounterAttack ) );
					Register( 404, typeof( Bushido.LightningStrike ) );
					Register( 405, typeof( Bushido.MomentumStrike ) );

					// Ninja abilities
					Register( 500, typeof( Ninjitsu.FocusAttack ) );
					Register( 501, typeof( Ninjitsu.DeathStrike ) );
					Register( 502, typeof( Ninjitsu.AnimalForm ) );
					Register( 503, typeof( Ninjitsu.KiAttack ) );
					Register( 504, typeof( Ninjitsu.SurpriseAttack ) );
					Register( 505, typeof( Ninjitsu.Backstab ) );
					Register( 506, typeof( Ninjitsu.Shadowjump ) );
					Register( 507, typeof( Ninjitsu.MirrorImage ) );


                    Register(600, typeof(Spellweaving.ArcaneCircleSpell));
                    Register(601, typeof(Spellweaving.GiftOfRenewalSpell));
                    //Register( 602, typeof( Spellweaving.ImmolatingWeaponSpell ) );
                    Register(603, typeof(Spellweaving.AttuneWeaponSpell));
                    Register(604, typeof(Spellweaving.ThunderstormSpell));
                    Register(605, typeof(Spellweaving.NatureFurySpell));
                    Register(606, typeof(Spellweaving.SummonFeySpell));
                    Register(607, typeof(Spellweaving.SummonFiendSpell));
                    Register(608, typeof(Spellweaving.ReaperFormSpell));
                    //Register( 609, typeof( Spellweaving.WildfireSpell ) );
                    Register(610, typeof(Spellweaving.EssenceOfWindSpell));
                    //Register( 611, typeof( Spellweaving.DryadAllureSpell ) );
                    Register(612, typeof(Spellweaving.EtherealVoyageSpell));
                    Register(613, typeof(Spellweaving.WordOfDeathSpell));
                    Register(614, typeof(Spellweaving.GiftOfLifeSpell));
                    //Register( 615, typeof( Spellweaving.ArcaneEmpowermentSpell ) );
                }

                // Druid Spells 
                Register(701, typeof(Druid.ShieldOfEarthSpell));
                Register(702, typeof(Druid.HollowReedSpell));
                Register(703, typeof(Druid.PackOfBeastSpell));
                Register(704, typeof(Druid.SpringOfLifeSpell));
                Register(705, typeof(Druid.GraspingRootsSpell));
                Register(706, typeof(Druid.BlendWithForestSpell));
                Register(707, typeof(Druid.SwarmOfInsectsSpell));
                Register(708, typeof(Druid.VolcanicEruptionSpell));
                Register(709, typeof(Druid.TreefellowSpell));
                Register(710, typeof(Druid.StoneCircleSpell));
                Register(711, typeof(Druid.EnchantedGroveSpell));
                Register(712, typeof(Druid.LureStoneSpell));
                Register(713, typeof(Druid.NaturesPassageSpell));
                Register(714, typeof(Druid.MushroomGatewaySpell));
                Register(715, typeof(Druid.RestorativeSoilSpell));
                Register(716, typeof(Druid.FireflySpell));
                Register(717, typeof(Druid.NaturaliasSpell));
                Register(718, typeof(Druid.Protspell));
                Register(719, typeof(Druid.FoudreSpell));
                Register(720, typeof(Druid.Viespell));
                Register(721, typeof(Druid.Arbremorph));
                Register(722, typeof(Druid.DruideFocusSpell));
                Register(723, typeof(Druid.Tree4Spell));
                Register(724, typeof(Druid.Somnispell));
                Register(725, typeof(Druid.Insomnispell));
                Register(726, typeof(Druid.ApparenceAnimaleSpell));
                Register(727, typeof(Druid.AuraProtectionSpell));
                Register(728, typeof(Druid.CreationFruitSpell));
                Register(729, typeof(Druid.DonnerFaimSpell));
                Register(730, typeof(Druid.flowerOfEarthSpell));
                Register(731, typeof(Druid.MarqueSpell));
                Register(732, typeof(Druid.MurCactusSpell));
                Register(733, typeof(Druid.PortanceduVentSpell));
                Register(734, typeof(Druid.RefluxSpell));
                Register(735, typeof(Druid.RejetPoisonSpell));
                Register(736, typeof(Druid.RejetPoisonMasseSpell));
                Register(737, typeof(Druid.RevelationSpell));
                Register(738, typeof(Druid.RonceVirulanteSpell));
                Register(739, typeof(Druid.NaturalParalyzeFieldSpell));
                Register(740, typeof(Druid.NaturalProtectionSpell));
                Register(741, typeof(Druid.firevortexSpell));
                Register(742, typeof(Druid.watervortexSpell));
                Register(743, typeof(Druid.earthvortexSpell));
                Register(744, typeof(Druid.airvortexSpell));
                Register(745, typeof(Druid.MassAbeillesSpell));
                Register(746, typeof(Druid.VaguedenergieSpell));
                Register(747, typeof(Druid.AntiMatraFieldSpell));
                Register(748, typeof(Druid.AntiMatraMassSpell));
                Register(749, typeof(Druid.AntiMatraSpell));

                //cleric spell 
                Register(801, typeof(Cleric.AngelicFaithSpell));
                Register(802, typeof(Cleric.BanishEvilSpell));
                Register(803, typeof(Cleric.DampenSpiritSpell));
                Register(804, typeof(Cleric.DivineFocusSpell));
                Register(805, typeof(Cleric.HammerOfFaithSpell));
                Register(806, typeof(Cleric.PurgeSpell));
                Register(807, typeof(Cleric.ResurectionSpell));
                Register(808, typeof(Cleric.SacredBoonSpell));
                Register(809, typeof(Cleric.SacrificeSpell));
                Register(810, typeof(Cleric.SmiteSpell));
                Register(811, typeof(Cleric.TouchOfLifeSpell));
                Register(812, typeof(Cleric.TrialByFireSpell));
                Register(813, typeof(Cleric.LumiereSpell));
                Register(814, typeof(Cleric.BeneSpell));
                Register(815, typeof(Cleric.repSpell));
                Register(816, typeof(Cleric.SanctuaireSpell));
                Register(817, typeof(Cleric.ImmobileSpell));
                Register(818, typeof(Cleric.BouclierSpell));
                Register(819, typeof(Cleric.MontureSpell));
                Register(820, typeof(Cleric.RobeSpell));
                Register(821, typeof(Cleric.AppelSpell));
                Register(822, typeof(Cleric.AppelsSpell));
                Register(823, typeof(Cleric.InviteSpell));
                Register(824, typeof(Cleric.ResutousSpell));
                Register(825, typeof(Cleric.MassoinSpell));

                // magister

                Register(901, typeof(Magister.feuf));
                Register(902, typeof(Magister.FireRain));
                Register(903, typeof(Magister.foudre));
                Register(904, typeof(Magister.eboul));
                Register(905, typeof(Magister.glace));
                Register(906, typeof(Magister.Comete));
                Register(907, typeof(Magister.clonesp));
                Register(908, typeof(Magister.meteor));
                Register(909, typeof(Magister.meteorz));
                Register(910, typeof(Magister.seisme));

            }
		}

		public static void Register( int spellID, Type type )
		{
			SpellRegistry.Register( spellID, type );
		}
	}
}