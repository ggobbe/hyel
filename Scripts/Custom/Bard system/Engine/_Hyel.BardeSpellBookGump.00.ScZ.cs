/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Spells.Barde;
using Server.Prompts;

namespace Server.Gumps
{
    public class BardeSpellbookGump : Gump
    {
        private BardeSpellbook m_Book;

        int gth = 0x903;
        private void AddBackground()
        {
            AddPage(0);

            AddImage(100, 10, 0x89B, 0);
            //   AddImage( 255, 10, 0x8AD, 0x48B ); 



            // AddLabel( 140, 45, gth, "Ohm - Earth" ); 
            // AddLabel( 140, 60, gth, "Ess - Air" ); 
            // AddLabel( 140, 75, gth, "Crur - Fire" ); 
            // AddLabel( 140, 90, gth, "Sepa - Water" ); 
            // AddLabel( 140, 110, gth, "Kes - One" ); 
            // AddLabel( 140, 125, gth, "Sec - Whole" ); 
            // AddLabel( 140, 140, gth, "En  - Call" ); 
            // AddLabel( 140, 155, gth, "Vauk - Banish" ); 
            // AddLabel( 140, 170, gth, "Tia - Befoul" ); 
            // AddLabel( 140, 185, gth, "Ante - Cleanse" ); 

        }

        /*public static bool this.HasSpell( Mobile from, int spellID ) 
        {
           Spellbook book = Spellbook.Find( from, spellID ); 
           return ( book != null && book.this.HasSpell( spellID ) ); 
        } */

        public bool HasSpell(Mobile from, int spellID)
        {
            return (m_Book.HasSpell(spellID));
        }


        public BardeSpellbookGump(Mobile from, BardeSpellbook book)
            : base(150, 200)
        {

            m_Book = book;
            AddBackground();
            AddPage(1);
            AddLabel(150, 17, gth, "Livre de Barde");
            int sbtn = 0x93A;
            int dby = 40;
            int dbpy = 40; ;
            AddButton(396, 14, 0x89E, 0x89E, 17, GumpButtonType.Page, 2);

            if (this.HasSpell(from, 301))
            {
                AddLabel(145, dbpy, gth, "Affaiblissement");
                AddButton(125, dbpy + 3, sbtn, sbtn, 1, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 302))
            {
                AddLabel(145, dby, gth, "Aveuglement");
                AddButton(125, dby + 3, sbtn, sbtn, 2, GumpButtonType.Reply, 1);
                dby = dby + 20;

            }
            if (this.HasSpell(from, 303))
            {
                AddLabel(145, dby, gth, "Paralysie");
                AddButton(125, dby + 3, sbtn, sbtn, 3, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 304))
            {
                AddLabel(145, dby, gth, "Désarmer");
                AddButton(125, dby + 3, sbtn, sbtn, 4, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 305))
            {
                AddLabel(145, dby, gth, "Stridence ");
                AddButton(125, dby + 3, sbtn, sbtn, 5, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 306))
            {
                AddLabel(145, dby, gth, "Découragement");
                AddButton(125, dby + 3, sbtn, sbtn, 6, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 307))
            {
                AddLabel(145, dby, gth, "Rats");
                AddButton(125, dby + 3, sbtn, sbtn, 7, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 308))
            {
                AddLabel(145, dby, gth, "Drain");
                AddButton(125, dby + 3, sbtn, sbtn, 8, GumpButtonType.Reply, 1);
            }
            if (this.HasSpell(from, 309))
            {
                AddLabel(315, dbpy, gth, "Protection");
                AddButton(295, dbpy + 3, sbtn, sbtn, 9, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 310))
            {
                AddLabel(315, dbpy, gth, "Acuité");
                AddButton(295, dbpy + 3, sbtn, sbtn, 10, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 311))
            {
                AddLabel(315, dbpy, gth, "Discrétion");
                AddButton(295, dbpy + 3, sbtn, sbtn, 11, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 312))
            {
                AddLabel(315, dbpy, gth, "Carapace");
                AddButton(295, dbpy + 3, sbtn, sbtn, 12, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 313))
            {
                AddLabel(315, dbpy, gth, "Retour aux sources");
                AddButton(295, dbpy + 3, sbtn, sbtn, 13, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 314))
            {
                AddLabel(315, dbpy, gth, "Courage");
                AddButton(295, dbpy + 3, sbtn, sbtn, 14, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 315))
            {
                AddLabel(315, dbpy, gth, "Attraction");
                AddButton(295, dbpy + 3, sbtn, sbtn, 15, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 316))
            {
                AddLabel(315, dby, gth, "Apaisement");
                AddButton(295, dby + 3, sbtn, sbtn, 16, GumpButtonType.Reply, 1);

            }

            int i = 2;

            if (this.HasSpell(from, 301))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Affaiblissement ");
                AddHtml(130, 59, 123, 132, "Réduit la résistance physique de la cible pendant 30 secondes.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  30");
                AddLabel(295, 187, gth, "Coût en Mana:  10");
                i++;
            }

            if (this.HasSpell(from, 302))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Aveuglement");
                AddHtml(130, 59, 123, 132, "Aveugle la cible pour un certain temps.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                //AddLabel(295, 97, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  35");
                AddLabel(295, 187, gth, "Coût en Mana:  15");
                i++;
            }

