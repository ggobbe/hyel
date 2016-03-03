/** Scriptiz@18/11/07 : permet au joueur de faire des emotes
 * 
 * .emote > affiche un gump proposant au joueur d'effectuer différentes emotes 
 **/
using System;
using Server;
using Server.Gumps;
using Server.Commands;

namespace Server.Gumps
{
    public enum EmotePage
    {
        P1,
        P2,
        P3,
        P4,
    }

    public class EmoteGump : Gump
    {

        public static void Initialize()
        {
            CommandSystem.Register("Emote", AccessLevel.Player, new CommandEventHandler(Msg_OnCommand));
        }

        [Usage("Emote")]
        [Description("Emote List")]

        private static void Msg_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new EmoteGump(e.Mobile, EmotePage.P1));
        }

        private Mobile m_From;
        private EmotePage m_Page;

        private const int Blanco = 0xFFFFFF;
        private const int Azul = 0x8080FF;

        public void AddPageButton(int x, int y, int buttonID, string text, EmotePage page, params EmotePage[] subpage)
        {
            bool seleccionado = (m_Page == page);
            for (int i = 0; !seleccionado && i < subpage.Length; ++i)
                seleccionado = (m_Page == subpage[i]);
            AddButton(x, y - 1, seleccionado ? 4006 : 4005, 4007, buttonID, GumpButtonType.Reply, 0);
            AddHtml(x + 35, y, 200, 20, Color(text, seleccionado ? Azul : Blanco), false, false);
        }

        public void AddButtonLabeled(int x, int y, int buttonID, string text)
        {
            AddButton(x, y - 1, 4005, 4007, buttonID, GumpButtonType.Reply, 0);
            AddHtml(x + 35, y, 240, 20, Color(text, Blanco), false, false);
        }

        public int GetButtonID(int type, int index)
        {
            return 1 + (index * 15) + type;
        }

        public string Color(string text, int color)
        {
            return String.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text);
        }

        public EmoteGump(Mobile from, EmotePage page)
            : base(600, 50)
        {
            from.CloseGump(typeof(EmoteGump));
            m_From = from;
            m_Page = page;
            Closable = true;
            Dragable = true;


            AddPage(0);
            AddBackground(0, 65, 130, 360, 5054);
            AddAlphaRegion(10, 70, 110, 350);
            AddImageTiled(10, 70, 110, 20, 9354);
            AddLabel(13, 70, 200, "Liste des Emotes");
            AddImage(100, 0, 10410);
            AddImage(100, 305, 10412);
            AddImage(100, 150, 10411);

            switch (page)
            {

                case EmotePage.P1:
                    {
                        AddButtonLabeled(10, 90, GetButtonID(1, 1), "Ah!");
                        AddButtonLabeled(10, 115, GetButtonID(1, 2), "Ah ah!");
                        AddButtonLabeled(10, 140, GetButtonID(1, 3), "*applaudit*");
                        AddButtonLabeled(10, 165, GetButtonID(1, 4), "*se mouche*");
                        AddButtonLabeled(10, 190, GetButtonID(1, 5), "*s'incline*");
                        AddButtonLabeled(10, 215, GetButtonID(1, 6), "*tousse*");
                        AddButtonLabeled(10, 240, GetButtonID(1, 7), "*éructe*");
                        AddButtonLabeled(10, 265, GetButtonID(1, 8), "Hum hum..");
                        AddButtonLabeled(10, 290, GetButtonID(1, 9), "*toussote*");
                        AddButtonLabeled(10, 315, GetButtonID(1, 10), "*pleure*");
                        AddButtonLabeled(10, 340, GetButtonID(1, 11), "*feint*");
                        AddButtonLabeled(10, 365, GetButtonID(1, 12), "*loufe*");
                        AddButton(70, 380, 4502, 0504, GetButtonID(0, 2), GumpButtonType.Reply, 0);
                    }
                    break;

                case EmotePage.P2:
                    {
                        AddButtonLabeled(10, 90, GetButtonID(1, 13), "*impressionné*");
                        AddButtonLabeled(10, 115, GetButtonID(1, 14), "*rit*");
                        AddButtonLabeled(10, 140, GetButtonID(1, 15), "*grogne*");
                        AddButtonLabeled(10, 165, GetButtonID(1, 16), "*grommelle*");
                        AddButtonLabeled(10, 190, GetButtonID(1, 17), "Hey!");
                        AddButtonLabeled(10, 215, GetButtonID(1, 18), "*hic*");
                        AddButtonLabeled(10, 240, GetButtonID(1, 19), "Hu?!");
                        AddButtonLabeled(10, 265, GetButtonID(1, 20), "*embrasse*");
                        AddButtonLabeled(10, 290, GetButtonID(1, 21), "*rigole*");
                        AddButtonLabeled(10, 315, GetButtonID(1, 22), "Non!");
                        AddButtonLabeled(10, 340, GetButtonID(1, 23), "Oh!");
                        AddButtonLabeled(10, 365, GetButtonID(1, 24), "Oooh!");
                        AddButton(10, 380, 4506, 4508, GetButtonID(0, 1), GumpButtonType.Reply, 0);
                        AddButton(70, 380, 4502, 0504, GetButtonID(0, 3), GumpButtonType.Reply, 0);
                        break;
                    }

                case EmotePage.P3:
                    {
                        AddButtonLabeled(10, 90, GetButtonID(1, 25), "Oups!");
                        AddButtonLabeled(10, 115, GetButtonID(1, 26), "*vomit*");
                        AddButtonLabeled(10, 140, GetButtonID(1, 27), "*frappe*");
                        AddButtonLabeled(10, 165, GetButtonID(1, 28), "*hurle*");
                        AddButtonLabeled(10, 190, GetButtonID(1, 29), "shuut!");
                        AddButtonLabeled(10, 215, GetButtonID(1, 30), "*soupire*");
                        AddButtonLabeled(10, 240, GetButtonID(1, 31), "*cogne*");
                        AddButtonLabeled(10, 265, GetButtonID(1, 32), "*éternue*");
                        AddButtonLabeled(10, 290, GetButtonID(1, 33), "*renifle*");
                        AddButtonLabeled(10, 315, GetButtonID(1, 34), "*ronfle*");
                        AddButtonLabeled(10, 340, GetButtonID(1, 35), "*crache*");
                        AddButtonLabeled(10, 365, GetButtonID(1, 36), "*se soulage*");
                        AddButton(10, 380, 4506, 4508, GetButtonID(0, 2), GumpButtonType.Reply, 0);
                        AddButton(70, 380, 4502, 0504, GetButtonID(0, 4), GumpButtonType.Reply, 0);
                        break;
                    }

                case EmotePage.P4:
                    {
                        AddButtonLabeled(10, 90, GetButtonID(1, 37), "*s'impatiente*");
                        AddButtonLabeled(10, 115, GetButtonID(1, 38), "*siffle*");
                        AddButtonLabeled(10, 140, GetButtonID(1, 39), "Wouhou!");
                        AddButtonLabeled(10, 165, GetButtonID(1, 40), "*baille*");
                        AddButtonLabeled(10, 190, GetButtonID(1, 41), "Yeah!");
                        AddButtonLabeled(10, 215, GetButtonID(1, 42), "*crie*");
                        AddButton(10, 380, 4506, 4508, GetButtonID(0, 3), GumpButtonType.Reply, 0);
                        break;
                    }
            }
        }

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            int val = info.ButtonID - 1;

            if (val < 0)
                return;

            Mobile from = m_From;

            int type = val % 15;
            int index = val / 15;

            switch (type)
            {
                case 0:
                    {
                        EmotePage page;

                        switch (index)
                        {
                            case 1: page = EmotePage.P1; break;
                            case 2: page = EmotePage.P2; break;
                            case 3: page = EmotePage.P3; break;
                            case 4: page = EmotePage.P4; break;
                            default: return;
                        }

                        from.SendGump(new EmoteGump(from, page));
                        break;
                    }

                case 1:
                    {
                        switch (index)
                        {

                            case 1:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(778);
                                        from.Say("ah!");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1049);
                                        from.Say("ah!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 2:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(779);
                                        from.Say("ah ah!");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1050);
                                        from.Say("ah ah!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 3:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(780);
                                        from.Emote("*applaudit*");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1051);
                                        from.Emote("*applaudit*");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 4:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(781);
                                        from.Emote("*se mouche*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(34, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1052);
                                        from.Emote("*se mouche*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(34, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 5:
                                {
                                    from.Emote("*s'incline*");
                                    if (!from.Mounted)
                                    {
                                        from.Animate(32, 5, 1, true, false, 0);
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 6:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(786);
                                        from.Emote("*tousse*");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1057);
                                        from.Emote("*tousse*");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 7:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(782);
                                        from.Emote("*éructe*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(33, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1053);
                                        from.Emote("*éructe*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(33, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 8:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(784);
                                        from.Say("Hum hum..");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(33, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1055);
                                        from.Say("Hum hum..");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(33, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 9:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(785);
                                        from.Emote("*toussote*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(33, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1056);
                                        from.Emote("*toussote*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(33, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 10:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(787);
                                        from.Emote("*pleure*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(34, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1058);
                                        from.Emote("*pleure*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(34, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 11:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(791);
                                        from.Emote("*tombe au sol*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(22, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1063);
                                        from.Emote("*tombe au sol*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(22, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 12:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(792);
                                        from.Emote("*loufe*");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1064);
                                        from.Emote("*loufe*");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P1));
                                    break;
                                }

                            case 13:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(793);
                                        from.Emote("*semble impressionnée*");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1065);
                                        from.Emote("*semble impressionné*");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 14:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(794);
                                        from.Emote("*rit*");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1066);
                                        from.Emote("*rit*");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 15:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(795);
                                        from.Emote("*grogne*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(6, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1067);
                                        from.Emote("*grogne*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(6, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 16:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(796);
                                        from.Emote("*gromelle*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(6, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1068);
                                        from.Emote("*gromelle*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(6, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 17:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(797);
                                        from.Say("Hey!");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1069);
                                        from.Say("Hey!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 18:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(798);
                                        from.Say("Hic!");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1070);
                                        from.Say("Hic!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 19:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(799);
                                        from.Say("Hu?!*");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1071);
                                        from.Say("Hu?!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 20:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(800);
                                        from.Emote("*embrasse*");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1072);
                                        from.Emote("*embrasse*");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 21:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(801);
                                        from.Emote("*rigole*");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1073);
                                        from.Emote("*rigole*");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 22:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(802);
                                        from.Say("Non!");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1074);
                                        from.Say("Non!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 23:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(803);
                                        from.Say("Oh!");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1075);
                                        from.Say("Oh!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 24:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(811);
                                        from.Say("Oooh!");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1085);
                                        from.Say("Oooh!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P2));
                                    break;
                                }

                            case 25:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(812);
                                        from.Say("Oups!");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1086);
                                        from.Say("Oups!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }

                            case 26:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(813);
                                        from.Emote("*vomit*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(32, 5, 1, true, false, 0);
                                        }
                                    }
                                    if (!from.Female)
                                    {
                                        from.PlaySound(1087);
                                        from.Emote("*vomit*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(32, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }

                            case 27:
                                {
                                    from.PlaySound(315);
                                    from.Emote("*frappe*");
                                    if (!from.Mounted)
                                    {
                                        from.Animate(31, 5, 1, true, false, 0);
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }

                            case 28:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(814);
                                        from.Emote("*hurle*");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1088);
                                        from.Emote("*hurle*");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }


                            case 29:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(815);
                                        from.Say("Shuut!");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1089);
                                        from.Say("Shuut!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }

                            case 30:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(816);
                                        from.Emote("*soupire*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(6, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1090);
                                        from.Emote("*soupire*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(6, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }

                            case 31:
                                {
                                    from.PlaySound(948);
                                    from.Emote("*cogne*");
                                    if (!from.Mounted)
                                    {
                                        from.Animate(11, 5, 1, true, false, 0);
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }

                            case 32:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(817);
                                        from.Emote("*éternue*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(32, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1091);
                                        from.Emote("*éternue*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(32, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }

                            case 33:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(818);
                                        from.Emote("*renifle*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(34, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1092);
                                        from.Emote("*renifle*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(34, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }

                            case 34:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(819);
                                        from.Emote("*ronfle*");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1093);
                                        from.Emote("*ronfle*");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }

                            case 35:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(820);
                                        from.Emote("*crache*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(6, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1094);
                                        from.Emote("*crache*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(6, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }

                            case 36:
                                {
                                    from.PlaySound(792);
                                    from.Emote("*se soulage*");
                                    from.SendGump(new EmoteGump(from, EmotePage.P3));
                                    break;
                                }

                            case 37:
                                {
                                    from.PlaySound(874);
                                    from.Emote("*tappe du pied*");
                                    if (!from.Mounted)
                                    {
                                        from.Animate(38, 5, 1, true, false, 0);
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P4));
                                    break;
                                }

                            case 38:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(821);
                                        from.Emote("*siffle*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(5, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1095);
                                        from.Emote("*siffle*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(5, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P4));
                                    break;
                                }

                            case 39:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(783);
                                        from.Say("Wouhou!");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1054);
                                        from.Say("Wouhou!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P4));
                                    break;
                                }

                            case 40:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(822);
                                        from.Emote("*baille*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(17, 5, 1, true, false, 0);
                                        }
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1096);
                                        from.Emote("*baille*");
                                        if (!from.Mounted)
                                        {
                                            from.Animate(17, 5, 1, true, false, 0);
                                        }
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P4));
                                    break;
                                }

                            case 41:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(823);
                                        from.Say("Yeah!");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1097);
                                        from.Say("Yeah!");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P4));
                                    break;
                                }

                            case 42:
                                {
                                    if (from.Female)
                                    {
                                        from.PlaySound(824);
                                        from.Emote("*crie*");
                                    }
                                    else if (!from.Female)
                                    {
                                        from.PlaySound(1098);
                                        from.Emote("*crie*");
                                    }
                                    from.SendGump(new EmoteGump(from, EmotePage.P4));
                                    break;
                                }

                        }
                        break;
                    }
            }
        }
    }
}