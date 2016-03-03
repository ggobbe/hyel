using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Spells.Daemonic;
using Server.Prompts;

namespace Server.Gumps
{
   public class DaemonicSpellbookGump : Gump
   {
      private DaemonicSpellbook m_Book;

      int gth = 0x903;
      private void AddBackground()
      {
         AddPage( 0 );

         AddImage( 74, 7, 0x8ac, 0 );//gump livre
         //AddImage( 1, 1, 0x89B, 0 );//gump livre

      }

      public static bool HasSpell( Mobile from, int spellID )
      {
         Spellbook book = Spellbook.Find( from, spellID );
         return ( book != null && book.HasSpell( spellID ) );
      }


      public DaemonicSpellbookGump(Mobile from, DaemonicSpellbook book)
          : base(150, 200)
      {
      	
         m_Book = book;
         AddBackground();
AddPage( 1 );
      	 // AddLabel( 150, 17, gth, "Livre de la Nature" );
         
       	  AddHtml( 150, 22, 130, 20, "<BASEFONT COLOR=#BF0600>Cresh'ind'hor", false, false );        
         int sbtn = 0x9a9;//bouton
         //int dby = 40;
      	//int dbpy = 40;;
			AddButton( 395, 15, 0x89E, 0x89E, 11, GumpButtonType.Page, 2 );//pages
	
         if (HasSpell( from, 130) )
         {
         	AddLabel( 165, 55, gth, "Boule Poison" );
            AddButton( 130, 55, sbtn, sbtn, 1, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 131) )
         {
         	AddLabel( 165, 85, gth, "Proie" );
            AddButton( 130, 85, sbtn, sbtn, 2, GumpButtonType.Reply, 1 );
           
        
            }
         if (HasSpell( from, 132) )
         {
            AddLabel( 165, 115, gth, "Drainvie" );
            AddButton( 130, 115, sbtn, sbtn, 3, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 133) )
         {
            AddLabel( 165, 145, gth, "Vague de Flamme" );
            AddButton( 130, 145, sbtn, sbtn, 4, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 134) )
         {
            AddLabel( 165, 175, gth, "Carapace" );
            AddButton( 130, 175, sbtn, sbtn, 5, GumpButtonType.Reply, 1 );
            
         }

         if (HasSpell( from, 135) )
         {
            AddLabel( 325, 55, gth, "Arme Vampire" );
            AddButton( 290, 55, sbtn, sbtn, 6, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 136) )
         {
            AddLabel( 325, 85, gth, "Maleficio" );
            AddButton( 290, 85, sbtn, sbtn, 7, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 137) )
         {
            AddLabel( 325, 115, gth, "Nuees" );
            AddButton( 290, 115, sbtn, sbtn, 8, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 138) )
         {
         	AddLabel( 325, 145, gth, "HS" );
            AddButton( 290, 145, sbtn, sbtn, 9, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 139) )
         {
            AddLabel( 325, 175, gth, "HS" );
            AddButton( 290, 175, sbtn, sbtn, 10, GumpButtonType.Reply, 1 );
            
         }

AddPage( 2 );

			AddButton( 395, 15, 0x89E, 0x89E, 12, GumpButtonType.Page, 3 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 1 );
       	  AddHtml( 160, 22, 130, 20, "<BASEFONT COLOR=#BF0600>Raccourcis", false, false ); 
      	    AddLabel( 140, 40, gth, ".ThotHSharrrr" );
      	    AddLabel( 140, 60, gth, ".HasKarTee" );
      	    AddLabel( 140, 80, gth, ".HarrTsRhee" );
      	    AddLabel( 140, 100, gth, ".HorrrrsSheerr" );
      	    AddLabel( 140, 120, gth, ".HotNShass" );
      	    AddLabel( 140, 140, gth, ".VanishHorTes" );
      	    AddLabel( 140, 160, gth, ".GhorsTack" );
      	    AddLabel( 140, 180, gth, ".VossKarh" );


        	//AddLabel( 285, 177, 0, "Points Sombres :" + from.TithingPoints.ToString());
AddPage( 3 );
      	 
			AddButton( 395, 15, 0x89E, 0x89E, 12, GumpButtonType.Page, 4 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 2 );
      	    AddLabel( 140, 37, gth, "Boule de Poison" );
      		AddHtml( 130, 59, 140, 40, "Vous lancez une boule de Fluide Empoisonné", false, false );    	
			AddHtml( 130, 110, 140,40, "<BASEFONT COLOR=RED>Composants : <BASEFONT COLOR=Black> Onax Nox", false, false );
			AddHtml( 130, 160, 140, 20, "<BASEFONT COLOR=RED>Niveau : <BASEFONT COLOR=Black> 100", false, false );
			AddHtml( 130, 180, 140, 20, "<BASEFONT COLOR=RED>Mana : <BASEFONT COLOR=Black> 60", false, false );

      	    AddLabel( 310, 37, gth, "La Proie" );
      		AddHtml( 292, 59, 140, 40, "Les Morts Vivant attackent", false, false );    	
			AddHtml( 292, 110, 140,40, "<BASEFONT COLOR=RED>Composants : <BASEFONT COLOR=Black>Onax Batwing gravdust", false, false );
			AddHtml( 292, 160, 140, 20, "<BASEFONT COLOR=RED>Niveau : <BASEFONT COLOR=Black>110", false, false );
			AddHtml( 293, 180, 140, 20, "<BASEFONT COLOR=RED>Mana : <BASEFONT COLOR=Black>70", false, false );
      
      	AddPage( 4 );
 		     AddButton( 396, 14, 0x89E, 0x89E, 12, GumpButtonType.Page, 5 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 3 );
      	    AddLabel( 140, 37, gth, "Drain de Vie" );
      		AddHtml( 130, 59, 140, 40, "vous abosrbez la vie de vos victimes", false, false );    	
			AddHtml( 130, 110, 140,40, "<BASEFONT COLOR=RED>Composants : <BASEFONT COLOR=Black>Onax Gravdust Katyl", false, false );
			AddHtml( 130, 160, 140, 20, "<BASEFONT COLOR=RED>Niveau : <BASEFONT COLOR=Black>120", false, false );
			AddHtml( 130, 180, 140, 20, "<BASEFONT COLOR=RED>Mana : <BASEFONT COLOR=Black>40", false, false );

      	    AddLabel( 310, 37, gth, "Vague de Flamme" );
      		AddHtml( 292, 59, 140, 40, "Une Vague de flamme vous entoure", false, false );    	
			AddHtml( 292, 110, 140,40, "<BASEFONT COLOR=RED>Composants : <BASEFONT COLOR=Black>Katyl Onax", false, false );
			AddHtml( 292, 160, 140, 20, "<BASEFONT COLOR=RED>Niveau : <BASEFONT COLOR=Black>120", false, false );
			AddHtml( 293, 180, 140, 20, "<BASEFONT COLOR=RED>Mana : <BASEFONT COLOR=Black>70", false, false );

      AddPage( 5 );
      	 
			AddButton( 396, 14, 0x89E, 0x89E, 12, GumpButtonType.Page, 6 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 4 );
      	    AddLabel( 140, 37, gth, "Carapace" );
      		AddHtml( 130, 59, 140, 40, "Une carapace de glace blesse vos Agresseurs", false, false );    	
			AddHtml( 130, 110, 140,40, "<BASEFONT COLOR=RED>Composants : <BASEFONT COLOR=Black>Onax Batwing DaemonBlood", false, false );
			AddHtml( 130, 160, 140, 20, "<BASEFONT COLOR=RED>Niveau : <BASEFONT COLOR=Black>125", false, false );
			AddHtml( 130, 180, 140, 20, "<BASEFONT COLOR=RED>Mana : <BASEFONT COLOR=Black>50", false, false );

      	    AddLabel( 310, 37, gth, "Arme Vampire" );
      		AddHtml( 292, 59, 140, 50, "Votre Arme est possédée, elle risque d'exploser", false, false );    	
			AddHtml( 292, 110, 140,40, "<BASEFONT COLOR=RED>Composants : <BASEFONT COLOR=Black>Katyl Batwing Gravedust", false, false );
			AddHtml( 292, 160, 140, 20, "<BASEFONT COLOR=RED>Niveau : <BASEFONT COLOR=Black>130", false, false );
			AddHtml( 293, 180, 140, 20, "<BASEFONT COLOR=RED>Mana : <BASEFONT COLOR=Black>60", false, false );

      	AddPage( 6 );
      	 
			AddButton( 396, 14, 0x89E, 0x89E, 12, GumpButtonType.Page, 7 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 5 );
      	    AddLabel( 140, 37, gth, "Maleficio" );
      		AddHtml( 130, 59, 140, 40, "Una Malefice affaibli vos adversaires", false, false );    	
			AddHtml( 130, 110, 140,40, "<BASEFONT COLOR=RED>Composants : <BASEFONT COLOR=Black>Onax Batwing PigIron", false, false );
			AddHtml( 130, 160, 140, 20, "<BASEFONT COLOR=RED>Niveau : <BASEFONT COLOR=Black>135", false, false );
			AddHtml( 130, 180, 140, 20, "<BASEFONT COLOR=RED>Mana : <BASEFONT COLOR=Black>120", false, false );

      	    AddLabel( 310, 37, gth, "Nuees" );
      		AddHtml( 292, 59, 140, 40, "Vous lancer un gaz qui etouffe vos adversaires", false, false );    	
			AddHtml( 292, 110, 140,40, "<BASEFONT COLOR=RED>Composants : <BASEFONT COLOR=Black>NoxCrystal Batwing Katyl", false, false );
			AddHtml( 292, 160, 140, 20, "<BASEFONT COLOR=RED>Niveau : <BASEFONT COLOR=Black>145", false, false );
			AddHtml( 293, 180, 140, 20, "<BASEFONT COLOR=RED>Mana : <BASEFONT COLOR=Black>70", false, false );

 		AddPage( 7 );
      	 
			//AddButton( 396, 14, 0x89E, 0x89E, 12, GumpButtonType.Page, 8 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 6 );
      	    AddLabel( 140, 37, gth, "" );
      		AddHtml( 130, 59, 140, 40, "", false, false );    	
			AddHtml( 130, 110, 140,40, "<BASEFONT COLOR=RED>Composants : <BASEFONT COLOR=Black>", false, false );
			AddHtml( 130, 160, 140, 20, "<BASEFONT COLOR=RED>Niveau : <BASEFONT COLOR=Black>0", false, false );
			AddHtml( 130, 180, 140, 20, "<BASEFONT COLOR=RED>Mana : <BASEFONT COLOR=Black>0", false, false );

      	    AddLabel( 310, 37, gth, "" );
      		AddHtml( 292, 59, 140, 40, "", false, false );    	
			AddHtml( 292, 110, 140,40, "<BASEFONT COLOR=RED>Composants : <BASEFONT COLOR=Black>", false, false );
			AddHtml( 292, 160, 140, 20, "<BASEFONT COLOR=RED>Niveau : <BASEFONT COLOR=Black>0", false, false );
			AddHtml( 293, 180, 140, 20, "<BASEFONT COLOR=RED>Mana : <BASEFONT COLOR=Black>0", false, false );

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
               new DaemonicPoison( from, null ).Cast();
               break;
            }
            case 2:
            {
               new Proie( from, null ).Cast();
               break;
            }
            case 3:
            {
               new DrainVie( from, null ).Cast();
               break;
            }
            case 4:
            {
               new Feuzone( from, null ).Cast();
               break;
            }
            case 5:
            {
               new Carapace( from, null ).Cast();
               break;
            }
            case 6:
            {
               new LVampire( from, null ).Cast();
               break;
            }
            case 7:
            {
               new Maleficio( from, null ).Cast();
               break;
            }
            case 8:
            {
               new NueesD( from, null ).Cast();
               break;
            }
              case 9:
            {
              new Medusa( from, null ).Cast();
               break;
            }
            case 10:
            {
               new Draco( from, null ).Cast();
               break;
            }

            case 11:
            {
              from.PlaySound(0x55);
              break;
            }
                case 12:
            {
             from.PlaySound(0x55);
               break;
            }
                case 13:
            {
               from.PlaySound(0x55);
               break;
            }


         }  
   }
}
}

