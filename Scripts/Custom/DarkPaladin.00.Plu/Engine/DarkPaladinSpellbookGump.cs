using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Spells.DarkPaladin;
using Server.Prompts;

namespace Server.Gumps
{
   public class DarkPaladinSpellBookGump : Gump
   {
       private DarkPaladinSpellBook m_Book;

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


      public DarkPaladinSpellBookGump(Mobile from, DarkPaladinSpellBook book)
          : base(150, 200)
      {
      	
         m_Book = book;
         AddBackground();
AddPage( 1 );
      	 // AddLabel( 150, 17, gth, "Livre de la Nature" );
         
       	  AddHtml( 150, 22, 130, 20, "<BASEFONT COLOR=#BF0600>GRIMOIRE MAUDIT", false, false );        
         int sbtn = 0x846;//bouton
         //int dby = 40;
      	//int dbpy = 40;;
			AddButton( 395, 15, 0x89E, 0x89E, 11, GumpButtonType.Page, 2 );//pages
	
         if (HasSpell( from, 220) )
         {
         	AddLabel( 145, 50, gth, "Feu Salvateur" );
            AddButton( 130, 55, sbtn, sbtn, 1, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 221) )
         {
         	AddLabel( 145, 80, gth, "Soins Malfique" );
            AddButton( 130, 85, sbtn, sbtn, 2, GumpButtonType.Reply, 1 );
           
        
            }
         if (HasSpell( from, 222) )
         {
            AddLabel( 145, 110, gth, "Reflet de sang" );
            AddButton( 130, 115, sbtn, sbtn, 3, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 223) )
         {
            AddLabel( 145, 140, gth, "Repousser  le mal" );
            AddButton( 130, 145, sbtn, sbtn, 4, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 224) )
         {
            AddLabel( 145, 170, gth, "Fureur Sombre" );
            AddButton( 130, 175, sbtn, sbtn, 5, GumpButtonType.Reply, 1 );
            
         }

         if (HasSpell( from, 225) )
         {
            AddLabel( 305, 50, gth, "Choisir sa Proie" );
            AddButton( 290, 55, sbtn, sbtn, 6, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 226) )
         {
            AddLabel( 305, 80, gth, "Lumiere Maudite" );
            AddButton( 290, 85, sbtn, sbtn, 7, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 227) )
         {
            AddLabel( 305, 110, gth, "Don Malefique" );
            AddButton( 290, 115, sbtn, sbtn, 8, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 228) )
         {
         	AddLabel( 305, 140, gth, "Lever la Malediction" );
            AddButton( 290, 145, sbtn, sbtn, 9, GumpButtonType.Reply, 1 );
            
         }
         if (HasSpell( from, 229) )
         {
            AddLabel( 305, 170, gth, "Chemin Malfique" );
            AddButton( 290, 175, sbtn, sbtn, 10, GumpButtonType.Reply, 1 );
            
         }

AddPage( 2 );

			AddButton( 395, 15, 0x89E, 0x89E, 12, GumpButtonType.Page, 3 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 1 );
        	AddLabel( 285, 177, 0, "Points Sombres :" + from.TithingPoints.ToString());
AddPage( 3 );
      	 
			AddButton( 395, 15, 0x89E, 0x89E, 12, GumpButtonType.Page, 4 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 2 );
      	    AddLabel( 140, 37, gth, "Feu Salvateur" );
      		AddHtml( 130, 59, 123, 60, "Vous purifiez votre corp.", false, false );    	
			AddLabel( 130, 130, gth, "Points Sombres :10" );
			AddLabel( 130, 150, gth, "Niveau :45" );
			AddLabel( 130, 170, gth, "Mana :5" );

      	    AddLabel( 310, 37, gth, "Soins Malfique" );
      		AddHtml( 292, 59, 123, 60, "vous guerissez votre corp.", false, false );    	
			AddLabel( 292, 130, gth, "Points Sombres :10" );
			AddLabel( 292, 150, gth, "Niveau :20" );
			AddLabel( 293, 170, gth, "Mana :5" );
      
      	AddPage( 4 );
 		     AddButton( 396, 14, 0x89E, 0x89E, 12, GumpButtonType.Page, 5 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 3 );
      	    AddLabel( 140, 37, gth, "Reflet de sang" );
      		AddHtml( 130, 59, 123, 60, "Votre lame monte en puissance.", false, false );    	
			AddLabel( 130, 130, gth, "Points Sombres :10" );
			AddLabel( 130, 150, gth, "Niveau :40" );
			AddLabel( 130, 170, gth, "Mana :5" );

      	    AddLabel( 310, 37, gth, "Repousser  le mal" );
      		AddHtml( 292, 59, 123, 60, "Vous chassez les morts Vivants.", false, false );    	
			AddLabel( 292, 130, gth, "Points Sombres :100" );
			AddLabel( 292, 150, gth, "Niveau :80" );
			AddLabel( 293, 170, gth, "Mana :20" );

      AddPage( 5 );
      	 
			AddButton( 396, 14, 0x89E, 0x89E, 12, GumpButtonType.Page, 6 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 4 );
      	    AddLabel( 140, 37, gth, "Fureur Sombre" );
      		AddHtml( 130, 59, 123, 60, "une Fureur noire vous saisi.", false, false );    	
			AddLabel( 130, 130, gth, "Points Sombres :10" );
			AddLabel( 130, 150, gth, "Niveau :45" );
			AddLabel( 130, 170, gth, "Mana :5" );

      	    AddLabel( 310, 37, gth, "Choisir sa Proie" );
      		AddHtml( 292, 59, 123, 60, "Votre cible devient faible.", false, false );    	
			AddLabel( 292, 130, gth, "Points Sombres :10" );
			AddLabel( 292, 150, gth, "Niveau :60" );
			AddLabel( 293, 170, gth, "Mana :5" );

      	AddPage( 6 );
      	 
			AddButton( 396, 14, 0x89E, 0x89E, 12, GumpButtonType.Page, 7 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 5 );
      	    AddLabel( 140, 37, gth, "Lumiere Maudite" );
      		AddHtml( 130, 59, 123, 60, "Un eclat des tenebres blaisse vos adversaires.", false, false );    	
			AddLabel( 130, 130, gth, "Points Sombres :10" );
			AddLabel( 130, 150, gth, "Niveau :90" );
			AddLabel( 130, 170, gth, "Mana :5" );

      	    AddLabel( 310, 37, gth, "Don Malefique" );
      		AddHtml( 292, 59, 123, 60, "Votre Ame Malefique rend la vie.", false, false );    	
			AddLabel( 292, 130, gth, "Points Sombres :30" );
			AddLabel( 292, 150, gth, "Niveau :80" );
			AddLabel( 293, 170, gth, "Mana :20" );
 
 		AddPage( 7 );
      	 
			//AddButton( 396, 14, 0x89E, 0x89E, 12, GumpButtonType.Page, 8 );
			AddButton( 123, 15, 0x89D, 0x89D, 13, GumpButtonType.Page, 6 );
      	    AddLabel( 140, 37, gth, "Lever la Malediction" );
      		AddHtml( 130, 59, 123, 60, "vous chassez les miasmes.", false, false );    	
			AddLabel( 130, 130, gth, "Points Sombres :10" );
			AddLabel( 130, 150, gth, "Niveau :40" );
			AddLabel( 130, 170, gth, "Mana :5" );

      	    AddLabel( 310, 37, gth, "Chemin Malfique" );
      		AddHtml( 292, 59, 123, 60, "Vous vous teleportez.", false, false );    	
			AddLabel( 292, 130, gth, "Points Sombres :15" );
			AddLabel( 292, 150, gth, "Niveau :50" );
			AddLabel( 293, 170, gth, "Mana :10" );

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
               new DPCleanseByFireSpell( from, null ).Cast();
               break;
            }
            case 2:
            {
                new DPCloseWoundsSpell(from, null).Cast();
               break;
            }
            case 3:
            {
                new DPConsecrateWeaponSpell(from, null).Cast();
               break;
            }
            case 4:
            {
                new DPDispelEvilSpell(from, null).Cast();
               break;
            }
            case 5:
            {
                new DPDivineFurySpell(from, null).Cast();
               break;
            }
            case 6:
            {
                new DPEnemyOfOneSpell(from, null).Cast();
               break;
            }
            case 7:
            {
                new DPHolyLightSpell(from, null).Cast();
               break;
            }
            case 8:
            {
                new DPNobleSacrificeSpell(from, null).Cast();
               break;
            }
              case 9:
            {
                new DPRemoveCurseSpell(from, null).Cast();
               break;
            }
            case 10:
            {
                new DPSacredJourneySpell(from, null).Cast();
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

