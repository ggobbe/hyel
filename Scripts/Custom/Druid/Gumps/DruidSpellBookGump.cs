using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Spells.Druid;
using Server.Prompts;

namespace Server.Gumps
{
   public class DruidicSpellbookGump : Gump
   {
       private DruidSpellbook m_Book;

      int gth = 0x903;
      private void AddBackground()
      {
         AddPage( 0 );

         AddImage( 100, 10, 0x89B, 0 );
      }


      public static bool HasSpell( Mobile from, int spellID )
      {
         Spellbook book = Spellbook.Find( from, spellID );
         return ( book != null && book.HasSpell( spellID ) );
      }



      public DruidicSpellbookGump(Mobile from, DruidSpellbook book): base(150, 200)
      {
      	
         m_Book = book;
         AddBackground();
AddPage( 1 );
		AddHtml( 145, 22, 130, 20, "<BASEFONT COLOR=#BF0600>Livre de la Nature", false, false );
      	//AddLabel( 150, 17, gth, "Livre de la Nature" );
        int sbtn = 0x93A;
        int dby = 40;
		int dbpy = 40;;
		AddButton( 396, 14, 0x89E, 0x89E, 17, GumpButtonType.Page, 2 );
	
         if (HasSpell( from, 716) )
         {
         	AddLabel( 145, dbpy, gth, "Lumiere volante" );
            AddButton( 125, dbpy + 3, sbtn, sbtn, 16, GumpButtonType.Reply, 1 );
            dby = dby + 20;
         }
         if (HasSpell( from, 702) )
         {
         	AddLabel( 145, dby, gth, "Forces Terre" );
            AddButton( 125, dby + 3, sbtn, sbtn, 2, GumpButtonType.Reply, 1 );
            dby = dby + 20;
        
            }
         if (HasSpell( from, 703) )
         {
            AddLabel( 145, dby, gth, "Invoquer la Meute" );
            AddButton( 125, dby + 3, sbtn, sbtn, 3, GumpButtonType.Reply, 1 );
            dby = dby + 20;
         }
         if (HasSpell( from, 704) )
         {
            AddLabel( 145, dby, gth, "Printemps de vie" );
            AddButton( 125, dby + 3, sbtn, sbtn, 4, GumpButtonType.Reply, 1 );
            dby = dby + 20;
         }
         if (HasSpell( from, 705) )
         {
            AddLabel( 145, dby, gth, "Enchevetrement" );
            AddButton( 125, dby + 3, sbtn, sbtn, 5, GumpButtonType.Reply, 1 );
            dby = dby + 20;
         }
         if (HasSpell(from, 706))
         {
            AddLabel( 145, dby, gth, "Dissimulation" );
            AddButton( 125, dby + 3, sbtn, sbtn, 6, GumpButtonType.Reply, 1 );
            dby = dby + 20;
         }
         if (HasSpell(from, 707))
         {
            AddLabel( 145, dby, gth, "Nuée d'abeilles" );
            AddButton( 125, dby + 3, sbtn, sbtn, 7, GumpButtonType.Reply, 1 );
            dby = dby + 20;
         }
         if (HasSpell(from, 708))
         {
            AddLabel( 145, dby, gth, "Colere du Volcan" );
            AddButton( 125, dby + 3, sbtn, sbtn, 8, GumpButtonType.Reply, 1 );
         }
         if (HasSpell(from, 709))
         {
            AddLabel( 315, dbpy, gth, "Etre Sylvain" );
            AddButton( 295, dbpy + 3, sbtn, sbtn, 9, GumpButtonType.Reply, 1 );
            dbpy = dbpy + 20;
         }
         if (HasSpell(from, 710))
         {
            AddLabel( 315, dbpy, gth, "Cercle de pierre" );
            AddButton( 295, dbpy + 3, sbtn, sbtn, 10, GumpButtonType.Reply, 1 );
            dbpy = dbpy + 20;
         }
         if (HasSpell(from, 711))
         {
            AddLabel( 315, dbpy, gth, "Son enchanté" );
            AddButton( 295, dbpy + 3, sbtn, sbtn, 11, GumpButtonType.Reply, 1 );
            dbpy = dbpy + 20;
         }
         if (HasSpell(from, 712))
         {
         	AddLabel( 315, dbpy, gth, "Leurre de pierre" );
            AddButton( 295, dbpy + 3, sbtn, sbtn, 12, GumpButtonType.Reply, 1 );
            dbpy = dbpy + 20;
         }
         if (HasSpell(from, 713))
         {
            AddLabel( 315, dbpy, gth, "Voie de la nature" );
            AddButton( 295, dbpy + 3, sbtn, sbtn, 13, GumpButtonType.Reply, 1 );
            dbpy = dbpy + 20;
         }
         if (HasSpell(from, 714))
         {
            AddLabel( 315, dbpy, gth, "Voie du champignon" );
            AddButton( 295, dbpy + 3, sbtn, sbtn, 14, GumpButtonType.Reply, 1 );
            dbpy = dbpy + 20;
         }
         if (HasSpell(from, 715))
         {
            AddLabel( 315, dbpy, gth, "Engrais de vie" );
            AddButton( 295, dbpy + 3, sbtn, sbtn, 15, GumpButtonType.Reply, 1 );
            dbpy = dbpy + 20;
         }
         if (HasSpell(from, 701))
         {
            AddLabel( 315, dby, gth, "La Barriere nature" );
            AddButton( 295, dby + 3, sbtn, sbtn, 1, GumpButtonType.Reply, 1 );
            
         }
AddPage( 2 );

			AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 3 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 1 );




