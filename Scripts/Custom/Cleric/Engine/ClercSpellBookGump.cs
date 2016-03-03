using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Spells.Cleric;
using Server.Prompts;
using Server.Gumps;
namespace Server.Gumps
{
   public class ClercSpellbookGump : Gump
   {
      private ClercSpellbook m_Book;

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


      public ClercSpellbookGump( Mobile from, ClercSpellbook book ) : base( 150, 200 )
      {
      	
         m_Book = book;
         AddBackground();
AddPage( 1 );
      	  AddLabel( 190, 17, gth, "Livre Saint" );


         int sbtn = 0x8B0;//0x93a
        // int dby = 40;
      	//int dbpy = 40;;
			AddButton( 456, 9, 0x1F6, 0x1F6, 17, GumpButtonType.Page, 2 );
	
         if (HasSpell( from, 801) )
         {
         	AddLabel( 165, 40, gth, "Divine Morph" );
            AddButton( 145, 43, sbtn, sbtn, 1, GumpButtonType.Reply, 1 );
           // dby = dby + 20;
         }
         if (HasSpell(from, 802))
         {
         	AddLabel( 165, 60, gth, "Bannir le Mal" );
            AddButton( 145, 63, sbtn, sbtn, 2, GumpButtonType.Reply, 1 );
           // dby = dby + 20;
        
            }
         if (HasSpell(from, 803))
         {
            AddLabel( 165, 80, gth, "Malediction" );
            AddButton( 145, 83, sbtn, sbtn, 3, GumpButtonType.Reply, 1 );
           // dby = dby + 20;
         }
         if (HasSpell(from, 804))
         {
            AddLabel( 165, 100, gth, "Divine Focus" );
            AddButton( 145, 103, sbtn, sbtn, 4, GumpButtonType.Reply, 1 );
           // dby = dby + 20;
         }
         if (HasSpell(from, 805))
         {
            AddLabel( 165, 120, gth, "Marteau Divin" );
            AddButton( 145, 123, sbtn, sbtn, 5, GumpButtonType.Reply, 1 );
           // dby = dby + 20;
         }
         if (HasSpell(from, 806))
         {
            AddLabel( 165, 140, gth, "Exorcisme" );
            AddButton( 145, 143, sbtn, sbtn, 6, GumpButtonType.Reply, 1 );
           // dby = dby + 20;
         }
         if (HasSpell(from, 807))
         {
            AddLabel( 165, 160, gth, "Resurection" );
            AddButton( 145, 163, sbtn, sbtn, 7, GumpButtonType.Reply, 1 );
            //dby = dby + 20;
         }
         if (HasSpell(from, 808))
         {
            AddLabel( 165, 180, gth, "Guerison Divine" );
            AddButton( 145, 183, sbtn, sbtn, 8, GumpButtonType.Reply, 1 );
            //dbpy = dbpy + 20;
         }
         if (HasSpell(from, 809))
         {
            AddLabel( 355, 40, gth, "Sacrifice" );
            AddButton( 335, 43, sbtn, sbtn, 9, GumpButtonType.Reply, 1 );
            //dbpy = dbpy + 20;
         }
         if (HasSpell(from, 810))
         {
            AddLabel( 355, 60, gth, "Foudre Divine" );
            AddButton( 335, 63, sbtn, sbtn, 10, GumpButtonType.Reply, 1 );
            //dbpy = dbpy + 20;
         }
         if (HasSpell(from, 811))
         {
            AddLabel( 355, 80, gth, "Soins Divins" );
            AddButton( 335, 83, sbtn, sbtn, 11, GumpButtonType.Reply, 1 );
           // dbpy = dbpy + 20;
         }
         if (HasSpell(from, 812))
         {
         	AddLabel( 355, 100, gth, "Halo de flamme" );
            AddButton( 335, 103, sbtn, sbtn, 12, GumpButtonType.Reply, 1 );
           // dbpy = dbpy + 20;
         }
         if (HasSpell(from, 813))
         {
            AddLabel( 355, 120, gth, "Luminos" );
            AddButton( 335, 123, sbtn, sbtn, 13, GumpButtonType.Reply, 1 );
           // dbpy = dbpy + 20;
         }
         if (HasSpell(from, 814))
         {
            AddLabel( 355, 140, gth, "Benediction" );
            AddButton( 335, 143, sbtn, sbtn, 14, GumpButtonType.Reply, 1 );
          //  dbpy = dbpy + 20;
         }
         if (HasSpell(from, 815))
         {
            AddLabel( 355, 160, gth, "Bouclier Divin" );
            AddButton( 335, 163, sbtn, sbtn, 15, GumpButtonType.Reply, 1 );
            //dbpy = dbpy + 20;
         }

         if (HasSpell(from, 816))
         {
            AddLabel( 355, 180, gth, "Sanctuaire" );
            AddButton( 335, 183, sbtn, sbtn, 16, GumpButtonType.Reply, 1 );
            //dbpy = dbpy + 20;            
         }
AddPage( 2 );

			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 3 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 1 );
        	AddLabel( 335, 187, 0, "Points de Foi : " + from.TithingPoints.ToString());



