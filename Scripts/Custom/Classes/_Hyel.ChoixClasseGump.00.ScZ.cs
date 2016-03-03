using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Misc;


namespace Server.Gumps
{
	public class ChoixClasseGump : Gump
	{
		private PlayerMobile m_NewChar;

        public ChoixClasseGump(PlayerMobile newChar)
			: base( 70, 60 )
		{
			m_NewChar = newChar;

			Dragable = false;
			Resizable = false;
			Closable = false;

            int nbr_classes = 15;   // nombre de classes

			AddPage( 0 );
			AddBackground( 0, 0, 200, 40 + (nbr_classes * 30), 9200 );
            // titre
			AddHtml( 10, 10, 180, 20, "<BASEFONT COLOR=#FFFFFF><CENTER>Quelle est votre voie de vie :</CENTER></BASEFONT>", false, false );

            int pos_x = 40;     // position x des zones de textes

            for (int classe = 1; classe <= 15; classe++)
            {
                AddImageTiled(10, pos_x, 180, 20, 1416);
                AddAlphaRegion(10, pos_x, 180, 20);
                AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>" + (HyelClasse)classe + "</BASEFONT>", false, false);
                AddButton(162, pos_x, 4014, 4016, classe, GumpButtonType.Reply, 0);
                pos_x += 30;
            }

            // Scriptiz : la boucle for ci dessus fait tout ça :
            /*
            // Artisan Léger
            int rep = 0;
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Artisan Léger</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Artisan Lourd
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Artisan Lourd</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Guerrier Léger
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Guerrier Léger</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Guerrier Lourd
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Guerrier Lourd</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Soigneur
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Soigneur</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Druide
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Druide</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Barde
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Barde</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Necromancien
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Nécromancien</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Clerc
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Clerc</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Paladin
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Paladin</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Mage
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Mage</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Protecteur
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Protecteur</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Assassin
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Assassin</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Roublard
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Roublard</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            // Traqueur
            AddImageTiled(10, pos_x, 180, 20, 1416);
            AddAlphaRegion(10, pos_x, 180, 20);
            AddHtml(12, pos_x, 150, 20, "<BASEFONT COLOR=#FFFFFF>Traqueur</BASEFONT>", false, false);
            AddButton(162, pos_x, 4014, 4016, ++rep, GumpButtonType.Reply, 0);
            pos_x += 30;
            */
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			int bttn = info.ButtonID;

            m_NewChar.HyelClasse = (HyelClasse)bttn;

            m_NewChar.Frozen = false;
		}
	}
}