/**
 * Scriptiz@19/11/07 : Scripts servant à faire parler les mobiles et les objets non freezer.
 * 
 * .say : pour faire parler un mobile
 * .itemsay : pour faire parler un objet
 **/

using System;
using Server;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;

namespace Server.Commands
{
    public class Say
    {
        public static void Initialize()
        {
            CommandSystem.Register("Say", AccessLevel.GameMaster, new CommandEventHandler(Say_OnCommand));
            CommandSystem.Register("ItemSay", AccessLevel.GameMaster, new CommandEventHandler(ItemSay_OnCommand));
        }

        [Usage("Say <texte>")]
        [Description("Force le mobile ciblé à dire le <texte>.")]
        public static void Say_OnCommand(CommandEventArgs e)
        {
            string toSay = e.ArgString.Trim();

            if (toSay.Length > 0)
                e.Mobile.Target = new SayTarget(toSay, false);
            else
                e.Mobile.SendMessage("Format: Say \"<texte>\"");
        }

        [Usage("ItemSay <texte>")]
        [Description("Force l'objet ciblé à dire le <texte>.")]
        public static void ItemSay_OnCommand(CommandEventArgs e)
        {
            string toSay = e.ArgString.Trim();

            if (toSay.Length > 0)
                e.Mobile.Target = new SayTarget(toSay, true);
            else
                e.Mobile.SendMessage("Format: Say \"<texte>\"");
        }

        private class SayTarget : Target
        {
            private string m_toSay;
            private bool targetItem;

            public SayTarget(string say, bool item)
                : base(-1, false, TargetFlags.None)
            {
                m_toSay = say;
                targetItem = item;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (!targetItem && targeted is Mobile)
                {
                    Mobile targ = (Mobile)targeted;

                    if (from != targ && from.AccessLevel > targ.AccessLevel)
                    {
                        CommandLogging.WriteLine(from, "{0} {1} force la parole sur {2}", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(targ));
                        targ.Say(m_toSay);
                    }
                }
                else if (targetItem && targeted is Item)
                {
                    Item targ = (Item)targeted;
                    targ.PublicOverheadMessage(MessageType.Regular, Utility.RandomDyedHue(), false, m_toSay);
                }
                else
                    from.SendMessage("Cible invalide");
            }
        }
    }
}