            if (HasSpell(from, 817))
         {
         	AddLabel( 165, 40, gth, "Immobilium" );
            AddButton( 145, 43, sbtn, sbtn, 20, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 818))
         {
         	AddLabel( 165, 60, gth, "Pavois Divin" );
            AddButton( 145, 63, sbtn, sbtn, 21, GumpButtonType.Reply, 1 );
            
        
            }
            if (HasSpell(from, 819))
         {
            AddLabel( 165, 80, gth, "Destrium" );
            AddButton( 145, 83, sbtn, sbtn, 22, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 820))
         {
            AddLabel( 165, 100, gth, "Robe Divine" );
            AddButton( 145, 103, sbtn, sbtn, 23, GumpButtonType.Reply, 1 );
            
         }
            if (HasSpell(from, 821))
         {
            AddLabel( 165, 120, gth, "Appelium" );
            AddButton( 145, 123, sbtn, sbtn, 24, GumpButtonType.Reply, 1 );
           
         }
            if (HasSpell(from, 822))
         {
            AddLabel( 165, 140, gth, "Appeliumis" );
            AddButton( 145, 143, sbtn, sbtn, 25, GumpButtonType.Reply, 1 );
             
         }
            if (HasSpell(from, 823))
         {
            AddLabel( 165, 160, gth, "Invitate" );
            AddButton( 145, 163, sbtn, sbtn, 26, GumpButtonType.Reply, 1 );
             
         }
            if (HasSpell(from, 824))
         {
            AddLabel( 165, 180, gth, "Todas Viventas" );
            AddButton( 145, 183, sbtn, sbtn, 27, GumpButtonType.Reply, 1 );
             
         }

