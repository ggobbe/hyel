using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Spells.Magister;
using Server.Prompts;
using Server.Gumps;
namespace Server.Gumps
{
   public class MagisterSpellbookGump : Gump
   {
      private MagisterSpellbook m_Book;

      int gth = 0x903;
      private void AddBackground()
      {
         AddPage( 0 );

         AddImage( 100, 10, 0x1F4, 0 );//0x89b


      }

      public static bool HasSpell( Mobile from, int spellID )
      {
         Spellbook book = Spellbook.Find( from, spellID );
         return ( book != null && book.HasSpell( spellID ) );
      }


      public MagisterSpellbookGump( Mobile from, MagisterSpellbook book ) : base( 150, 200 )
      {
      	
         m_Book = book;
         AddBackground();
AddPage( 1 );
      	  //AddHtml( 170, 17, 130, 20, "<BASEFONT COLOR=BLACK>GRIMOIRE MAGIQUE", false, false );
      	  AddHtml( 171, 22, 130, 20, "<BASEFONT COLOR=#BF0600>GRIMOIRE MAGIQUE", false, false );

         int sbtn = 0x5e;//0x93a
         //int dby = 40;
      	//int dbpy = 40;;
			AddButton( 456, 9, 0x1F6, 0x1F6, 10, GumpButtonType.Page, 2 );
	
         if (HasSpell( from, 901) )
         {
         	AddLabel( 180, 55, gth, "Feu Follet" );
            AddButton( 145, 40, sbtn, sbtn, 1, GumpButtonType.Reply, 1 );
            //dby = dby + 30;
         }
         if (HasSpell( from, 902) )
         {
         	AddLabel( 180, 85, gth, "Pluie de Feu" );
            AddButton( 145, 70, sbtn, sbtn, 2, GumpButtonType.Reply, 1 );
            //dby = dby + 30;
        
            }
         if (HasSpell( from, 903) )
         {
            AddLabel( 180, 115, gth, "Foudre Celeste" );
            AddButton( 145, 100, sbtn, sbtn, 3, GumpButtonType.Reply, 1 );
            //dby = dby + 30;
         }
         if (HasSpell( from, 904) )
         {
            AddLabel( 180, 145, gth, "Eboulement" );
            AddButton( 145, 130, sbtn, sbtn, 4, GumpButtonType.Reply, 1 );
            //dby = dby + 30;
         }
         if (HasSpell( from, 905) )
         {
            AddLabel( 180, 175, gth, "Blizard" );
            AddButton( 145, 160, sbtn, sbtn, 5, GumpButtonType.Reply, 1 );
            //dby = dby + 30;
         }
         if (HasSpell( from, 906) )
         {
            AddLabel( 370, 55, gth, "La Comete" );
            AddButton( 335, 40, sbtn, sbtn, 6, GumpButtonType.Reply, 1 );
            //dby = dby + 20;
         }
         if (HasSpell( from, 910) )
         {
            AddLabel( 370, 85, gth, "Seisme");
            AddButton( 335, 70, sbtn, sbtn, 13, GumpButtonType.Reply, 1 );
            //dby = dby + 30;
         }
         if (HasSpell( from, 908) )
         {
            AddLabel( 370, 115, gth, "Poussieres d'Etoiles" );
            AddButton( 335, 100, sbtn, sbtn, 8, GumpButtonType.Reply, 1 );
            //dbpy = dbpy + 30;
         }
         if (HasSpell( from, 909) )
         {
            AddLabel( 370, 145, gth, "Apocalypse" );
            AddButton( 335, 130, sbtn, sbtn, 9, GumpButtonType.Reply, 1 );
            //dbpy = dbpy + 30;
         }

         if (HasSpell( from, 907) )
         {
            AddLabel( 370, 175, gth, "CloneMagus" );
            AddButton( 335, 160, sbtn, sbtn, 7, GumpButtonType.Reply, 1 );
            //dbpy = dbpy + 30;
         }                        
AddPage( 2 );      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 11, GumpButtonType.Page, 3 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 12, GumpButtonType.Page, 1 );
		 AddHtml( 170, 25, 130, 15, "<BASEFONT COLOR=#BF0600>Feu Follet", false, false );
      		AddHtml( 140, 55, 160, 50, "<BASEFONT COLOR=BLACK>Feu de cérémonie", false, false );    	
		AddHtml( 140, 110, 160, 40, "<BASEFONT COLOR=BLACK>Composants : <BASEFONT COLOR=GREEN>Mandrake", false, false );
		AddHtml( 140, 175, 160, 15, "<BASEFONT COLOR=BLACK>Niveau : <BASEFONT COLOR=RED>30", false, false );
	      	AddHtml( 140, 195, 160, 15, "<BASEFONT COLOR=BLACK>Mana : <BASEFONT COLOR=BLUE>5", false, false );