            if (HasSpell(from, 717))
         {
         	AddLabel( 145, 40, gth, "Sanctuaire" );
            AddButton( 125, 43, sbtn, sbtn, 20, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 718))
         {
         	AddLabel( 145, 60, gth, "Peau de Pierre" );
            AddButton( 125, 63, sbtn, sbtn, 21, GumpButtonType.Reply, 1 );
            
        
            }
            if (HasSpell(from, 719))
         {
            AddLabel( 145, 80, gth, "Colere du Ciel" );
            AddButton( 125, 83, sbtn, sbtn, 22, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 720))
         {
            AddLabel( 145, 100, gth, "Vitalite" );
            AddButton( 125, 103, sbtn, sbtn, 23, GumpButtonType.Reply, 1 );
            
         }
            if (HasSpell(from, 721))
         {
            AddLabel( 145, 120, gth, "Arbre Ancien" );
            AddButton( 125, 123, sbtn, sbtn, 24, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 722))
         {
            AddLabel( 145, 140, gth, "Force de Vie" );
            AddButton( 125, 143, sbtn, sbtn, 25, GumpButtonType.Reply, 1 );
             
         }
            if (HasSpell(from, 723))
         {
            AddLabel( 145, 160, gth, "Appel des Gardiens" );
            AddButton( 125, 163, sbtn, sbtn, 26, GumpButtonType.Reply, 1 );
             
         }

            if (HasSpell(from, 724))
         {
            AddLabel( 145, 180, gth, "Somnis" );
            AddButton( 125, 183, sbtn, sbtn, 27, GumpButtonType.Reply, 1 );
             
         }

            if (HasSpell(from, 725))
         {
            AddLabel( 315, 40, gth, "InSomnis" );
            AddButton( 295, 43, sbtn, sbtn, 28, GumpButtonType.Reply, 1 );
             
         }

            if (HasSpell(from, 726))
         {
         	AddLabel( 315, 60, gth, "Apparence Animal" );
            AddButton( 295, 63, sbtn, sbtn, 29, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 727))
         {
         	AddLabel( 315, 80, gth, "Aura de Protection" );
            AddButton( 295, 83, sbtn, sbtn, 30, GumpButtonType.Reply, 1 );
            
        
            }
            if (HasSpell(from, 728))
         {
            AddLabel( 315, 100, gth, "Creation Fruits" );
            AddButton( 295, 103, sbtn, sbtn, 31, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 729))
         {
            AddLabel( 315, 120, gth, "Famine" );
            AddButton( 295, 123, sbtn, sbtn, 32, GumpButtonType.Reply, 1 );
            
         }
            if (HasSpell(from, 730))
         {
            AddLabel( 315, 140, gth, "Fleurs" );
            AddButton( 295, 143, sbtn, sbtn, 33, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 731))
         {
            AddLabel( 315, 160, gth, "Marquer" );
            AddButton( 295, 163, sbtn, sbtn, 34, GumpButtonType.Reply, 1 );
             
         }
            if (HasSpell(from, 732))
         {
            AddLabel( 315, 180, gth, "Mur de Cactus" );
            AddButton( 295, 183, sbtn, sbtn, 35, GumpButtonType.Reply, 1 );
             
         }

AddPage( 3 );

			AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 4 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 2 );

            if (HasSpell(from, 733))
         {
         	AddLabel( 145, 40, gth, "Portance du Vent" );
            AddButton( 125, 43, sbtn, sbtn, 36, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 734))
         {
         	AddLabel( 145, 60, gth, "Reflux" );
            AddButton( 125, 63, sbtn, sbtn, 37, GumpButtonType.Reply, 1 );
            
        
         }
            if (HasSpell(from, 735))
         {
            AddLabel( 145, 80, gth, "Rejet Poison" );
            AddButton( 125, 83, sbtn, sbtn, 38, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 736))
         {
            AddLabel( 145, 100, gth, "Rejet Poison Masse" );
            AddButton( 125, 103, sbtn, sbtn, 39, GumpButtonType.Reply, 1 );
            
         }
            if (HasSpell(from, 737))
         {
            AddLabel( 145, 120, gth, "Revelation" );
            AddButton( 125, 123, sbtn, sbtn, 40, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 738))
         {
            AddLabel( 145, 140, gth, "Ronce Virulante" );
            AddButton( 125, 143, sbtn, sbtn, 41, GumpButtonType.Reply, 1 );
		 }
            if (HasSpell(from, 739))
         {
            AddLabel( 145, 160, gth, "Protection Naturelle" );
            AddButton( 125, 163, sbtn, sbtn, 42, GumpButtonType.Reply, 1 );
		 }
            if (HasSpell(from, 740))
         {
            AddLabel( 145, 180, gth, "Mur Paralysant" );
            AddButton( 125, 183, sbtn, sbtn, 43, GumpButtonType.Reply, 1 );
             
         }
            if (HasSpell(from, 741))
         {
            AddLabel( 315, 40, gth, "Vortex de Feu" );
            AddButton( 295, 43, sbtn, sbtn, 44, GumpButtonType.Reply, 1 );
             
         }

            if (HasSpell(from, 742))
         {
         	AddLabel( 315, 60, gth, "Vortex d'eau" );
            AddButton( 295, 63, sbtn, sbtn, 45, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 743))
         {
         	AddLabel( 315, 80, gth, "Vortex de terre" );
            AddButton( 295, 83, sbtn, sbtn, 46, GumpButtonType.Reply, 1 );
		 }
            if (HasSpell(from, 744))
         {
            AddLabel( 315, 100, gth, "Vortex d'air" );
            AddButton( 295, 103, sbtn, sbtn, 47, GumpButtonType.Reply, 1 );
		 }

            if (HasSpell(from, 745))
         {
         	AddLabel( 315, 120, gth, "Mass Abeilles" );
            AddButton( 295, 123, sbtn, sbtn, 48, GumpButtonType.Reply, 1 );
         }
            if (HasSpell(from, 746))
	   {
	      AddLabel( 315, 140, gth, "Boule d'energie" );
	      AddButton( 295, 143, sbtn, sbtn, 49, GumpButtonType.Reply, 1 );
   	}
       if (HasSpell(from, 749))
      {
         AddLabel( 315, 160, gth, "AntiMatra" );
         AddButton( 295, 163, sbtn, sbtn, 50, GumpButtonType.Reply, 1 );   
		 }
       if (HasSpell(from, 748))
      {
         AddLabel( 315, 180, gth, "AntiMatra Masse" );
         AddButton( 295, 183, sbtn, sbtn, 51, GumpButtonType.Reply, 1 );   
		 }
AddPage( 4 );		 
		AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 5 );
		AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 3 );

        if (HasSpell(from, 747))
      {
         AddLabel( 145, 40, gth, "AntiMatra Champ" );
         AddButton( 125, 43, sbtn, sbtn, 52, GumpButtonType.Reply, 1 );   
		 }		 

AddPage( 5 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 6 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 4 );			
			AddLabel( 150, 37, gth, "Lumiere volante" );
      		AddHtml( 130, 59, 123, 132, "Mere Nature vous donne la vision de nuit.", false, false );    	
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Destroying Angel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  1" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  5" );
      