            if (HasSpell(from, 825))
         {
            AddLabel( 355, 40, gth, "Pluie Divine" );
            AddButton( 335, 43, sbtn, sbtn, 28, GumpButtonType.Reply, 1 );
             
         }                         
AddPage( 3 );      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 4 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 2 );
      	 AddLabel( 170, 37, gth, "Divine Morph" );
//      		AddHtml( 130, 59, 123, 132, "Vous prenez la forme d un Ange et sentez vos forces Augmenter.", false, false );    	
      		AddHtml( 155, 59, 123, 132, "Vous prenez la forme d un Ange et sentez vos forces Augmenter.", false, false );    	


			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 1000" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  140" );
		      	AddLabel( 335, 187, gth, "Mana :  110" );
      
      	AddPage( 4 );
      			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 5 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 3 );
      		  AddLabel( 170, 37, gth, "Bannir le Mal" );
      		AddHtml( 155, 59, 123, 132, "Vous chassez les morts et les forces du Mal.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 100" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  90" );
		      	AddLabel( 335, 187, gth, "Mana :  40" );
      AddPage( 5 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 6 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 4 );
      	  AddLabel( 170, 37, gth, "Malediction" );
      		AddHtml( 155, 59, 123, 132, "Vous jeter une Malediction.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 15" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  65" );
		      	AddLabel( 335, 187, gth, "Mana :  15" );
      	AddPage( 6 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 7 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 5 );
      	 AddLabel( 170, 37, gth, "Divin Focus" );
      		AddHtml( 155, 59, 123, 132, "Vous communiez et sentez vos forces Augmenter, mais la fatigue est proche.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 200" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  100" );
		      	AddLabel( 335, 187, gth, "Mana :  90" );
      	AddPage( 7 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 8 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 6 );
      	 AddLabel( 170, 37, gth, "Marteau Divin" );
      		AddHtml( 155, 59, 123, 132, "Invoquez une Masse de guerre Divine.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 20" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  45" );
		      	AddLabel( 335, 187, gth, "Mana :  15" );
      	AddPage( 8 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 9 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 7 );
      	  AddLabel( 170, 37, gth, "Exorcisme" );
      		AddHtml( 155, 59, 123, 132, "Vous chassez le mal des corps.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 5" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  50" );
		      	AddLabel( 335, 187, gth, "Mana :  15" );
      	AddPage( 9 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 10 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 8 );
      	  AddLabel( 170, 37, gth, "Resurection" );
      		AddHtml( 155, 59, 123, 132, "Vous ressucitez le Mort.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 100" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  80" );
		      	AddLabel( 335, 187, gth, "Mana :  50" );
      	AddPage( 10 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 11 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 9 );
      AddLabel( 170, 37, gth, "Guerison Divine" );
      		AddHtml( 155, 59, 123, 132, "L etre beni recevra les soins divins a chaque instant", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 80" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  90" );
		      	AddLabel( 335, 187, gth, "Mana :  50" );
      	AddPage( 11 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 12 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 10 );
      	 AddLabel( 170, 37, gth, "Sacrifice" );
      		AddHtml( 155, 59, 123, 132, "Vous Absorbez une partie des blessures de vos compagnons.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 5" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  50" );
		      	AddLabel( 335, 187, gth, "Mana :  15" );
      	AddPage( 12 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 13 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 11 );
      	  AddLabel( 170, 37, gth, "Foudre Divine" );
      		AddHtml( 155, 59, 123, 132, "Vous appelez la Foudre Divine.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 500" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  120" );
		      	AddLabel( 335, 187, gth, "Mana :  100" );
      	AddPage( 13 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 14 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 12 );
      	 AddLabel( 170, 37, gth, "Soins Divins" );
      		AddHtml( 155, 59, 123, 132, "Vous donnez des soins par votre Foi.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 10" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  40" );
		      	AddLabel( 335, 187, gth, "Mana :  15" );
      	AddPage( 14 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 15 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 13 );
      		  AddLabel( 170, 37, gth, "Halo de flamme" );
      		AddHtml( 155, 59, 123, 132, "Un Halo de Flamme divine vous Protege.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 25" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  85" );
		      	AddLabel( 335, 187, gth, "Mana :  15" );
      	AddPage( 15 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 16 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 14 );
      	 AddLabel( 170, 37, gth, "Luminoos" );
      		AddHtml( 155, 59, 123, 132, "une Lumiere Divine vous eclaire.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 20" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  30" );
		      	AddLabel( 335, 187, gth, "Mana :  10" );
      	AddPage( 16 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 17 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 15 );
      	AddLabel( 170, 37, gth, "Benediction" );
      		AddHtml( 155, 59, 123, 132, "Vous benissez et fortifiez autrui.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 40" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  60" );
		      	AddLabel( 335, 187, gth, "Mana :  15" );
      	AddPage( 17 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 18 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 16 );
      	  AddLabel( 170, 37, gth, "Bouclier Divin" );
      		AddHtml( 155, 59, 123, 132, "Cree une aura de protection Divine autoure de vous.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 40" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  55" );
		      	AddLabel( 335, 187, gth, "Mana :  15" );
	AddPage( 18 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 19 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 17 );
			AddLabel( 170, 37, gth, "Sanctuaire" );
      		AddHtml( 155, 59, 123, 132, "Dissipe la magie au alentour.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 100" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  80" );
		      	AddLabel( 335, 187, gth, "Mana :  20" );
 
 	AddPage( 19 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 20 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 18 );
			AddLabel( 170, 37, gth, "Immobilium" );
      		AddHtml( 155, 59, 123, 132, "Immobilise votre adversaire.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 50" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  75" );
		      	AddLabel( 335, 187, gth, "Mana :  75" );
	AddPage( 20 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 21 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 19 );
			AddLabel( 170, 37, gth, "Pavois Divin" );
      		AddHtml( 155, 59, 123, 132, "Les Dieux vous armes d'un Pavois sacr.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 50" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  70" );
		      	AddLabel( 335, 187, gth, "Mana :  50" );

	AddPage( 21 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 22 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 20 );
			AddLabel( 170, 37, gth, "Destrium" );
      		AddHtml( 155, 59, 123, 132, "Les Dieux vous donnent un Cheval de guerre.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 500" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  100" );
		      	AddLabel( 335, 187, gth, "Mana :  80" );
		      	
	AddPage( 22 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 23 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 21 );
			AddLabel( 170, 37, gth, "Robe Divine" );
      		AddHtml( 155, 59, 123, 132, "Les Dieux vous donnent une robe de protection.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 50" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  65" );
		      	AddLabel( 335, 187, gth, "Mana :  50" );
		      	
	AddPage( 23 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 24 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 22 );
			AddLabel( 170, 37, gth, "Appelium" );
      		AddHtml( 155, 59, 123, 132, "Vous appelez un esprit guerrier ancien  votre aide.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : ?" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  ?" );
		      	AddLabel( 335, 187, gth, "Mana :  ?" );
		      	
	AddPage( 24 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 25 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 23 );
			AddLabel( 170, 37, gth, "Appeliumis" );
      		AddHtml( 155, 59, 123, 132, "Vous appelez 4 Esprits Sacrs  votre aide", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : ?" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  ?" );
		      	AddLabel( 335, 187, gth, "Mana :  ?" );		      			      			      			      			      	

	AddPage( 25 );
      	 
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 26 );
			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 24 );
			AddLabel( 170, 37, gth, "Invitate" );
      		AddHtml( 155, 59, 123, 132, "Vous transporte dans le sanctuaire des Clercs.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 80" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau : 10 " );
		      	AddLabel( 335, 187, gth, "Mana :  15" );

	AddPage( 26 );
      	 

			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 25 );
			AddButton( 456, 9, 0x1F6, 0x1F6, 18, GumpButtonType.Page, 27 );
			AddLabel( 170, 37, gth, "Todas Viventas" );
      		AddHtml( 155, 59, 123, 132, "Vous Rendez vie aux proches.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 200" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  80" );
		      	AddLabel( 335, 187, gth, "Mana :  110" );
	AddPage( 27 );
      	 

			AddButton( 100, 9, 0x1F5, 0x1F5, 19, GumpButtonType.Page, 26 );
			AddLabel( 170, 37, gth, "Pluie Divine" );
      		AddHtml( 155, 59, 123, 132, "Vous soignez vos proches.", false, false );
			AddLabel( 335, 37, gth, "Composants :" );
			AddLabel( 335, 107, gth, "Points de foi : 20" );
			AddLabel( 335, 127, gth, "Competence :" );
			AddLabel( 335, 147, gth, "Magie" );			
			AddLabel( 335, 167, gth, "Niveau :  70" );
		      	AddLabel( 335, 187, gth, "Mana :  40" );
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
               new AngelicFaithSpell( from, null ).Cast();
               break;
            }
            case 2:
            {
               new BanishEvilSpell( from, null ).Cast();
               break;
            }
            case 3:
            {
               new DampenSpiritSpell( from, null ).Cast();
               break;
            }
            case 4:
            {
               new DivineFocusSpell( from, null ).Cast();
               break;
            }
            case 5:
            {
               new HammerOfFaithSpell( from, null ).Cast();
               break;
            }
            case 6:
            {
               new PurgeSpell( from, null ).Cast();
               break;
            }
            case 7:
            {
               new ResurectionSpell( from, null ).Cast();
               break;
            }
            case 8:
            {
               new SacredBoonSpell( from, null ).Cast();
               break;
            }
              case 9:
            {
               new SacrificeSpell( from, null ).Cast();
               break;
            }
            case 10:
            {
               new SmiteSpell( from, null ).Cast();
               break;
            }
               case 11:
            {
               new TouchOfLifeSpell( from, null ).Cast();
               break;
            }
               case 12:
            {
               new TrialByFireSpell( from, null ).Cast();
               break;
            }
               case 13:
            {
              new LumiereSpell( from, null ).Cast();
               break;
            }
               case 14:
            {
              new BeneSpell( from, null ).Cast();
               break;
            }
               case 15:
            {
               new repSpell( from, null ).Cast();
               break;
            }
               case 16:
            {
               new SanctuaireSpell( from, null ).Cast();
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
               new ImmobileSpell( from, null ).Cast();
               break;
            }
            case 21:
            {
               new BouclierSpell( from, null ).Cast();
               break;
            }
            case 22:
            {
               new MontureSpell( from, null ).Cast();
               break;
            }
            case 23:
            {
               new RobeSpell( from, null ).Cast();
               break;
            }
            case 24:
            {
               new AppelSpell( from, null ).Cast();
               break;
            }
            case 25:
            {
               new AppelsSpell( from, null ).Cast();
               break;
            }                                                                        
            case 26:
            {
               new InviteSpell( from, null ).Cast();
               break;
            }
            case 27:
            {
               new ResutousSpell( from, null ).Cast();
               break;
            }
            case 28:
            {
               new MassoinSpell( from, null ).Cast();
               break;
            }

         }
      }
   }
}