		 AddHtml( 360, 25, 130, 15, "<BASEFONT COLOR=#BF0600>Pluie de Feu", false, false );
      		AddHtml( 330, 55, 160, 50, "<BASEFONT COLOR=BLACK> des Boules de Feu Frappent votre ennemi", false, false );    	
		AddHtml( 330, 110, 160, 40, "<BASEFONT COLOR=BLACK>Composants : <BASEFONT COLOR=GREEN>Onax Mandrake", false, false );
		AddHtml( 330, 175, 160, 15, "<BASEFONT COLOR=BLACK>Niveau : <BASEFONT COLOR=RED>90", false, false );
	      	AddHtml( 330, 195, 160, 15, "<BASEFONT COLOR=BLACK>Mana : <BASEFONT COLOR=BLUE>50", false, false );


  
AddPage( 3 );      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 11, GumpButtonType.Page, 4 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 12, GumpButtonType.Page, 2 );
		 AddHtml( 170, 25, 130, 15, "<BASEFONT COLOR=#BF0600>Foudre Celeste", false, false );
      		AddHtml( 140, 55, 160, 50, "<BASEFONT COLOR=BLACK>La Foudre Frappe votre cible.", false, false );    	
		AddHtml( 140, 110, 160, 40, "<BASEFONT COLOR=BLACK>Composants : <BASEFONT COLOR=GREEN>Katyl Mandrake", false, false );
		AddHtml( 140, 175, 160, 15, "<BASEFONT COLOR=BLACK>Niveau : <BASEFONT COLOR=RED>110", false, false );
	      	AddHtml( 140, 195, 160, 15, "<BASEFONT COLOR=BLACK>Mana : <BASEFONT COLOR=BLUE>50", false, false );

		 AddHtml( 360, 25, 130, 15, "<BASEFONT COLOR=#BF0600>Eboulement", false, false );
      		AddHtml( 330, 55, 160, 50, "<BASEFONT COLOR=BLACK>une Avalanche de roches frappe votre cible.", false, false );    	
		AddHtml( 330, 110, 160, 40, "<BASEFONT COLOR=BLACK>Composants : <BASEFONT COLOR=GREEN>Garlic Onax", false, false );
		AddHtml( 330, 175, 160, 15, "<BASEFONT COLOR=BLACK>Niveau : <BASEFONT COLOR=RED>115", false, false );
	      	AddHtml( 330, 195, 160, 15, "<BASEFONT COLOR=BLACK>Mana : <BASEFONT COLOR=BLUE>50", false, false );
	      	
AddPage( 4 );      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 11, GumpButtonType.Page, 5 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 12, GumpButtonType.Page, 3 );
		 AddHtml( 170, 25, 130, 15, "<BASEFONT COLOR=#BF0600>Blizard", false, false );
      		AddHtml( 140, 55, 160, 50, "<BASEFONT COLOR=BLACK>Le froid frappe votre cible", false, false );    	
		AddHtml( 140, 110, 160, 40, "<BASEFONT COLOR=BLACK>Composants : <BASEFONT COLOR=GREEN>Garlic Katyl", false, false );
		AddHtml( 140, 175, 160, 15, "<BASEFONT COLOR=BLACK>Niveau : <BASEFONT COLOR=RED>120", false, false );
	      	AddHtml( 140, 195, 160, 15, "<BASEFONT COLOR=BLACK>Mana : <BASEFONT COLOR=BLUE>50", false, false );

		 AddHtml( 360, 25, 130, 15, "<BASEFONT COLOR=#BF0600>La Comete", false, false );
      		AddHtml( 330, 55, 160, 50, "<BASEFONT COLOR=BLACK>Une roche en Feu frappe votre cible", false, false );    	
		AddHtml( 330, 110, 160, 40, "<BASEFONT COLOR=BLACK>Composants : <BASEFONT COLOR=GREEN>Katyl Onax Mandrake", false, false );
		AddHtml( 330, 175, 160, 15, "<BASEFONT COLOR=BLACK>Niveau : <BASEFONT COLOR=RED>125", false, false );
	      	AddHtml( 330, 195, 160, 15, "<BASEFONT COLOR=BLACK>Mana : <BASEFONT COLOR=BLUE>70", false, false );	      	
	      	
	      	
