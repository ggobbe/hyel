/*
 * User: Eckmuhl
 * Date: 25/11/2007
 */

using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Mobiles;

namespace Server.Commands
{
	public class Hierarchie
	{
		public static void Initialize()
		{
			Register();
		}

		public static void Register()
		{
			CommandSystem.Register( "Hierarchie", AccessLevel.Counselor, new CommandEventHandler( Hierarchie_OnCommand ) );
		}

		private class HierarchieTarget : Target
		{
			public HierarchieTarget( ) : base( -1, true, TargetFlags.None )
			{
			}

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is PlayerMobile)
                    from.SendGump(new HierarchieGump(from, (PlayerMobile)o));
                else
                {
                    from.SendMessage("Cette commande ne s'applique que sur les joueurs!");
                }
            }
		}

		[Usage( "Hierarchie" )]/* Creation de la commande .hierarchie */
		[Description( "Ouvre le menu permettant d'éditer Druidisme, Foi, Noblesse et Assassinat" )]
		private static void Hierarchie_OnCommand( CommandEventArgs e )
		{
			e.Mobile.Target = new HierarchieTarget();
		}
	}
}

namespace Server.Gumps
{
    public class HierarchieGump : Gump
    {
        /*Toutes les variables du gump :*/
        public static readonly bool OldStyle = false;

        public static readonly int GumpOffsetX = 30;
        public static readonly int GumpOffsetY = 30;

        public static readonly int TextHue = 0;
        public static readonly int TextOffsetX = 2;

        public static readonly int OffsetGumpID = 0x0A40; // Pure black
        public static readonly int EntryGumpID = 0x0BBC; // Light offwhite, textured
        public static readonly int BackGumpID = 0x13BE; // Gray slate/stoney
        public static readonly int SetGumpID = OldStyle ? 0x0000 : 0x0E14; // Empty : Dark navy blue, textured

        public static readonly int SetWidth = 20;
        public static readonly int SetOffsetX = OldStyle ? 4 : 2, SetOffsetY = 2;
        public static readonly int SetButtonID1 = 0x15E1; // Arrow pointing right
        public static readonly int SetButtonID2 = 0x15E5; // " pressed

        public static readonly int EntryHeight = 20;
        private static readonly int EntryWidth = 160;
        public static readonly int BorderSize = 10;
        public static readonly int OffsetSize = 1;

        private static readonly int TotalWidth = OffsetSize + EntryWidth + OffsetSize + SetWidth + OffsetSize;
        private static readonly int TotalHeight = OffsetSize + (5 * (EntryHeight + OffsetSize));/* 5 car Hierarchie + 4 Nom de hierarchie*/

        private static readonly int BackWidth = BorderSize + TotalWidth + BorderSize;
        private static readonly int BackHeight = BorderSize + TotalHeight + BorderSize;

        private string TextHierarchie = "Hierarchie";
        private PlayerMobile m_Target;

        public HierarchieGump(Mobile from, Mobile target)
            : base(GumpOffsetX, GumpOffsetY)
        {
            int i;
            int ValeurHierarchie = 0;

            m_Target = (PlayerMobile)target;

            /*Description du gump, taille, bouton, texte...*/
            AddPage(0);

            AddBackground(0, 0, BackWidth, BackHeight, BackGumpID);
            AddImageTiled(BorderSize, BorderSize, TotalWidth - (OldStyle ? SetWidth + OffsetSize : 0), TotalHeight, OffsetGumpID);

            int x = 11; /*BorderSize + OffsetSize*/
            int y = 11; /* BorderSize + OffsetSize*/
            AddImageTiled(x, y, EntryWidth, EntryHeight, EntryGumpID);
            AddLabelCropped(x + TextOffsetX, y, EntryWidth - TextOffsetX, EntryHeight, TextHue, TextHierarchie);
            x += 161; /*EntryWidth + OffsetSize*/
            if (SetGumpID != 0)
                AddImageTiled(x, y, SetWidth, EntryHeight, SetGumpID);

            for (i = 1; i < 5; i++)
            {
                switch (i)
                {
                    case 1: TextHierarchie = "Foi";
                        ValeurHierarchie = m_Target.Foi;
                        break;
                    case 2: TextHierarchie = "Noblesse";
                        ValeurHierarchie = m_Target.Noblesse;
                        break;
                    case 3: TextHierarchie = "Assassinat";
                        ValeurHierarchie = m_Target.Assassinat;
                        break;
                    case 4: TextHierarchie = "Druidisme";
                        ValeurHierarchie = m_Target.Druidisme;
                        break;
                    default: TextHierarchie = "Error";
                        break;
                }
                x = 11; /*BorderSize + OffsetSize*/
                y += 21; /* EntryHeight + OffsetSize*/
                AddImageTiled(x, y, EntryWidth, EntryHeight, EntryGumpID);
                AddLabelCropped(x + TextOffsetX, y, EntryWidth - TextOffsetX, EntryHeight, TextHue, TextHierarchie);
                x += EntryWidth + OffsetSize;
                if (SetGumpID != 0)
                    AddImageTiled(x, y, SetWidth, EntryHeight, SetGumpID);

                AddButton(x + SetOffsetX, y + SetOffsetY, SetButtonID1, SetButtonID2, i, GumpButtonType.Reply, 0);

                y += 1;
                x -= OffsetSize;
                x -= 1;
                x -= 50;

                AddImageTiled(x, y, 50, EntryHeight - 2, OffsetGumpID);

                x += 1;
                y += 1;

                AddImageTiled(x, y, 48, EntryHeight - 4, EntryGumpID);

                AddTextEntry(x + TextOffsetX, y - 1, 48 - TextOffsetX, EntryHeight - 3, TextHue, i, ValeurHierarchie.ToString("F0"));

                y -= 2;
            }
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            /*Ce qui se passe quand on appui sur un bouton du gump :*/
            Mobile from = sender.Mobile;
            TextRelay text = info.GetTextEntry(info.ButtonID);
            int val;
            
            if (text != null)
            {

                try
                {
                    val = (int)Convert.ToDouble(text.Text);
                    if ((val >= 0) && (val <= 1000))
                    {
                        switch (info.ButtonID)
                        {
                            case 0: break;
                            case 1: m_Target.Foi = val; goto case 5;
                            case 2: m_Target.Noblesse = val; goto case 5;
                            case 3: m_Target.Assassinat = val; goto case 5;
                            case 4: m_Target.Druidisme = val; goto case 5;
                            case 5: from.SendGump(new HierarchieGump(from, (Mobile)m_Target)); break;
                            default: break;
                        }
                    }
                    else
                    {
                        from.SendMessage("Veuillez saisir des valeurs entre 0 et 1000 inclus !");
                    }
                }
                catch
                {
                    from.SendMessage("Mauvais format !!!"); /*virgules ou lettres*/
                }
            }
        }
    }
}