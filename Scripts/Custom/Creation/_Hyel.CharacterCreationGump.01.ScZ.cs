using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Misc;


namespace Server.Gumps
{
	public class HyelCharacterCreationGump : Gump
	{
		private PlayerMobile z_NewChar;

		public HyelCharacterCreationGump( PlayerMobile newChar )
			: base( 70, 60 )
		{
			z_NewChar = newChar;

            z_NewChar.Frozen = true;

			Dragable = false;
			Resizable = false;
			Closable = false;

			AddPage( 0 );
			AddBackground( 0, 0, 200, 190, 9200 );
            // titre
			AddHtml( 10, 10, 180, 20, "<BASEFONT COLOR=#FFFFFF><CENTER>Choississez votre race :</CENTER></BASEFONT>", false, false );
            // race humain
			AddImageTiled( 10, 40, 180, 20, 1416 );
			AddAlphaRegion( 10, 40, 180, 20 );
			AddHtml( 12, 40, 150, 20, "<BASEFONT COLOR=#FFFFFF>Humain</BASEFONT>", false, false );
			AddButton( 162, 40, 4014, 4016, 1, GumpButtonType.Reply, 0 );
            // race nain
			AddImageTiled( 10, 70, 180, 20, 1416 );
			AddAlphaRegion( 10, 70, 180, 20 );
			AddHtml( 12, 70, 150, 20, "<BASEFONT COLOR=#FFFFFF>Nain</BASEFONT>", false, false );
			AddButton( 162, 70, 4014, 4016, 2, GumpButtonType.Reply, 0 );
            // race elfe
            AddImageTiled(10, 100, 180, 20, 1416);
            AddAlphaRegion(10, 100, 180, 20);
            AddHtml(12, 100, 150, 20, "<BASEFONT COLOR=#FFFFFF>Elfe</BASEFONT>", false, false);
            AddButton(162, 100, 4014, 4016, 3, GumpButtonType.Reply, 0);
            // race elfe noir
            AddImageTiled(10, 130, 180, 20, 1416);
            AddAlphaRegion(10, 130, 180, 20);
            AddHtml(12, 130, 150, 20, "<BASEFONT COLOR=#FFFFFF>Elfe Noir</BASEFONT>", false, false);
            AddButton(162, 130, 4014, 4016, 4, GumpButtonType.Reply, 0);
            // race elfe noir
            AddImageTiled(10, 160, 180, 20, 1416);
            AddAlphaRegion(10, 160, 180, 20);
            AddHtml(12, 160, 150, 20, "<BASEFONT COLOR=#FFFFFF>Elfe de Glace</BASEFONT>", false, false);
            AddButton(162, 160, 4014, 4016, 5, GumpButtonType.Reply, 0);
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			int bttn = info.ButtonID;

			switch( bttn ) {
				case 1:
                    z_NewChar.HyelRace = HyelRace.Humain;
                    break;

				case 2:
                    z_NewChar.HyelRace = HyelRace.Nain;
                    break;

                case 3:
                    z_NewChar.HyelRace = HyelRace.Elfe;
                    break;

                case 4:
                    z_NewChar.HyelRace = HyelRace.ElfeNoir;
                    break;

                case 5:
                    z_NewChar.HyelRace = HyelRace.ElfeGlace;
                    break;

                default:
                    z_NewChar.HyelRace = HyelRace.None;
                    break;
			}

            z_NewChar.SendGump(new ChoixClasseGump(z_NewChar));
		}
	}
}