AddPage( 5 );      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 11, GumpButtonType.Page, 6 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 12, GumpButtonType.Page, 4 );
		 AddHtml( 170, 25, 130, 15, "<BASEFONT COLOR=#BF0600>Seisme", false, false );
      		AddHtml( 140, 55, 160, 50, "<BASEFONT COLOR=BLACK>Un tremblement de terre frappe votre zone", false, false );    	
		AddHtml( 140, 110, 160, 40, "<BASEFONT COLOR=BLACK>Composants : <BASEFONT COLOR=GREEN>Katyl Onax", false, false );
		AddHtml( 140, 175, 160, 15, "<BASEFONT COLOR=BLACK>Niveau : <BASEFONT COLOR=RED>135", false, false );
	      	AddHtml( 140, 195, 160, 15, "<BASEFONT COLOR=BLACK>Mana : <BASEFONT COLOR=BLUE>70", false, false );

		 AddHtml( 355, 25, 130, 15, "<BASEFONT COLOR=#BF0600>Poussieres D'etoile", false, false );
      		AddHtml( 330, 55, 160, 50, "<BASEFONT COLOR=BLACK>descript.", false, false );    	
		AddHtml( 330, 110, 160, 40, "<BASEFONT COLOR=BLACK>Composants : <BASEFONT COLOR=GREEN>Souffre Onax Katyl Bloodmousse", false, false );
		AddHtml( 330, 175, 160, 15, "<BASEFONT COLOR=BLACK>Niveau : <BASEFONT COLOR=RED>140", false, false );
	      	AddHtml( 330, 195, 160, 15, "<BASEFONT COLOR=BLACK>Mana : <BASEFONT COLOR=BLUE>120", false, false );	      	
	      	
	      	
AddPage( 6 );      	 
			//AddButton( 456, 9, 0x1F6, 0x1F6, 11, GumpButtonType.Page, 3 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 12, GumpButtonType.Page, 5 );
		 AddHtml( 170, 25, 130, 15, "<BASEFONT COLOR=#BF0600>Apocalypse", false, false );
      		AddHtml( 140, 55, 160, 55, "<BASEFONT COLOR=BLACK>Les Meteors frappent La zone ou vous etes, vous perdez 0.02 de magery", false, false );    	
		AddHtml( 140, 110, 160, 40, "<BASEFONT COLOR=BLACK>Composants : <BASEFONT COLOR=GREEN>Bloodmousse Nightshade Katyl Onax", false, false );
		AddHtml( 140, 175, 160, 15, "<BASEFONT COLOR=BLACK>Niveau : <BASEFONT COLOR=RED>150", false, false );
	      	AddHtml( 140, 195, 160, 15, "<BASEFONT COLOR=BLACK>Mana : <BASEFONT COLOR=BLUE>125", false, false );

		 AddHtml( 360, 25, 130, 15, "<BASEFONT COLOR=#BF0600>CloneMagus", false, false );
      		AddHtml( 330, 55, 160, 50, "<BASEFONT COLOR=BLACK>Vous creez un clone", false, false );    	
		AddHtml( 330, 110, 160, 40, "<BASEFONT COLOR=BLACK>Composants : <BASEFONT COLOR=GREEN>Bloodmousse Katyl Onax", false, false );
		AddHtml( 330, 175, 160, 15, "<BASEFONT COLOR=BLACK>Niveau : <BASEFONT COLOR=RED>130", false, false );
	      	AddHtml( 330, 195, 160, 15, "<BASEFONT COLOR=BLACK>Mana : <BASEFONT COLOR=BLUE>80", false, false );	      	
	      	
	      	
	      	
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
               new feuf( from, null ).Cast();
               break;
            }
            case 2:
            {
               new FireRain( from, null ).Cast();
               break;
            }
            case 3:
            {
               new foudre( from, null ).Cast();
               break;
            }
            case 4:
            {
               new eboul( from, null ).Cast();
               break;
            }
            case 5:
            {
               new glace( from, null ).Cast();
               break;
            }
            case 6:
            {
               new Comete( from, null ).Cast();
               break;
            }
            case 7:
            {
               new clonesp( from, null ).Cast();
               break;
            }
            case 8:
            {
               new meteor( from, null ).Cast();
               break;
            }
              case 9:
            {
               new meteorz( from, null ).Cast();
               break;
            }
            case 10:
            {
              from.PlaySound(0x55);
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
               new seisme( from, null ).Cast();
               break;
            }

         }
      }
   }
}
