/** Scriptiz@18/11/07 : permet de connaitre son statut de faim et de soif
 * 
 * .faim et .soif > affiche le gump d'informations quant à la faim et la soif du joueur (2 font pareil)
 **/
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
    public class HungryGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("Faim", AccessLevel.Player, new CommandEventHandler(Hungry_OnCommand));
            CommandSystem.Register("Soif", AccessLevel.Player, new CommandEventHandler(Hungry_OnCommand));
        }

        [Usage("Faim")]
        [Aliases("Soif")]
        [Description("Niveau de nutrition et d'hydration du joueur.")]
        private static void Hungry_OnCommand(CommandEventArgs e)
        {
            if (!e.Mobile.HasGump(typeof(Gumps.HungryGump)))
            {
                e.Mobile.SendGump(new HungryGump(e.Mobile));
            }
            else
            {
                e.Mobile.CloseGump(typeof(Gumps.HungryGump));
                e.Mobile.SendGump(new HungryGump(e.Mobile));
            }
        }

        private Mobile m_Owner;

        public HungryGump(Mobile owner)
            : base(150, 200)
        {
            m_Owner = owner;

            AddBackground(0, 0, 125, 60, 5054);

            //AddImage( 10, 10+44, 0x503C);
            AddLabel(10, 10, 0, "Faim :");
            AddLabel(60, 10, 0, (m_Owner.Hunger).ToString());
            AddLabel(80, 10, 0, "/ 20");

            //AddImageTiled( 10+60, 10 + 44, 50, 50, 0x1f99);
            AddLabel(10, 10 + 22, 0, "Soif :");
            AddLabel(60, 10 + 22, 0, (m_Owner.Thirst).ToString());
            AddLabel(80, 10 + 22, 0, "/ 20");
        }
    }
}
