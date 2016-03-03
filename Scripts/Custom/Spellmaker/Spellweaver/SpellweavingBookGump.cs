/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Spells.Spellweaving;
using Server.Prompts;


namespace Server.Gumps
{
    public class SpellweavingBookGump : Gump
    {
        private SpellweavingBook m_Book;

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


        public SpellweavingBookGump(Mobile from, SpellweavingBook book)
            : base(150, 200)
        {

            m_Book = book;
            AddBackground();
            AddPage(1);
            AddLabel(150, 17, gth, "Livre d'Arcaniste");
            int sbtn = 0x93A;
            int dby = 40;
            int dbpy = 40; ;
            AddButton(396, 14, 0x89E, 0x89E, 17, GumpButtonType.Page, 2);

            if (this.HasSpell(from, 600))
            {
                AddLabel(145, dbpy, gth, "Arcane Circle");
                AddButton(125, dbpy + 3, sbtn, sbtn, 1, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 601))
            {
                AddLabel(145, dby, gth, "Gift Of Renewal");
                AddButton(125, dby + 3, sbtn, sbtn, 2, GumpButtonType.Reply, 1);
                dby = dby + 20;

            }
            if (this.HasSpell(from, 602))
            {
                AddLabel(145, dby, gth, "Immolating Weapon");
                AddButton(125, dby + 3, sbtn, sbtn, 3, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 603))
            {
                AddLabel(145, dby, gth, "Attune Weapon");
                AddButton(125, dby + 3, sbtn, sbtn, 4, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 604))
            {
                AddLabel(145, dby, gth, "Thunderstorm");
                AddButton(125, dby + 3, sbtn, sbtn, 5, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 605))
            {
                AddLabel(145, dby, gth, "Nature Fury");
                AddButton(125, dby + 3, sbtn, sbtn, 6, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 606))
            {
                AddLabel(145, dby, gth, "Summon Fey");
                AddButton(125, dby + 3, sbtn, sbtn, 7, GumpButtonType.Reply, 1);
                dby = dby + 20;
            }
            if (this.HasSpell(from, 607))
            {
                AddLabel(145, dby, gth, "Summon Fiend");
                AddButton(125, dby + 3, sbtn, sbtn, 8, GumpButtonType.Reply, 1);
            }
            if (this.HasSpell(from, 608))
            {
                AddLabel(315, dbpy, gth, "Reaper Form");
                AddButton(295, dbpy + 3, sbtn, sbtn, 9, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 609))
            {
                AddLabel(315, dbpy, gth, "Wildfire");
                AddButton(295, dbpy + 3, sbtn, sbtn, 10, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 610))
            {
                AddLabel(315, dbpy, gth, "Essence Of Wind");
                AddButton(295, dbpy + 3, sbtn, sbtn, 11, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 611))
            {
                AddLabel(315, dbpy, gth, "Dryad Allure");
                AddButton(295, dbpy + 3, sbtn, sbtn, 12, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 612))
            {
                AddLabel(315, dbpy, gth, "Ethereal Voyage");
                AddButton(295, dbpy + 3, sbtn, sbtn, 13, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 613))
            {
                AddLabel(315, dbpy, gth, "Word Of Death");
                AddButton(295, dbpy + 3, sbtn, sbtn, 14, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 614))
            {
                AddLabel(315, dbpy, gth, "Gift Of Life");
                AddButton(295, dbpy + 3, sbtn, sbtn, 15, GumpButtonType.Reply, 1);
                dbpy = dbpy + 20;
            }
            if (this.HasSpell(from, 615))
            {
                AddLabel(315, dby, gth, "Arcane Empowerment");
                AddButton(295, dby + 3, sbtn, sbtn, 16, GumpButtonType.Reply, 1);

            }

            int i = 2;

            if (this.HasSpell(from, 600))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Arcane Circle ");
                AddHtml(130, 59, 123, 132, "Crée une gemme de focus qui accroit les pouvois magiques", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "Pentagramme");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  0");
                AddLabel(295, 187, gth, "Coût en Mana:  24");
                i++;
            }

            if (this.HasSpell(from, 601))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Gift of Renewal");
                AddHtml(130, 59, 123, 132, "Accroît la regénération de vie et permet de soigner un poison", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  0");
                AddLabel(295, 187, gth, "Coût en Mana:  24");
                i++;
            }