AddPage(6 );
 		    AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 7);
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 5 );
      		AddLabel( 150, 37, gth, "Forces Terre" );
      		AddHtml( 130, 59, 123, 132, "Augmente a la fois la force et l'intelligence du druide.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Spring Water" );
			AddLabel( 295, 77, gth, "" );
			AddLabel( 295, 97, gth, "" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  20" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  10" );
			
AddPage( 7 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 8 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 6 );
			AddLabel( 150, 37, gth, "Invoquer la Meute" );
      		AddHtml( 130, 59, 123, 132, "Summone une meute de betes qui obeissent au druide . La puissnce augmente avec la skill.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "" );
			AddLabel( 295, 97, gth, "Petrified Wood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  20" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  20" );
			
AddPage( 8 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 9 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 7 );
			AddLabel( 150, 37, gth, "Printemps de vie" );
      		AddHtml( 130, 59, 123, 132, "Soin de masse.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Spring Water" );
			AddLabel( 295, 77, gth, "Spring Water" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  40" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  15" );

AddPage( 9 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 10 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 8 );
			AddLabel( 150, 37, gth, "Enchevetrement" );
      		AddHtml( 130, 59, 123, 132, "Invoque des racines qui enchevetrent la cible.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Spring Water" );
			AddLabel( 295, 97, gth, "" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  40" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  20" );

AddPage( 10 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 11 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 9 );
			AddLabel( 150, 37, gth, "Dissimulation" );
      		AddHtml( 130, 59, 123, 132, "tranforme le druide en arbre.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Spring Water" );
			AddLabel( 295, 77, gth, "" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  50" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  60" );

AddPage( 11 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 12 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 10 );
			AddLabel( 150, 37, gth, "Nuée d'abeilles" );
      		AddHtml( 130, 59, 123, 132, "Summone un essaim d'abeilles qui blessent la cible.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "" );
			AddLabel( 295, 97, gth, "Destroying Angel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  30" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  20" );
      	
AddPage( 12 );
			AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 13 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 11 );
			AddLabel( 150, 37, gth, "Colere du Volcan" );
      		AddHtml( 130, 59, 123, 132, "De lave surgie et blesse tout alentour", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Destroying Angel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  110" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  90" );
      	
AddPage( 13 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 14 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 12 );
			AddLabel( 150, 37, gth, "Etre Sylvain" );
      		AddHtml( 130, 59, 123, 132, "Summone un Etre Sylvain qui obeit au druide.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "" );
			AddLabel( 295, 97, gth, "Petrified Wood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  80" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  50" );

AddPage( 14 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 15 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 13 );
			AddLabel( 150, 37, gth, "Cercle de pierre" );
      		AddHtml( 130, 59, 123, 132, "Forme un infranchissable cercle de pierre, ideal pour coincer ses ennemis.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Ginseng" );
			AddLabel( 295, 77, gth, "BlackPearl" );
			AddLabel( 295, 97, gth, "Spring Water" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  60" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  45" );

AddPage( 15 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 16 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 14 );
			AddLabel( 150, 37, gth, "Son enchanté" );
      		AddHtml( 130, 59, 123, 132, "Cree un cercle d'arbres donnant regeneration de vie et de mana pour les bons karmas.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Petrified Wood" );
			AddLabel( 295, 97, gth, "Spring Water" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  95" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  60" );

AddPage( 16 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 17 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 15 );
      		AddLabel( 150, 37, gth, "Leure de pierre" );
      		AddHtml( 130, 59, 123, 132, "Cree une pierre magique qui attire les animaux vers elle.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Spring Water" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  15" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  30" );

AddPage( 17 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 18 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 16 );
			AddLabel( 150, 37, gth, "Voie de la nature" );
      		AddHtml( 130, 59, 123, 132, "Le recall des druides.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "" );
			AddLabel( 295, 97, gth, "Petrified Wood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  15" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  10" );

AddPage( 18 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 19 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 17 );
			AddLabel( 150, 37, gth, "Voie du champignon" );
      		AddHtml( 130, 59, 123, 132, "Portail druide.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Spring Water" );
			AddLabel( 295, 97, gth, "" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  60" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  30" );

AddPage( 19 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 20 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 18 );
			AddLabel( 150, 37, gth, "Engrais de vie" );
      		AddHtml( 130, 59, 123, 132, "Crée une flaque de resurection, le fantome doit marcher dessus.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "" );
			AddLabel( 295, 97, gth, "Spring Water" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  70" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  25" );

AddPage( 20 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 21 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 19 );
			AddLabel( 150, 37, gth, "Barriere de la nature" );
      		AddHtml( 130, 59, 123, 132, "Crée un mur de feuillages.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Spring Water" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  20" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  15" );

AddPage( 21 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 22 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 20 );
			AddLabel( 150, 37, gth, "Sanctuaire de la nature" );
      		AddHtml( 130, 59, 123, 132, "Vous Teleporte dans le sanctuaire des Druides.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "DestroyingAngel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  20" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  30" );

AddPage( 22 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 23 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 21 );
			AddLabel( 150, 37, gth, "Peau de Pierre" );
      		AddHtml( 130, 59, 123, 132, "Mere Nature donne a votre peaux la duretee de la pierre.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Spring Water" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  30" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  20" );

AddPage( 23 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 24 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 22 );
			AddLabel( 150, 37, gth, "Colere du Ciel" );
      		AddHtml( 130, 59, 123, 132, "Vous invoquez la colere du ciel.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "DestroyingAngel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  110" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  30" );

AddPage( 24 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 25 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 23 );
			AddLabel( 150, 37, gth, "Vitalite" );
      		AddHtml( 130, 59, 123, 132, "Mere Nature vous soigne.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "DestroyingAngel" );
			AddLabel( 295, 77, gth, "Spring Water" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  40" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  15" );

AddPage( 25 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 26 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 24 );
			AddLabel( 150, 37, gth, "Arbre Ancien" );
      		AddHtml( 130, 59, 123, 132, "Vous demandez a Mere Nature la force et la puissance.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "PetrafiedWood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  150" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  100" );

AddPage( 26 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 27 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 25 );
			AddLabel( 150, 37, gth, "Force de vie" );
      		AddHtml( 130, 59, 123, 132, "Benediction de Mere nature donnant plus de puissance a vos sorts.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "PetrafiedWood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  100" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  40" );

AddPage( 27 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 28 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 26 );
			AddLabel( 150, 37, gth, "Appel des Gardiens" );
      		AddHtml( 130, 59, 123, 132, "Vous invoquez 4 esprits Sylvain.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "PetrafiedWood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  140" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  90" );

AddPage( 28 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 29 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 27 );
			AddLabel( 150, 37, gth, "Somnis" );
      		AddHtml( 130, 59, 123, 132, "Vous plongez votre cible dans un profond sommeil.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Destroying Angel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  80" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  20" );

AddPage( 29 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 30 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 28 );
			AddLabel( 150, 37, gth, "InSomnis" );
      		AddHtml( 130, 59, 123, 132, "Vous ranimez ce qui est endormis.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Destroying Angel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  80" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  20" );

AddPage( 30 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 31 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 29 );
			AddLabel( 150, 37, gth, "Apparence Animale" );
      		AddHtml( 130, 59, 123, 132, "Vous prennez l'apparence d'un animal.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "SpringWater" );
			AddLabel( 295, 77, gth, "DestroyingAngel" );
			AddLabel( 295, 97, gth, "PetrafiedWood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  50" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  40" );


AddPage( 31 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 32 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 30 );
			AddLabel( 150, 37, gth, "Aura de Protection" );
      		AddHtml( 130, 59, 123, 132, "Vous devenez plus fort, rapide et intelligent.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Garlic" );
			AddLabel( 295, 97, gth, "Spring Water" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  25" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  10" );

AddPage( 32 );
      	 
			AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 33 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 31 );
			AddLabel( 150, 37, gth, "Apparition fruit" );
      		AddHtml( 130, 59, 123, 132, "Vous créer un fruit.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "SpringWater" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  20" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  10" );

AddPage( 33 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 34 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 32 );
			AddLabel( 150, 37, gth, "Famine" );
      		AddHtml( 130, 59, 123, 132, "Vous donnez faim a votre cible.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "SpringWater" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  50" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  10" );

AddPage( 34 );
      	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 35 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 33 );
			AddLabel( 150, 37, gth, "Fleurs" );
      	AddHtml( 130, 59, 123, 132, "Vous créer des fleurs.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Spring Water" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  25" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  10" );


AddPage( 35 );
			AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 36 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 34 );
			AddLabel( 150, 37, gth, "Marque" );
      	AddHtml( 130, 59, 123, 132, "Vous marquer une rune.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "SpringWater" );
			AddLabel( 295, 77, gth, "PetrafiedWood" );
			AddLabel( 295, 97, gth, "MandrakeRoot" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  60" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  20" );

AddPage( 36 );
      	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 37 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 35 );
			AddLabel( 150, 37, gth, "Mur de Cactus" );
      	AddHtml( 130, 59, 123, 132, "Invoque des cactus qui empoisonnent.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "PetrafiedWood" );
			AddLabel( 295, 97, gth, "DestroyingAngel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  50" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  20" );

AddPage( 37 );
      	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 38 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 36 );
			AddLabel( 150, 37, gth, "Portance Du Vent" );
      	AddHtml( 130, 59, 123, 132, "Le vent vous transporte a l'endroit ciblé.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Bloodmoss" );
			AddLabel( 295, 77, gth, "Petrafied Wood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  35" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  10" );

AddPage( 38 );
      	 
			AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 39 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 37 );
			AddLabel( 150, 37, gth, "Reflux" );
      	AddHtml( 130, 59, 123, 132, "Protection dirigee sur le physique", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Garlic" );
			AddLabel( 295, 77, gth, "SpringWater" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  25" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  10" );

AddPage( 39 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 40 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 38 );
			AddLabel( 150, 37, gth, "Rejet Poison" );
      		AddHtml( 130, 59, 123, 132, "Vous soigne des effets du poison.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Garlic" );
			AddLabel( 295, 77, gth, "SpringWater" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  25" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  15" );

AddPage( 40 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 41 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 39 );
			AddLabel( 150, 37, gth, "Rejet Poison Masse" );
      		AddHtml( 130, 59, 123, 132, "Soigne le druide et ses amis des effets du poison.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Garlic" );
			AddLabel( 295, 77, gth, "DestroyingAngel" );
			AddLabel( 295, 97, gth, "SpringWater" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  40" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  20" );


AddPage( 41 );
			AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 42 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 40 );
			AddLabel( 150, 37, gth, "Revelation" );
      		AddHtml( 130, 59, 123, 132, "Vous devoiler les personnes dans l'ombre à la lumière.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Destroying Angel" );
			AddLabel( 295, 77, gth, "Destroying Angel" );
			AddLabel( 295, 97, gth, "PetrafiedWood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  65" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  30" );

AddPage( 42 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 43 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 41 );
			AddLabel( 150, 37, gth, "Ronces Virulantes" );
      		AddHtml( 130, 59, 123, 132, "Vous empoisonner la cible.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Destroying Angel" );
			AddLabel( 295, 77, gth, "Nightshade" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  35" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  15" );

AddPage( 43 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 44 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 42 );
			AddLabel( 150, 37, gth, "Protection Naturelle" );
      		AddHtml( 130, 59, 123, 132, "Vous restez concentré pendant l'incantation de votre sort.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "PetrafiedWood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  40" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  15" );

AddPage( 44 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 45 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 43 );
			AddLabel( 150, 37, gth, "Mur Naturel Paralisant" );
      		AddHtml( 130, 59, 123, 132, "Vous invoquez un mur de racines paralisantes.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "PetrafiedWood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  40" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  15" );
			

AddPage( 45 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 46 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 44 );
			AddLabel( 150, 37, gth, "Vortex de feu" );
      		AddHtml( 130, 59, 123, 132, "Vous invoquez un Vortex de feu.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "SulfurousAsh" );
			AddLabel( 295, 97, gth, "SpiderSilk" );
			AddLabel( 295, 117, gth, "PetrafiedWood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  120" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  50" );

AddPage( 46 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 47 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 45 );
			AddLabel( 150, 37, gth, "Vortex d'eau" );
      		AddHtml( 130, 59, 123, 132, "Vous invoquez un Vortex d'eau.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "BloodMoss" );
			AddLabel( 295, 97, gth, "SpiderSilk" );
			AddLabel( 295, 117, gth, "SpringWater" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  120" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  50" );
			

AddPage( 47 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 48 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 46 );
			AddLabel( 150, 37, gth, "Vortex de terre" );
      		AddHtml( 130, 59, 123, 132, "Vous invoquez un Vortex de terre.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "MandrakeRoot" );
			AddLabel( 295, 97, gth, "SpiderSilk" );
			AddLabel( 295, 117, gth, "PetrafiedWood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  120" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  50" );

AddPage( 48 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 49 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 47 );
			AddLabel( 150, 37, gth, "Vortex d'air" );
      		AddHtml( 130, 59, 123, 132, "Vous invoquez un Vortex d'air.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "BlackPearl" );
			AddLabel( 295, 97, gth, "SpiderSilk" );
			AddLabel( 295, 117, gth, "PetrafiedWood" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  120" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  50" );

AddPage( 49 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 50 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 48 );
			AddLabel( 150, 37, gth, "Mass Abeilles" );
      		AddHtml( 130, 59, 123, 132, "Les abeille s'unissent pour vous defendre.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Bloodmoss" );
			AddLabel( 295, 97, gth, "DestroyingAngel" );
			AddLabel( 295, 117, gth, "MandrakeRoot" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  130" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  50" );

AddPage( 50 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 51 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 49 );
			AddLabel( 150, 37, gth, "Boule d'ennergie" );
      		AddHtml( 130, 59, 123, 132, "Mere nature vous prete son energie.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "Nightshade" );
			AddLabel( 295, 77, gth, "BlackPearl" );
			AddLabel( 295, 97, gth, "DestroyingAngel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  100" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  30" );
AddPage( 51 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 52 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 50 );
			AddLabel( 150, 37, gth, "AntiMatra" );
      		AddHtml( 130, 59, 123, 132, "Dissipe les spells.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Garlic" );
			AddLabel( 295, 97, gth, "DestroyingAngel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  50" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  30" );	
AddPage( 52 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 53 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 51 );
			AddLabel( 150, 37, gth, "AntiMatra de masse" );
      		AddHtml( 130, 59, 123, 132, "Dissipe les spells de masse.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "Garlic" );
			AddLabel( 295, 97, gth, "MandrakeRoot" );
			AddLabel( 295, 117, gth, "DestroyingAngel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  60" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  35" );	
AddPage( 53 );
      	 	AddButton( 396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, 54 );
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 52 );
			AddLabel( 150, 37, gth, "AntiMatra de champ" );
      		AddHtml( 130, 59, 123, 132, "Dissipe les spells de champ.", false, false );
			AddLabel( 295, 37, gth, "Reagents:" );
			AddLabel( 295, 57, gth, "" );
			AddLabel( 295, 77, gth, "BlackPearl" );
			AddLabel( 295, 97, gth, "SpidersSilk" );
			AddLabel( 295, 117, gth, "DestroyingAngel" );
			AddLabel( 295, 167, gth, "Niveau de Magie:  50" );
			AddLabel( 295, 187, gth, "Niveau de Mana:  30" );								

AddPage( 54 );
      	 
			AddButton( 123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, 53 );
			AddLabel( 295, 37, gth, "Fin du livre" );    
     
      }





      public override void OnResponse( NetState state, RelayInfo info )
      {
         Mobile from = state.Mobile;
         switch ( info.ButtonID )
         {
            case 0:
            {
               break;
            }
            case 1:
            {
               new ShieldOfEarthSpell( from, null ).Cast();
               break;
            }
            case 2:
            {
               new HollowReedSpell( from, null ).Cast();
               break;
            }
            case 3:
            {
               new PackOfBeastSpell( from, null ).Cast();
               break;
            }
            case 4:
            {
               new SpringOfLifeSpell( from, null ).Cast();
               break;
            }
            case 5:
            {
               new GraspingRootsSpell( from, null ).Cast();
               break;
            }
            case 6:
            {
               new BlendWithForestSpell( from, null ).Cast();
               break;
            }
            case 7:
            {
               new SwarmOfInsectsSpell( from, null ).Cast();
               break;
            }
            case 8:
            {
               new VolcanicEruptionSpell( from, null ).Cast();
               break;
            }
             case 9:
            {
               new TreefellowSpell( from, null ).Cast();
               break;
            }
            case 10:
            {
               new StoneCircleSpell( from, null ).Cast();
               break;
            }
            case 11:
            {
               new EnchantedGroveSpell( from, null ).Cast();
               break;
            }
            case 12:
            {
               new LureStoneSpell( from, null ).Cast();
               break;
            }
            case 13:
            {
              new NaturesPassageSpell( from, null ).Cast();
               break;
            }
            case 14:
            {
              new MushroomGatewaySpell( from, null ).Cast();
               break;
            }
            case 15:
            {
               new RestorativeSoilSpell( from, null ).Cast();
               break;
            }
            case 16:
            {
               new FireflySpell( from, null ).Cast();
               break;
            }
            case 17:
            {
              from.PlaySound(0x55);
              break;
            }
            case 18:
            {
				from.PlaySound(0x55);
				break;
            }
            case 19:
            {
				from.PlaySound(0x55);
				break;
            }
            case 20:
            {
				new NaturaliasSpell( from, null ).Cast();
				break;
            }
            case 21:
            {
               new Protspell( from, null ).Cast();
               break;
            }
            case 22:
            {
               new FoudreSpell( from, null ).Cast();
               break;
            }
            case 23:
            {
               new Viespell( from, null ).Cast();
               break;
            }
            case 24:
            {
               new Arbremorph( from, null ).Cast();
               break;
            }
            case 25:
            {
               new DruideFocusSpell( from, null ).Cast();
               break;
            }                                                                        
            case 26:
            {
               new Tree4Spell( from, null ).Cast();
               break;
            }
            case 27:
            {
               new Somnispell( from, null ).Cast();
               break;
            }
            case 28:
            {
               new Insomnispell( from, null ).Cast();
               break;
            }
            case 29:
            {
               new ApparenceAnimaleSpell( from, null ).Cast();
               break;
            }
            case 30:
            {
               new AuraProtectionSpell( from, null ).Cast();
               break;
            }
            case 31:
            {
               new CreationFruitSpell( from, null ).Cast();
               break;
            }
            case 32:
            {
               new DonnerFaimSpell( from, null ).Cast();
               break;
            }
            case 33:
            {
               new flowerOfEarthSpell( from, null ).Cast();
               break;
            }
            
            case 34:
            {
               new MarqueSpell( from, null ).Cast();
               break;
            }                                                                        
            case 35:
            {
               new MurCactusSpell( from, null ).Cast();
               break;
            }
            
            case 36:
            {
               new PortanceduVentSpell( from, null ).Cast();
               break;
            }
            case 37:
            {
               new RefluxSpell( from, null ).Cast();
               break;
            }
            case 38:
            {
               new RejetPoisonSpell( from, null ).Cast();
               break;
            }
            case 39:
            {
               new RejetPoisonMasseSpell( from, null ).Cast();
               break;
            }
            case 40:
            {
               new RevelationSpell( from, null ).Cast();
               break;
            }                                                                        
            case 41:
            {
               new RonceVirulanteSpell( from, null ).Cast();
               break;
            }
				case 42:
            {
               new NaturalProtectionSpell( from, null ).Cast();
               break;
            }
				case 43:
            {
               new NaturalParalyzeFieldSpell( from, null ).Cast();
               break;
            }
            case 44:
            {
               new firevortexSpell( from, null ).Cast();
               break;
            }                                                                        
            case 45:
            {
               new watervortexSpell( from, null ).Cast();
               break;
            }
				case 46:
            {
               new earthvortexSpell( from, null ).Cast();
               break;
            }
				case 47:
            {
               new airvortexSpell( from, null ).Cast();
               break;
            }
        		case 48:
            {
               new MassAbeillesSpell( from, null ).Cast();
               break;
            }
				case 49:
            {
               new VaguedenergieSpell( from, null ).Cast();
               break;
            }
				case 50:
            {
               new AntiMatraSpell( from, null ).Cast();
               break;
            }
				case 51:
            {
               new AntiMatraMassSpell( from, null ).Cast();
               break;
            }
				case 52:
            {
               new AntiMatraFieldSpell( from, null ).Cast();
               break;
            }                        
         }
      }
   }
}