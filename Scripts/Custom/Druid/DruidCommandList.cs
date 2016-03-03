/*
 * Created by SharpDevelop.
 * User: em
 * Date: 22/08/2004
 * Time: 20:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Druid;


namespace Server.Commands
{
	public class CastDruidSpells
	{
		public static void Initialize()
		{
            CommandSystem.Prefix = ".";
            CommandSystem.Register("KesEnSepaOhm", AccessLevel.Player, new CommandEventHandler(KesEnSepaOhm_OnCommand));
            CommandSystem.Register("EnCrurAetaSecEnEss", AccessLevel.Player, new CommandEventHandler(EnCrurAetaSecEnEss_OnCommand));
            CommandSystem.Register("EnSecOhmEssSepa", AccessLevel.Player, new CommandEventHandler(EnSecOhmEssSepa_OnCommand));
            CommandSystem.Register("EnSepaAete", AccessLevel.Player, new CommandEventHandler(EnSepaAete_OnCommand));
            CommandSystem.Register("EnOhmSepaTiaKes", AccessLevel.Player, new CommandEventHandler(EnOhmSepaTiaKes_OnCommand));
            CommandSystem.Register("KesOhm", AccessLevel.Player, new CommandEventHandler(KesOhm_OnCommand));
            CommandSystem.Register("EssOhmEnSecTia", AccessLevel.Player, new CommandEventHandler(EssOhmEnSecTia_OnCommand));
            CommandSystem.Register("VaukOhmEnTiaCrur", AccessLevel.Player, new CommandEventHandler(VaukOhmEnTiaCrur_OnCommand));
            CommandSystem.Register("KesEnSepaOhmCrur", AccessLevel.Player, new CommandEventHandler(KesEnSepaOhmCrur_OnCommand));
            CommandSystem.Register("EnEssOhm", AccessLevel.Player, new CommandEventHandler(EnEssOhm_OnCommand));
            CommandSystem.Register("EnAnteOhmSepa", AccessLevel.Player, new CommandEventHandler(EnAnteOhmSepa_OnCommand));
            CommandSystem.Register("EnKesOhmCrur", AccessLevel.Player, new CommandEventHandler(EnKesOhmCrur_OnCommand));
            CommandSystem.Register("KesSecVauk", AccessLevel.Player, new CommandEventHandler(KesSecVauk_OnCommand));
            CommandSystem.Register("VaukSepaOhm", AccessLevel.Player, new CommandEventHandler(VaukSepaOhm_OnCommand));
            CommandSystem.Register("OhmSepaAnte", AccessLevel.Player, new CommandEventHandler(OhmSepaAnte_OnCommand));
            CommandSystem.Register("KesEnCrur", AccessLevel.Player, new CommandEventHandler(KesEnCrur_OnCommand));
            CommandSystem.Register("NarThot", AccessLevel.Player, new CommandEventHandler(NarThot_OnCommand));
            CommandSystem.Register("HocPaoPieras", AccessLevel.Player, new CommandEventHandler(HocPaoPieras_OnCommand));
            CommandSystem.Register("FlorActMosTar", AccessLevel.Player, new CommandEventHandler(FlorActMosTar_OnCommand));
            CommandSystem.Register("MasFurrVimas", AccessLevel.Player, new CommandEventHandler(MasFurrVimas_OnCommand));
            CommandSystem.Register("NosTiaKoAmmEss", AccessLevel.Player, new CommandEventHandler(NosTiaKoAmmEss_OnCommand));
            CommandSystem.Register("NosTeHouuuur", AccessLevel.Player, new CommandEventHandler(NosTeHouuuur_OnCommand));
            CommandSystem.Register("KesEnSepaOhmMas", AccessLevel.Player, new CommandEventHandler(KesEnSepaOhmMas_OnCommand));
            CommandSystem.Register("EnVosSomnis", AccessLevel.Player, new CommandEventHandler(EnVosSomnis_OnCommand));
            CommandSystem.Register("OsvorInSomnis", AccessLevel.Player, new CommandEventHandler(OsvorInSomnis_OnCommand));
            CommandSystem.Register("NatAnmal", AccessLevel.Player, new CommandEventHandler(NatAnmal_OnCommand));
            CommandSystem.Register("ReMinSat", AccessLevel.Player, new CommandEventHandler(ReMinSat_OnCommand));
            CommandSystem.Register("NiFruLem", AccessLevel.Player, new CommandEventHandler(NiFruLem_OnCommand));
            CommandSystem.Register("LemNe", AccessLevel.Player, new CommandEventHandler(LemNe_OnCommand));
            CommandSystem.Register("EnAnteOhmFloras", AccessLevel.Player, new CommandEventHandler(EnAnteOhmFloras_OnCommand));
            CommandSystem.Register("KelParLem", AccessLevel.Player, new CommandEventHandler(KelParLem_OnCommand));
            CommandSystem.Register("CakanGrav", AccessLevel.Player, new CommandEventHandler(CakanGrav_OnCommand));
            CommandSystem.Register("ReVen", AccessLevel.Player, new CommandEventHandler(ReVen_OnCommand));
            CommandSystem.Register("Manro", AccessLevel.Player, new CommandEventHandler(Manro_OnCommand));
            CommandSystem.Register("NoxNei", AccessLevel.Player, new CommandEventHandler(NoxNei_OnCommand));
            CommandSystem.Register("MasNoxNei", AccessLevel.Player, new CommandEventHandler(MasNoxNei_OnCommand));
            CommandSystem.Register("WosQuos", AccessLevel.Player, new CommandEventHandler(WosQuos_OnCommand));
            CommandSystem.Register("AxNoxPla", AccessLevel.Player, new CommandEventHandler(AxNoxPla_OnCommand));
            CommandSystem.Register("EnKesGrav", AccessLevel.Player, new CommandEventHandler(EnKesGrav_OnCommand));
            CommandSystem.Register("EnCrurSanct", AccessLevel.Player, new CommandEventHandler(EnCrurSanct_OnCommand));
            CommandSystem.Register("KesEnFlam", AccessLevel.Player, new CommandEventHandler(KesEnFlam_OnCommand));
            CommandSystem.Register("KesEnAnFlam", AccessLevel.Player, new CommandEventHandler(KesEnAnFlam_OnCommand));
            CommandSystem.Register("KesEnYlem", AccessLevel.Player, new CommandEventHandler(KesEnYlem_OnCommand));
            CommandSystem.Register("KesEnHur", AccessLevel.Player, new CommandEventHandler(KesEnHur_OnCommand));
            CommandSystem.Register("VasCorpNat", AccessLevel.Player, new CommandEventHandler(VasCorpNat_OnCommand));
            CommandSystem.Register("KesEnPor", AccessLevel.Player, new CommandEventHandler(KesEnPor_OnCommand));
            CommandSystem.Register("AnGravIel", AccessLevel.Player, new CommandEventHandler(AnGravIel_OnCommand));
            CommandSystem.Register("VasAnNat", AccessLevel.Player, new CommandEventHandler(VasAnNat_OnCommand));
            CommandSystem.Register("AnOrtNat", AccessLevel.Player, new CommandEventHandler(AnOrtNat_OnCommand));
		}

		public static void Register( string command, AccessLevel access, CommandEventHandler handler )
		{
            CommandSystem.Register(command, access, handler);
		}

		public static bool HasSpell( Mobile from, int spellID )
		{
			Spellbook book = Spellbook.Find( from, spellID );

			return ( book != null && book.HasSpell( spellID ) );
		}

		[Usage( "KesEnSepaOhm" )]
		[Description( "Barriere Naturel." )]
		public static void KesEnSepaOhm_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing
				
				if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 301 ) )
					{
					new ShieldOfEarthSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "EnCrurAetaSecEnEss" )]
		[Description( "Force de terre" )]
		public static void EnCrurAetaSecEnEss_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 302 ) )
					{
					new HollowReedSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "EnSecOhmEssSepa" )]
		[Description( "Invoquer la meute." )]
		public static void EnSecOhmEssSepa_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 303 ) )
					{
					new PackOfBeastSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "EnSepaAete" )]
		[Description( "Printemps de Vie." )]
		public static void EnSepaAete_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 304 ) )
					{
					new SpringOfLifeSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "EnOhmSepaTiaKes" )]
		[Description( "Enchemetrement." )]
		public static void EnOhmSepaTiaKes_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 305 ) )
					{
					new GraspingRootsSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "KesOhm" )]
		[Description( "Dissimulation." )]
		public static void KesOhm_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 306 ) )
					{
					new BlendWithForestSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "EssOhmEnSecTia" )]
		[Description( "Nuee d'abeilles." )]
		public static void EssOhmEnSecTia_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) //&& ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 307 ) )
					{
					new SwarmOfInsectsSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "VaukOhmEnTiaCrur" )]
		[Description( "Colere du volcan." )]
		public static void VaukOhmEnTiaCrur_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 308 ) )
					{
					new VolcanicEruptionSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "KesEnSepaOhmCrur" )]
		[Description( "Etre Sylvain." )]
		public static void KesEnSepaOhmCrur_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 309 ) )
					{
					new TreefellowSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "EnEssOhm" )]
		[Description( "Cercle de pierre." )]
		public static void EnEssOhm_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 310 ) )
					{
					new StoneCircleSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "EnAnteOhmSepa" )]
		[Description( "Son Enchante." )]
		public static void EnAnteOhmSepa_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 311 ) )
					{
					new EnchantedGroveSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "EnKesOhmCrur" )]
		[Description( "Leure de pierre." )]
		public static void EnKesOhmCrur_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 312 ) )
					{
					new LureStoneSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "KesSecVauk" )]
		[Description( "Voie de la Nature." )]
		public static void KesSecVauk_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 313 ) )
					{
					new NaturesPassageSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "VaukSepaOhm" )]
		[Description( "Voie du champignon." )]
		public static void VaukSepaOhm_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 314 ) )
					{
					new MushroomGatewaySpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "OhmSepaAnte" )]
		[Description( "Engrais de Vie." )]
		public static void OhmSepaAnte_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 315 ) )
					{
					new RestorativeSoilSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "KesEnCrur" )]
		[Description( "Lumiere volante." )]
		public static void KesEnCrur_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 316 ) )
					{
					new FireflySpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "NarThot" )]
		[Description( "Santuaire." )]
		public static void NarThot_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 317 ) )
					{
					new NaturaliasSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "HocPaoPieras" )]
		[Description( "Peau de pierre." )]
		public static void HocPaoPieras_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 318 ) )
					{
					new Protspell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "FlorActMosTar" )]
		[Description( "Celere du ciel." )]
		public static void FlorActMosTar_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 319 ) )
					{
					new FoudreSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "MasFurrVimas" )]
		[Description( "Vitalitee." )]
		public static void MasFurrVimas_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 320 ) )
					{
					new Viespell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "NosTiaKoAmmEss" )]
		[Description( "Arbres Anciens." )]
		public static void NosTiaKoAmmEss_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 321 ) )
					{
					new Arbremorph( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "NosTeHouuuur" )]
		[Description( "Force de vie." )]
		public static void NosTeHouuuur_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 322 ) )
					{
					new DruideFocusSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "KesEnSepaOhmMas" )]
		[Description( "Appel des guardiens." )]
		public static void KesEnSepaOhmMas_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 323 ) )
					{
					new Tree4Spell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "EnVosSomnis" )]
		[Description( "Somnis." )]
		public static void EnVosSomnis_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 324 ) )
					{
					new Somnispell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "OsvorInSomnis" )]
		[Description( "InSomsnis." )]
		public static void OsvorInSomnis_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 325 ) )
					{
					new Insomnispell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "NatAnmal" )]
		[Description( "Apparence animale." )]
		public static void NatAnmal_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 326 ) )
					{
					new ApparenceAnimaleSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "ReMinSat" )]
		[Description( "Aure de protection." )]
		public static void ReMinSat_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 327 ) )
					{
					new AuraProtectionSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "NiFruLem" )]
		[Description( "Creation de fruits." )]
		public static void NiFruLem_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 328 ) )
					{
					new CreationFruitSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "LemNe" )]
		[Description( "Donner la faim." )]
		public static void LemNe_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 329 ) )
					{
					new DonnerFaimSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "EnAnteOhmFloras" )]
		[Description( "Fleurs." )]
		public static void EnAnteOhmFloras_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 330 ) )
					{
					new flowerOfEarthSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "KelParLem" )]
		[Description( "Marque." )]
		public static void KelParLem_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 331 ) )
					{
					new MarqueSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "CakanGrav" )]
		[Description( "Mur de cactus." )]
		public static void CakanGrav_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 332 ) )
					{
					new MurCactusSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "ReVen" )]
		[Description( "Portence du vent." )]
		public static void ReVen_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 333 ) )
					{
					new PortanceduVentSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "Manro" )]
		[Description( "Reflux." )]
		public static void Manro_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 334 ) )
					{
					new RefluxSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "NoxNei" )]
		[Description( "Rejet du poison." )]
		public static void NoxNei_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 335 ) )
					{
					new RejetPoisonSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "MasNoxNei" )]
		[Description( "Rejet du poison de masse." )]
		public static void MasNoxNei_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 336 ) )
					{
					new RejetPoisonMasseSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "WosQuos" )]
		[Description( "Perception naturelle." )]
		public static void WosQuos_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 337 ) )
					{
					new RevelationSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		
		[Usage( "AxNoxPla" )]
		[Description( "Ronce virulentes." )]
		public static void AxNoxPla_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 338 ) )
					{
					new RonceVirulanteSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		[Usage( "EnKesGrav" )]
		[Description( "Mur naturel paralysant." )]
		public static void EnKesGrav_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 339 ) )
					{
					new NaturalParalyzeFieldSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		[Usage( "EnCrurSanct" )]
		[Description( "Mur naturel paralysant." )]
		public static void EnCrurSanct_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 340 ) )
					{
					new NaturalProtectionSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		[Usage( "KesEnFlam" )]
		[Description( "Vortex de feu." )]
		public static void KesEnFlam_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 341 ) )
					{
					new firevortexSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}		
		[Usage( "KesEnAnFlam" )]
		[Description( "Vortex d eau." )]
		public static void KesEnAnFlam_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 342 ) )
					{
					new watervortexSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}		
		
		[Usage( "KesEnYlem" )]
		[Description( "Vortex de terre." )]
		public static void KesEnYlem_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 343 ) )
					{
					new earthvortexSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}			
		[Usage( "KesEnHur" )]
		[Description( "Vortex d air." )]
		public static void KesEnHur_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 344 ) )
					{
					new airvortexSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}		
		[Usage( "VasCorpNat" )]
		[Description( "Essain d'abeille" )]
		public static void VasCorpNat_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 345 ) )
					{
					new MassAbeillesSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}			
		[Usage( "KesEnPor" )]
		[Description( "Vague d energie" )]
		public static void KesEnPor_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 346 ) )
					{
					new VaguedenergieSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}
		[Usage( "AnGravIel" )]
		[Description( "AntiMatra de champ" )]
		public static void AnGravIel_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 347 ) )
					{
					new AntiMatraFieldSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}		
		[Usage( "VasAnNat" )]
		[Description( "AntiMatra de masse" )]
		public static void VasAnNat_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 348 ) )
					{
					new AntiMatraMassSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}		
		[Usage( "AnOrtNat" )]
		[Description( "AntiMatra " )]
		public static void AnOrtNat_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;
				
				if ( !Multis.DesignContext.Check( e.Mobile ) )
         		        				return; // They are customizing

                if (from is PlayerMobile) // && ((PlayerMobile)from).Druidisme )
				{
					if ( HasSpell( from, 349 ) )
					{
					new AntiMatraSpell( e.Mobile, null ).Cast();
					}
						else
						{
						from.SendLocalizedMessage( 500015 ); // Vous ne disposez pas de se sort!
						} 
				}
				else
				{
				from.SendMessage ("Vous devez être druide pour pouvoir lancer cela");
				return;
				}  		

		}		
		
						
		
	}
}