            if (this.HasSpell(from, 602))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Désactivé");
                AddHtml(130, 59, 123, 132, "Désactivé", false, false);
                AddLabel(295, 37, gth, "Désactivé");
                AddLabel(295, 57, gth, "Désactivé");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Désactivé");
                AddLabel(295, 187, gth, "Désactivé");
                i++;
            }
            if (this.HasSpell(from, 603))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Attune Weapon");
                AddHtml(130, 59, 123, 132, "Réduit les dégats de l'ennemi sur vous", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  0");
                AddLabel(295, 187, gth, "Coût en Mana:  24");
                i++;
            }
            if (this.HasSpell(from, 604))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Thunderstorm");
                AddHtml(130, 59, 123, 132, "Frappe l'ennemi et réduit sa récupération après un sort", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  10");
                AddLabel(295, 187, gth, "Coût en Mana:  32");
                i++;
            }
            if (this.HasSpell(from, 605))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Nature's Fury");
                AddHtml(130, 59, 123, 132, "Invoque des insectes empoisonnés sur la cible", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  10");
                AddLabel(295, 187, gth, "Coût en Mana:  24");
                i++;
            }
            if (this.HasSpell(from, 606))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Summon Fey");
                AddHtml(130, 59, 123, 132, "Invoque des fées pour vous protéger", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  38");
                AddLabel(295, 187, gth, "Coût en Mana:  10");
                i++;
            }
            if (this.HasSpell(from, 607))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Summon Fiend");
                AddHtml(130, 59, 123, 132, "Invoque des créatures pour vous protéger", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  38");
                AddLabel(295, 187, gth, "Coût en Mana:  10");
                i++;
            }
            if (this.HasSpell(from, 608))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Reaper Form");
                AddHtml(130, 59, 123, 132, "Transforme l'arcaniste en reaper", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  24");
                AddLabel(295, 187, gth, "Coût en Mana:  34");
                i++;
            }
            if (this.HasSpell(from, 609))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Désactivé");
                AddHtml(130, 59, 123, 132, "Désactivé", false, false);
                AddLabel(295, 37, gth, "Désactivé");
                AddLabel(295, 57, gth, "Désactivé");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Désactivé");
                AddLabel(295, 187, gth, "Désactivé");
                i++;
            }
            if (this.HasSpell(from, 610))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Essence of Wind");
                AddHtml(130, 59, 123, 132, "Réduit la vitesse d'attaque de l'ennemi en lui infligeant des dégats", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  52");
                AddLabel(295, 187, gth, "Coût en Mana:  40");
                i++;
            }
            if (this.HasSpell(from, 611))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Désactivé");
                AddHtml(130, 59, 123, 132, "Désactivé", false, false);
                AddLabel(295, 37, gth, "Désactivé:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Désactivé");
                AddLabel(295, 187, gth, "Désactivé");
                i++;
            }
            if (this.HasSpell(from, 612))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Ethereal Voyage");
                AddHtml(130, 59, 123, 132, "Permet de se dérober à la vue des monstres", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  24");
                AddLabel(295, 187, gth, "Coût en Mana:  32");
                i++;
            }
            if (this.HasSpell(from, 613))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Word of Death");
                AddHtml(130, 59, 123, 132, "Achève un monstre au bord de la mort", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  80");
                AddLabel(295, 187, gth, "Coût en Mana:  50");
                i++;
            }
            if (this.HasSpell(from, 614))
            {
                AddPage(i);
                AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, i + 1);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Gift of Life");
                AddHtml(130, 59, 123, 132, "Permet de ressucité un animal ou le jeteur de sort en cas de décès", false, false);
                AddLabel(295, 37, gth, "Requis:");
                AddLabel(295, 57, gth, "");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Spellweaving:  38");
                AddLabel(295, 187, gth, "Coût en Mana:  70");
                i++;
            }
            if (this.HasSpell(from, 615))
            {
                AddPage(i);
                AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, i - 1);
                AddLabel(150, 37, gth, "Désactivé");
                AddHtml(130, 59, 123, 132, "Désactivé", false, false);
                AddLabel(295, 37, gth, "Désactivé");
                AddLabel(295, 57, gth, "Désactivé");
                //AddLabel(295, 77, gth, " ");
                AddLabel(295, 167, gth, "Désactivé");
                AddLabel(295, 187, gth, "Désactivé");
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
                        new ArcaneCircleSpell(from, null).Cast();
                        break;
                    }

                case 2:
                    {
                        new GiftOfRenewalSpell(from, null).Cast();
                        break;
                    }

                case 3:
                    {
                        new GiftOfRenewalSpell(from, null).Cast();
                        break;
                    }

                case 4:
                    {
                        new AttuneWeaponSpell(from, null).Cast();
                        break;
                    }

                case 5:
                    {
                        new ThunderstormSpell(from, null).Cast();
                        break;
                    }

                case 6:
                    {
                        new NatureFurySpell(from, null).Cast();
                        break;
                    }

                case 7:
                    {
                        new SummonFeySpell(from, null).Cast();
                        break;
                    }

                case 8:
                    {
                        new SummonFiendSpell(from, null).Cast();
                        break;
                    }

                case 9:
                    {
                        new ReaperFormSpell(from, null).Cast();
                        break;
                    }

                case 10:
                    {
                        new ReaperFormSpell(from, null).Cast();
                        break;
                    }

                case 11:
                    {
                        new EssenceOfWindSpell(from, null).Cast();
                        break;
                    }

                case 12:
                    {
                        new EssenceOfWindSpell(from, null).Cast();
                        break;
                    }

                case 13:
                    {
                        new EtherealVoyageSpell(from, null).Cast();
                        break;
                    }

                case 14:
                    {
                        new WordOfDeathSpell(from, null).Cast();
                        break;
                    }

                case 15:
                    {
                        new GiftOfLifeSpell(from, null).Cast();
                        break;
                    }

                case 16:
                    {
                        new GiftOfLifeSpell(from, null).Cast();
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
