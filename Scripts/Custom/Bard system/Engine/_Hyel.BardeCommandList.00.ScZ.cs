using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Barde;


namespace Server.Commands
{
    public class CastBardeSpells
    {
        public static void Initialize()
        {
            CommandSystem.Prefix = ".";

            CommandSystem.Register("Affaiblissement", AccessLevel.Player, new CommandEventHandler(Affaiblissement_OnCommand));

            CommandSystem.Register("Aveuglement", AccessLevel.Player, new CommandEventHandler(Aveuglement_OnCommand));

            CommandSystem.Register("Paralysie", AccessLevel.Player, new CommandEventHandler(Paralysie_OnCommand));

            CommandSystem.Register("Desarmer", AccessLevel.Player, new CommandEventHandler(Desarmer_OnCommand));

            CommandSystem.Register("Stridence", AccessLevel.Player, new CommandEventHandler(Stridence_OnCommand));

            CommandSystem.Register("Decouragement", AccessLevel.Player, new CommandEventHandler(Decouragement_OnCommand));

            CommandSystem.Register("Rats", AccessLevel.Player, new CommandEventHandler(Rats_OnCommand));

            CommandSystem.Register("Drain", AccessLevel.Player, new CommandEventHandler(Drain_OnCommand));

            CommandSystem.Register("ProtectionB", AccessLevel.Player, new CommandEventHandler(ProtectionB_OnCommand));

            CommandSystem.Register("Acuite", AccessLevel.Player, new CommandEventHandler(Acuite_OnCommand));

            CommandSystem.Register("Discretion", AccessLevel.Player, new CommandEventHandler(Discretion_OnCommand));

            CommandSystem.Register("Carapace", AccessLevel.Player, new CommandEventHandler(Carapace_OnCommand));

            CommandSystem.Register("RetourSources", AccessLevel.Player, new CommandEventHandler(RetourSources_OnCommand));

            CommandSystem.Register("Courage", AccessLevel.Player, new CommandEventHandler(Courage_OnCommand));

            CommandSystem.Register("Attraction", AccessLevel.Player, new CommandEventHandler(Attraction_OnCommand));

            CommandSystem.Register("Apaisement", AccessLevel.Player, new CommandEventHandler(Apaisement_OnCommand));

        }

        public static void Register(string command, AccessLevel access, CommandEventHandler handler)
        {
            Server.Commands.CommandSystem.Register(command, access, handler);
        }

        public static bool HasSpell(Mobile from, int spellID)
        {
            Spellbook book = Spellbook.Find(from, spellID);

            return (book != null && book.HasSpell(spellID));
        }

        [Usage("Affaiblissement")]
        [Description("Caste le sort Affaiblissement.")]
        public static void Affaiblissement_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 301))
            {
                new AffaiblissementSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }
        [Usage("Aveuglement")]
        [Description("Caste le sort Aveuglement.")]
        public static void Aveuglement_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 302))
            {
                new AveuglementSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("Paralysie")]
        [Description("Caste le sort Paralysie.")]
        public static void Paralysie_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 303))
            {
                new ParalysieSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("Desarmer")]
        [Description("Caste le sort Desarmer.")]
        public static void Desarmer_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 304))
            {
                new DesarmerSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("Stridence")]
        [Description("Caste le sort Stridence.")]
        public static void Stridence_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 305))
            {
                new StridenceSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("Decouragement")]
        [Description("Caste le sort Decouragement.")]
        public static void Decouragement_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 306))
            {
                new DecouragementSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("Rats")]
        [Description("Caste le sort Rats.")]
        public static void Rats_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 307))
            {
                new RatsSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("Drain")]
        [Description("Caste le sort Drain.")]
        public static void Drain_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 308))
            {
                new DrainSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("ProtectionB")]
        [Description("Caste le sort ProtectionB.")]
        public static void ProtectionB_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 309))
            {
                new ProtectionBSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("Acuite")]
        [Description("Caste le sort Acuite.")]
        public static void Acuite_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 310))
            {
                new AcuiteSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("Discretion")]
        [Description("Caste le sort Discretion.")]
        public static void Discretion_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 311))
            {
                new DiscretionSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("Carapace")]
        [Description("Caste le sort Carapace.")]
        public static void Carapace_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 312))
            {
                new CarapaceSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("RetourSources")]
        [Description("Caste le sort RetourSources.")]
        public static void RetourSources_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 313))
            {
                new RetourSourcesSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("Courage")]
        [Description("Caste le sort Courage.")]
        public static void Courage_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 314))
            {
                new CourageSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }

        [Usage("Attraction")]
        [Description("Caste le sort Attraction.")]
        public static void Attraction_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 315))
            {
                new AttractionSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }
        [Usage("Apaisement")]
        [Description("Caste le sort Apaisement.")]
        public static void Apaisement_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!Multis.DesignContext.Check(e.Mobile))
                return; // They are customizing

            if (HasSpell(from, 316))
            {

                new ApaisementSpell(e.Mobile, null).Cast();
            }
            else
            {
                from.SendLocalizedMessage(500015); // You do not have that spell!
            }

        }
    }
}