            if (this.HasSpell(from, 303))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Paralysie");
                AddHtml(130, 59, 123, 132, "Summons a pack of beasts to fight for the Druid. Spell length increases with skill.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                //AddLabel(295, 97, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  60");
                AddLabel(295, 187, gth, "Coût en Mana:  20");
                i++;
            }
            if (this.HasSpell(from, 304))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Désarmer");
                AddHtml(130, 59, 123, 132, "Désarme la cible de toute arme.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  60");
                AddLabel(295, 187, gth, "Coût en Mana:  20");
                i++;
            }
            if (this.HasSpell(from, 305))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Stridence");
                AddHtml(130, 59, 123, 132, "Provoque des dégats progressifs dans un rayon autour du barde à chaque seconde.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                //AddLabel(295, 97, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  70");
                AddLabel(295, 187, gth, "Coût en Mana:  25");
                i++;
            }
            if (this.HasSpell(from, 306))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Découragement");
                AddHtml(130, 59, 123, 132, "Fatigue énormément la cible.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  75");
                AddLabel(295, 187, gth, "Coût en Mana:  30");
                i++;
            }
            if (this.HasSpell(from, 307))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Rats");
                AddHtml(130, 59, 123, 132, "Invoque des rats aux dents empoisonnées.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                //AddLabel(295, 97, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  120");
                AddLabel(295, 187, gth, "Coût en Mana:  40");
                i++;
            }
            if (this.HasSpell(from, 308))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Drain");
                AddHtml(130, 59, 123, 132, "Aspire la vie et la mana de la cible.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  115");
                AddLabel(295, 187, gth, "Coût en Mana:  50");
                i++;
            }
            if (this.HasSpell(from, 309))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Protection");
                AddHtml(130, 59, 123, 132, "Augmente temporairement vos résistances.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                //AddLabel(295, 97, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  35");
                AddLabel(295, 187, gth, "Coût en Mana:  15");
                i++;
            }
            if (this.HasSpell(from, 310))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Acuité");
                AddHtml(130, 59, 123, 132, "Permet de voir dans le noir.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                //AddLabel(295, 97, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  40");
                AddLabel(295, 187, gth, "Coût en Mana:  15");
                i++;
            }
            if (this.HasSpell(from, 311))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Discrétion");
                AddHtml(130, 59, 123, 132, "Cache le barde aux yeux de tous.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                //AddLabel(295, 97, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  60");
                AddLabel(295, 187, gth, "Coût en Mana:  20");
                i++;
            }
            if (this.HasSpell(from, 312))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Carapace");
                AddHtml(130, 59, 123, 132, "Crée un mur solide autour du barde.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  60");
                AddLabel(295, 187, gth, "Coût en Mana:  20");
                i++;
            }
            if (this.HasSpell(from, 313))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Retour aux sources");
                AddHtml(130, 59, 123, 132, "Emmènne le druide loin dans un endroit propice à son spectacle.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                //AddLabel(295, 97, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  70");
                AddLabel(295, 187, gth, "Coût en Mana:  30");
                i++;
            }
            if (this.HasSpell(from, 314))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Courage");
                AddHtml(130, 59, 123, 132, "Régénère la vie et la mana du barde plus rapidement.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                //AddLabel(295, 97, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  75");
                AddLabel(295, 187, gth, "Coût en Mana:  1");
                i++;
            }
            if (this.HasSpell(from, 315))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Attraction");
                AddHtml(130, 59, 123, 132, "Attire une personne pret de soi.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                //AddLabel(295, 97, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  115");
                AddLabel(295, 187, gth, "Coût en Mana:  40");
                i++;
            }
            if (this.HasSpell(from, 301))
            {
                AddPage(i);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Apaisement");
                AddHtml(130, 59, 123, 132, "Soulage la fatigue du barde plus rapidement.", false, false);
                AddLabel(295, 37, gth, "Instrument:");
                AddLabel(295, 57, gth, "A trouver");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Musicianship:  120");
                AddLabel(295, 187, gth, "Coût en Mana:  40");
                i++;
            }

            AddPage(i);
            AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0:
                    {
                        break;
                    }

                case 1:
                    {
                        new AffaiblissementSpell(from, null).Cast();
                        break;
                    }

                case 2:
                    {
                        new AveuglementSpell(from, null).Cast();
                        break;
                    }

                case 3:
                    {
                        new ParalysieSpell(from, null).Cast();
                        break;
                    }

                case 4:
                    {
                        new DesarmerSpell(from, null).Cast();
                        break;
                    }

                case 5:
                    {
                        new StridenceSpell(from, null).Cast();
                        break;
                    }

                case 6:
                    {
                        new DecouragementSpell(from, null).Cast();
                        break;
                    }

                case 7:
                    {
                        new RatsSpell(from, null).Cast();
                        break;
                    }

                case 8:
                    {
                        new DrainSpell(from, null).Cast();
                        break;
                    }

                case 9:
                    {
                        new ProtectionBSpell(from, null).Cast();
                        break;
                    }

                case 10:
                    {
                        new AcuiteSpell(from, null).Cast();
                        break;
                    }

                case 11:
                    {
                        new DiscretionSpell(from, null).Cast();
                        break;
                    }

                case 12:
                    {
                        new CarapaceSpell(from, null).Cast();
                        break;
                    }

                case 13:
                    {
                        new RetourSourcesSpell(from, null).Cast();
                        break;
                    }
                  
                case 14:
                    {
                        new CourageSpell(from, null).Cast();
                        break;
                    }
                   
                case 15:
                    {
                        new AttractionSpell(from, null).Cast();
                        break;
                    }
                    
                case 16:
                    {
                        new ApaisementSpell(from, null).Cast();
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
            }
        }
    }
}
