using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server.Misc
{
	public enum HyelClasse
	{
        None            = 0,
		ArtisanLeger    = 1,
		ArtisanLourd    = 2,
        GuerrierLeger   = 3,
        GuerrierLourd   = 4,
        Soigneur        = 5,
        Druide          = 6,
        Barde           = 7,
        Necromancien    = 8,
        Clerc           = 9,
        Paladin         = 10,
        Mage            = 11,
        Protecteur      = 12,
        Assassin        = 13,
        Roublard        = 14,
        Traqueur        = 15

	}
	
	class HyelClasseSystem
	{
        public static void ChangeClasse(PlayerMobile pm, HyelClasse newClasse)
		{
            switch (newClasse)
            {
                case HyelClasse.ArtisanLeger:
                    ArtisanLeger(pm);
                    break;

                case HyelClasse.ArtisanLourd:
                    ArtisanLourd(pm);
                    break;

                case HyelClasse.GuerrierLeger:
                    GuerrierLeger(pm);
                    break;

                case HyelClasse.GuerrierLourd:
                    GuerrierLourd(pm);
                    break;

                case HyelClasse.Soigneur:
                    Soigneur(pm);
                    break;

                case HyelClasse.Druide:
                    Druide(pm);
                    break;

                case HyelClasse.Barde:
                    Barde(pm);
                    break;

                case HyelClasse.Necromancien:
                    Necromancien(pm);
                    break;

                case HyelClasse.Clerc:
                    Clerc(pm);
                    break;

                case HyelClasse.Paladin:
                    Paladin(pm);
                    break;

                case HyelClasse.Mage:
                    Mage(pm);
                    break;

                case HyelClasse.Protecteur:
                    Protecteur(pm);
                    break;

                case HyelClasse.Assassin:
                    Assassin(pm);
                    break;

                case HyelClasse.Roublard:
                    Roublard(pm);
                    break;

                case HyelClasse.Traqueur:
                    Traqueur(pm);
                    break;
			}

            pm.SendMessage("Vous êtes maintenant un " + newClasse.ToString());
		}

        /**
         * Définition des classe et de leurs cap de skills
         */
        #region Cap skills de classes
        private static void ArtisanLeger(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 120;
            pm.Skills.Anatomy.Cap = 100;
            pm.Skills.AnimalLore.Cap = 100;
            pm.Skills.AnimalTaming.Cap = 100;
            pm.Skills.Archery.Cap = 80;
            pm.Skills.ArmsLore.Cap = 100;
            pm.Skills.Begging.Cap = 100;
            pm.Skills.Blacksmith.Cap = 110;
            pm.Skills.Bushido.Cap = 90;
            pm.Skills.Camping.Cap = 100;
            pm.Skills.Carpentry.Cap = 110;
            pm.Skills.Cartography.Cap = 120;
            pm.Skills.Chivalry.Cap = 90;
            pm.Skills.Cooking.Cap = 120;
            pm.Skills.DetectHidden.Cap = 100;
            pm.Skills.Discordance.Cap = 90;
            pm.Skills.EvalInt.Cap = 100;
            pm.Skills.Fencing.Cap = 100;
            pm.Skills.Fishing.Cap = 110;
            pm.Skills.Fletching.Cap = 110;
            pm.Skills.Focus.Cap = 100;
            pm.Skills.Forensics.Cap = 100;
            pm.Skills.Healing.Cap = 100;
            pm.Skills.Herding.Cap = 100;
            pm.Skills.Hiding.Cap = 100;
            pm.Skills.Inscribe.Cap = 120;
            pm.Skills.ItemID.Cap = 100;
            pm.Skills.Lockpicking.Cap = 110;
            pm.Skills.Lumberjacking.Cap = 110;
            pm.Skills.Macing.Cap = 80;
            pm.Skills.Magery.Cap = 90;
            pm.Skills.MagicResist.Cap = 100;
            pm.Skills.Meditation.Cap = 100;
            pm.Skills.Mining.Cap = 110;
            pm.Skills.Musicianship.Cap = 90;
            pm.Skills.Necromancy.Cap = 90;
            pm.Skills.Ninjitsu.Cap = 90;
            pm.Skills.Parry.Cap = 80;
            pm.Skills.Peacemaking.Cap = 90;
            pm.Skills.Poisoning.Cap = 110;
            pm.Skills.Provocation.Cap = 90;
            pm.Skills.RemoveTrap.Cap = 110;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 90;
            pm.Skills.SpiritSpeak.Cap = 100;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 100;
            pm.Skills.Swords.Cap = 80;
            pm.Skills.Tactics.Cap = 100;
            pm.Skills.Tailoring.Cap = 120;
            pm.Skills.TasteID.Cap = 100;
            pm.Skills.Tinkering.Cap = 110;
            pm.Skills.Tracking.Cap = 100;
            pm.Skills.Veterinary.Cap = 100;
            pm.Skills.Wrestling.Cap = 80;
        }

        private static void ArtisanLourd(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 110;
            pm.Skills.Anatomy.Cap = 100;
            pm.Skills.AnimalLore.Cap = 100;
            pm.Skills.AnimalTaming.Cap = 100;
            pm.Skills.Archery.Cap = 90;
            pm.Skills.ArmsLore.Cap = 110;
            pm.Skills.Begging.Cap = 100;
            pm.Skills.Blacksmith.Cap = 120;
            pm.Skills.Bushido.Cap = 90;
            pm.Skills.Camping.Cap = 100;
            pm.Skills.Carpentry.Cap = 120;
            pm.Skills.Cartography.Cap = 110;
            pm.Skills.Chivalry.Cap = 90;
            pm.Skills.Cooking.Cap = 110;
            pm.Skills.DetectHidden.Cap = 100;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 100;
            pm.Skills.Fencing.Cap = 90;
            pm.Skills.Fishing.Cap = 110;
            pm.Skills.Fletching.Cap = 120;
            pm.Skills.Focus.Cap = 100;
            pm.Skills.Forensics.Cap = 100;
            pm.Skills.Healing.Cap = 90;
            pm.Skills.Herding.Cap = 100;
            pm.Skills.Hiding.Cap = 100;
            pm.Skills.Inscribe.Cap = 110;
            pm.Skills.ItemID.Cap = 100;
            pm.Skills.Lockpicking.Cap = 110;
            pm.Skills.Lumberjacking.Cap = 110;
            pm.Skills.Macing.Cap = 90;
            pm.Skills.Magery.Cap = 80;
            pm.Skills.MagicResist.Cap = 100;
            pm.Skills.Meditation.Cap = 100;
            pm.Skills.Mining.Cap = 120;
            pm.Skills.Musicianship.Cap = 80;
            pm.Skills.Necromancy.Cap = 80;
            pm.Skills.Ninjitsu.Cap = 80;
            pm.Skills.Parry.Cap = 100;
            pm.Skills.Peacemaking.Cap = 90;
            pm.Skills.Poisoning.Cap = 100;
            pm.Skills.Provocation.Cap = 90;
            pm.Skills.RemoveTrap.Cap = 110;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 80;
            pm.Skills.SpiritSpeak.Cap = 100;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 100;
            pm.Skills.Swords.Cap = 90;
            pm.Skills.Tactics.Cap = 100;
            pm.Skills.Tailoring.Cap = 110;
            pm.Skills.TasteID.Cap = 100;
            pm.Skills.Tinkering.Cap = 120;
            pm.Skills.Tracking.Cap = 100;
            pm.Skills.Veterinary.Cap = 100;
            pm.Skills.Wrestling.Cap = 90;
        }

        private static void GuerrierLeger(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 90;
            pm.Skills.Anatomy.Cap = 120;
            pm.Skills.AnimalLore.Cap = 100;
            pm.Skills.AnimalTaming.Cap = 100;
            pm.Skills.Archery.Cap = 120;
            pm.Skills.ArmsLore.Cap = 100;
            pm.Skills.Begging.Cap = 100;
            pm.Skills.Blacksmith.Cap = 80;
            pm.Skills.Bushido.Cap = 100;
            pm.Skills.Camping.Cap = 100;
            pm.Skills.Carpentry.Cap = 80;
            pm.Skills.Cartography.Cap = 90;
            pm.Skills.Chivalry.Cap = 90;
            pm.Skills.Cooking.Cap = 90;
            pm.Skills.DetectHidden.Cap = 110;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 100;
            pm.Skills.Fencing.Cap = 120;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 80;
            pm.Skills.Focus.Cap = 110;
            pm.Skills.Forensics.Cap = 100;
            pm.Skills.Healing.Cap = 100;
            pm.Skills.Herding.Cap = 110;
            pm.Skills.Hiding.Cap = 100;
            pm.Skills.Inscribe.Cap = 90;
            pm.Skills.ItemID.Cap = 100;
            pm.Skills.Lockpicking.Cap = 100;
            pm.Skills.Lumberjacking.Cap = 90;
            pm.Skills.Macing.Cap = 110;
            pm.Skills.Magery.Cap = 90;
            pm.Skills.MagicResist.Cap = 110;
            pm.Skills.Meditation.Cap = 100;
            pm.Skills.Mining.Cap = 90;
            pm.Skills.Musicianship.Cap = 90;
            pm.Skills.Necromancy.Cap = 110;
            pm.Skills.Ninjitsu.Cap = 110;
            pm.Skills.Parry.Cap = 110;
            pm.Skills.Peacemaking.Cap = 100;
            pm.Skills.Poisoning.Cap = 100;
            pm.Skills.Provocation.Cap = 100;
            pm.Skills.RemoveTrap.Cap = 100;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 90;
            pm.Skills.SpiritSpeak.Cap = 100;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 100;
            pm.Skills.Swords.Cap = 110;
            pm.Skills.Tactics.Cap = 120;
            pm.Skills.Tailoring.Cap = 90;
            pm.Skills.TasteID.Cap = 100;
            pm.Skills.Tinkering.Cap = 80;
            pm.Skills.Tracking.Cap = 110;
            pm.Skills.Veterinary.Cap = 100;
            pm.Skills.Wrestling.Cap = 120;
        }

        private static void GuerrierLourd(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 80;
            pm.Skills.Anatomy.Cap = 120;
            pm.Skills.AnimalLore.Cap = 100;
            pm.Skills.AnimalTaming.Cap = 100;
            pm.Skills.Archery.Cap = 80;
            pm.Skills.ArmsLore.Cap = 110;
            pm.Skills.Begging.Cap = 110;
            pm.Skills.Blacksmith.Cap = 90;
            pm.Skills.Bushido.Cap = 110;
            pm.Skills.Camping.Cap = 100;
            pm.Skills.Carpentry.Cap = 90;
            pm.Skills.Cartography.Cap = 100;
            pm.Skills.Chivalry.Cap = 90;
            pm.Skills.Cooking.Cap = 90;
            pm.Skills.DetectHidden.Cap = 100;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 100;
            pm.Skills.Fencing.Cap = 110;
            pm.Skills.Fishing.Cap = 110;
            pm.Skills.Fletching.Cap = 90;
            pm.Skills.Focus.Cap = 110;
            pm.Skills.Forensics.Cap = 100;
            pm.Skills.Healing.Cap = 90;
            pm.Skills.Herding.Cap = 100;
            pm.Skills.Hiding.Cap = 90;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 100;
            pm.Skills.Lockpicking.Cap = 100;
            pm.Skills.Lumberjacking.Cap = 120;
            pm.Skills.Macing.Cap = 120;
            pm.Skills.Magery.Cap = 90;
            pm.Skills.MagicResist.Cap = 110;
            pm.Skills.Meditation.Cap = 100;
            pm.Skills.Mining.Cap = 100;
            pm.Skills.Musicianship.Cap = 80;
            pm.Skills.Necromancy.Cap = 100;
            pm.Skills.Ninjitsu.Cap = 100;
            pm.Skills.Parry.Cap = 110;
            pm.Skills.Peacemaking.Cap = 100;
            pm.Skills.Poisoning.Cap = 100;
            pm.Skills.Provocation.Cap = 110;
            pm.Skills.RemoveTrap.Cap = 100;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 90;
            pm.Skills.SpiritSpeak.Cap = 100;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 100;
            pm.Skills.Swords.Cap = 120;
            pm.Skills.Tactics.Cap = 120;
            pm.Skills.Tailoring.Cap = 80;
            pm.Skills.TasteID.Cap = 100;
            pm.Skills.Tinkering.Cap = 90;
            pm.Skills.Tracking.Cap = 100;
            pm.Skills.Veterinary.Cap = 100;
            pm.Skills.Wrestling.Cap = 110;
        }

        private static void Soigneur(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 110;
            pm.Skills.Anatomy.Cap = 120;
            pm.Skills.AnimalLore.Cap = 100;
            pm.Skills.AnimalTaming.Cap = 100;
            pm.Skills.Archery.Cap = 80;
            pm.Skills.ArmsLore.Cap = 100;
            pm.Skills.Begging.Cap = 100;
            pm.Skills.Blacksmith.Cap = 80;
            pm.Skills.Bushido.Cap = 90;
            pm.Skills.Camping.Cap = 110;
            pm.Skills.Carpentry.Cap = 90;
            pm.Skills.Cartography.Cap = 100;
            pm.Skills.Chivalry.Cap = 100;
            pm.Skills.Cooking.Cap = 110;
            pm.Skills.DetectHidden.Cap = 100;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 100;
            pm.Skills.Fencing.Cap = 90;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 80;
            pm.Skills.Focus.Cap = 100;
            pm.Skills.Forensics.Cap = 120;
            pm.Skills.Healing.Cap = 120;
            pm.Skills.Herding.Cap = 100;
            pm.Skills.Hiding.Cap = 100;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 110;
            pm.Skills.Lockpicking.Cap = 100;
            pm.Skills.Lumberjacking.Cap = 90;
            pm.Skills.Macing.Cap = 90;
            pm.Skills.Magery.Cap = 110;
            pm.Skills.MagicResist.Cap = 110;
            pm.Skills.Meditation.Cap = 110;
            pm.Skills.Mining.Cap = 100;
            pm.Skills.Musicianship.Cap = 100;
            pm.Skills.Necromancy.Cap = 80;
            pm.Skills.Ninjitsu.Cap = 90;
            pm.Skills.Parry.Cap = 90;
            pm.Skills.Peacemaking.Cap = 110;
            pm.Skills.Poisoning.Cap = 90;
            pm.Skills.Provocation.Cap = 100;
            pm.Skills.RemoveTrap.Cap = 110;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 120;
            pm.Skills.SpiritSpeak.Cap = 100;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 100;
            pm.Skills.Swords.Cap = 100;
            pm.Skills.Tactics.Cap = 100;
            pm.Skills.Tailoring.Cap = 100;
            pm.Skills.TasteID.Cap = 110;
            pm.Skills.Tinkering.Cap = 90;
            pm.Skills.Tracking.Cap = 100;
            pm.Skills.Veterinary.Cap = 120;
            pm.Skills.Wrestling.Cap = 90;
        }

        private static void Druide(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 110;
            pm.Skills.Anatomy.Cap = 100;
            pm.Skills.AnimalLore.Cap = 120;
            pm.Skills.AnimalTaming.Cap = 120;
            pm.Skills.Archery.Cap = 90;
            pm.Skills.ArmsLore.Cap = 100;
            pm.Skills.Begging.Cap = 100;
            pm.Skills.Blacksmith.Cap = 80;
            pm.Skills.Bushido.Cap = 80;
            pm.Skills.Camping.Cap = 100;
            pm.Skills.Carpentry.Cap = 90;
            pm.Skills.Cartography.Cap = 100;
            pm.Skills.Chivalry.Cap = 90;
            pm.Skills.Cooking.Cap = 100;
            pm.Skills.DetectHidden.Cap = 100;
            pm.Skills.Discordance.Cap = 110;
            pm.Skills.EvalInt.Cap = 110;
            pm.Skills.Fencing.Cap = 90;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 90;
            pm.Skills.Focus.Cap = 100;
            pm.Skills.Forensics.Cap = 100;
            pm.Skills.Healing.Cap = 110;
            pm.Skills.Herding.Cap = 120;
            pm.Skills.Hiding.Cap = 100;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 100;
            pm.Skills.Lockpicking.Cap = 100;
            pm.Skills.Lumberjacking.Cap = 90;
            pm.Skills.Macing.Cap = 90;
            pm.Skills.Magery.Cap = 110;
            pm.Skills.MagicResist.Cap = 110;
            pm.Skills.Meditation.Cap = 110;
            pm.Skills.Mining.Cap = 80;
            pm.Skills.Musicianship.Cap = 110;
            pm.Skills.Necromancy.Cap = 80;
            pm.Skills.Ninjitsu.Cap = 90;
            pm.Skills.Parry.Cap = 100;
            pm.Skills.Peacemaking.Cap = 110;
            pm.Skills.Poisoning.Cap = 100;
            pm.Skills.Provocation.Cap = 110;
            pm.Skills.RemoveTrap.Cap = 100;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 90;
            pm.Skills.SpiritSpeak.Cap = 120;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 100;
            pm.Skills.Swords.Cap = 90;
            pm.Skills.Tactics.Cap = 100;
            pm.Skills.Tailoring.Cap = 100;
            pm.Skills.TasteID.Cap = 100;
            pm.Skills.Tinkering.Cap = 100;
            pm.Skills.Tracking.Cap = 100;
            pm.Skills.Veterinary.Cap = 120;
            pm.Skills.Wrestling.Cap = 100;
        }

        private static void Barde(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 100;
            pm.Skills.Anatomy.Cap = 100;
            pm.Skills.AnimalLore.Cap = 110;
            pm.Skills.AnimalTaming.Cap = 110;
            pm.Skills.Archery.Cap = 100;
            pm.Skills.ArmsLore.Cap = 100;
            pm.Skills.Begging.Cap = 120;
            pm.Skills.Blacksmith.Cap = 80;
            pm.Skills.Bushido.Cap = 80;
            pm.Skills.Camping.Cap = 100;
            pm.Skills.Carpentry.Cap = 100;
            pm.Skills.Cartography.Cap = 100;
            pm.Skills.Chivalry.Cap = 100;
            pm.Skills.Cooking.Cap = 100;
            pm.Skills.DetectHidden.Cap = 100;
            pm.Skills.Discordance.Cap = 120;
            pm.Skills.EvalInt.Cap = 110;
            pm.Skills.Fencing.Cap = 100;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 90;
            pm.Skills.Focus.Cap = 100;
            pm.Skills.Forensics.Cap = 100;
            pm.Skills.Healing.Cap = 100;
            pm.Skills.Herding.Cap = 110;
            pm.Skills.Hiding.Cap = 110;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 100;
            pm.Skills.Lockpicking.Cap = 100;
            pm.Skills.Lumberjacking.Cap = 100;
            pm.Skills.Macing.Cap = 90;
            pm.Skills.Magery.Cap = 90;
            pm.Skills.MagicResist.Cap = 110;
            pm.Skills.Meditation.Cap = 110;
            pm.Skills.Mining.Cap = 90;
            pm.Skills.Musicianship.Cap = 120;
            pm.Skills.Necromancy.Cap = 80;
            pm.Skills.Ninjitsu.Cap = 90;
            pm.Skills.Parry.Cap = 90;
            pm.Skills.Peacemaking.Cap = 120;
            pm.Skills.Poisoning.Cap = 100;
            pm.Skills.Provocation.Cap = 120;
            pm.Skills.RemoveTrap.Cap = 100;
            pm.Skills.Snooping.Cap = 110;
            pm.Skills.Spellweaving.Cap = 90;
            pm.Skills.SpiritSpeak.Cap = 100;
            pm.Skills.Stealing.Cap = 110;
            pm.Skills.Stealth.Cap = 110;
            pm.Skills.Swords.Cap = 80;
            pm.Skills.Tactics.Cap = 90;
            pm.Skills.Tailoring.Cap = 100;
            pm.Skills.TasteID.Cap = 100;
            pm.Skills.Tinkering.Cap = 90;
            pm.Skills.Tracking.Cap = 100;
            pm.Skills.Veterinary.Cap = 100;
            pm.Skills.Wrestling.Cap = 90;
        }

        // Scriptiz : vérifier par rapport au tableau à partir d'ici
        private static void Necromancien(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 110;
            pm.Skills.Anatomy.Cap = 110;
            pm.Skills.AnimalLore.Cap = 110;
            pm.Skills.AnimalTaming.Cap = 90;
            pm.Skills.Archery.Cap = 100;
            pm.Skills.ArmsLore.Cap = 100;
            pm.Skills.Begging.Cap = 100;
            pm.Skills.Blacksmith.Cap = 90;
            pm.Skills.Bushido.Cap = 80;
            pm.Skills.Camping.Cap = 100;
            pm.Skills.Carpentry.Cap = 90;
            pm.Skills.Cartography.Cap = 100;
            pm.Skills.Chivalry.Cap = 100;
            pm.Skills.Cooking.Cap = 100;
            pm.Skills.DetectHidden.Cap = 100;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 110;
            pm.Skills.Fencing.Cap = 110;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 90;
            pm.Skills.Focus.Cap = 110;
            pm.Skills.Forensics.Cap = 120;
            pm.Skills.Healing.Cap = 90;
            pm.Skills.Herding.Cap = 100;
            pm.Skills.Hiding.Cap = 120;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 110;
            pm.Skills.Lockpicking.Cap = 90;
            pm.Skills.Lumberjacking.Cap = 100;
            pm.Skills.Macing.Cap = 100;
            pm.Skills.Magery.Cap = 90;
            pm.Skills.MagicResist.Cap = 120;
            pm.Skills.Meditation.Cap = 110;
            pm.Skills.Mining.Cap = 100;
            pm.Skills.Musicianship.Cap = 80;
            pm.Skills.Necromancy.Cap = 120;
            pm.Skills.Ninjitsu.Cap = 100;
            pm.Skills.Parry.Cap = 100;
            pm.Skills.Peacemaking.Cap = 100;
            pm.Skills.Poisoning.Cap = 100;
            pm.Skills.Provocation.Cap = 100;
            pm.Skills.RemoveTrap.Cap = 100;
            pm.Skills.Snooping.Cap = 90;
            pm.Skills.Spellweaving.Cap = 80;
            pm.Skills.SpiritSpeak.Cap = 120;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 110;
            pm.Skills.Swords.Cap = 100;
            pm.Skills.Tactics.Cap = 100;
            pm.Skills.Tailoring.Cap = 90;
            pm.Skills.TasteID.Cap = 110;
            pm.Skills.Tinkering.Cap = 90;
            pm.Skills.Tracking.Cap = 100;
            pm.Skills.Veterinary.Cap = 80;
            pm.Skills.Wrestling.Cap = 100;
        }

        private static void Clerc(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 110;
            pm.Skills.Anatomy.Cap = 120;
            pm.Skills.AnimalLore.Cap = 100;
            pm.Skills.AnimalTaming.Cap = 90;
            pm.Skills.Archery.Cap = 90;
            pm.Skills.ArmsLore.Cap = 110;
            pm.Skills.Begging.Cap = 100;
            pm.Skills.Blacksmith.Cap = 80;
            pm.Skills.Bushido.Cap = 80;
            pm.Skills.Camping.Cap = 100;
            pm.Skills.Carpentry.Cap = 100;
            pm.Skills.Cartography.Cap = 100;
            pm.Skills.Chivalry.Cap = 100;
            pm.Skills.Cooking.Cap = 100;
            pm.Skills.DetectHidden.Cap = 110;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 110;
            pm.Skills.Fencing.Cap = 90;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 90;
            pm.Skills.Focus.Cap = 100;
            pm.Skills.Forensics.Cap = 100;
            pm.Skills.Healing.Cap = 120;
            pm.Skills.Herding.Cap = 110;
            pm.Skills.Hiding.Cap = 100;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 110;
            pm.Skills.Lockpicking.Cap = 100;
            pm.Skills.Lumberjacking.Cap = 80;
            pm.Skills.Macing.Cap = 110;
            pm.Skills.Magery.Cap = 120;
            pm.Skills.MagicResist.Cap = 110;
            pm.Skills.Meditation.Cap = 120;
            pm.Skills.Mining.Cap = 90;
            pm.Skills.Musicianship.Cap = 100;
            pm.Skills.Necromancy.Cap = 90;
            pm.Skills.Ninjitsu.Cap = 90;
            pm.Skills.Parry.Cap = 100;
            pm.Skills.Peacemaking.Cap = 100;
            pm.Skills.Poisoning.Cap = 100;
            pm.Skills.Provocation.Cap = 100;
            pm.Skills.RemoveTrap.Cap = 100;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 80;
            pm.Skills.SpiritSpeak.Cap = 120;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 100;
            pm.Skills.Swords.Cap = 90;
            pm.Skills.Tactics.Cap = 110;
            pm.Skills.Tailoring.Cap = 90;
            pm.Skills.TasteID.Cap = 110;
            pm.Skills.Tinkering.Cap = 90;
            pm.Skills.Tracking.Cap = 100;
            pm.Skills.Veterinary.Cap = 100;
            pm.Skills.Wrestling.Cap = 100;
        }

        private static void Paladin(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 100;
            pm.Skills.Anatomy.Cap = 120;
            pm.Skills.AnimalLore.Cap = 100;
            pm.Skills.AnimalTaming.Cap = 90;
            pm.Skills.Archery.Cap = 100;
            pm.Skills.ArmsLore.Cap = 110;
            pm.Skills.Begging.Cap = 110;
            pm.Skills.Blacksmith.Cap = 90;
            pm.Skills.Bushido.Cap = 90;
            pm.Skills.Camping.Cap = 100;
            pm.Skills.Carpentry.Cap = 90;
            pm.Skills.Cartography.Cap = 100;
            pm.Skills.Chivalry.Cap = 120;
            pm.Skills.Cooking.Cap = 100;
            pm.Skills.DetectHidden.Cap = 110;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 110;
            pm.Skills.Fencing.Cap = 100;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 90;
            pm.Skills.Focus.Cap = 110;
            pm.Skills.Forensics.Cap = 100;
            pm.Skills.Healing.Cap = 90;
            pm.Skills.Herding.Cap = 100;
            pm.Skills.Hiding.Cap = 100;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 100;
            pm.Skills.Lockpicking.Cap = 100;
            pm.Skills.Lumberjacking.Cap = 110;
            pm.Skills.Macing.Cap = 120;
            pm.Skills.Magery.Cap = 80;
            pm.Skills.MagicResist.Cap = 100;
            pm.Skills.Meditation.Cap = 110;
            pm.Skills.Mining.Cap = 100;
            pm.Skills.Musicianship.Cap = 90;
            pm.Skills.Necromancy.Cap = 80;
            pm.Skills.Ninjitsu.Cap = 80;
            pm.Skills.Parry.Cap = 110;
            pm.Skills.Peacemaking.Cap = 90;
            pm.Skills.Poisoning.Cap = 100;
            pm.Skills.Provocation.Cap = 90;
            pm.Skills.RemoveTrap.Cap = 100;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 100;
            pm.Skills.SpiritSpeak.Cap = 110;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 100;
            pm.Skills.Swords.Cap = 120;
            pm.Skills.Tactics.Cap = 120;
            pm.Skills.Tailoring.Cap = 80;
            pm.Skills.TasteID.Cap = 90;
            pm.Skills.Tinkering.Cap = 100;
            pm.Skills.Tracking.Cap = 100;
            pm.Skills.Veterinary.Cap = 100;
            pm.Skills.Wrestling.Cap = 110;
        }

        private static void Mage(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 110;
            pm.Skills.Anatomy.Cap = 110;
            pm.Skills.AnimalLore.Cap = 100;
            pm.Skills.AnimalTaming.Cap = 90;
            pm.Skills.Archery.Cap = 90;
            pm.Skills.ArmsLore.Cap = 100;
            pm.Skills.Begging.Cap = 90;
            pm.Skills.Blacksmith.Cap = 80;
            pm.Skills.Bushido.Cap = 90;
            pm.Skills.Camping.Cap = 100;
            pm.Skills.Carpentry.Cap = 100;
            pm.Skills.Cartography.Cap = 100;
            pm.Skills.Chivalry.Cap = 100;
            pm.Skills.Cooking.Cap = 110;
            pm.Skills.DetectHidden.Cap = 100;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 120;
            pm.Skills.Fencing.Cap = 90;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 90;
            pm.Skills.Focus.Cap = 110;
            pm.Skills.Forensics.Cap = 100;
            pm.Skills.Healing.Cap = 100;
            pm.Skills.Herding.Cap = 100;
            pm.Skills.Hiding.Cap = 100;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 110;
            pm.Skills.Lockpicking.Cap = 100;
            pm.Skills.Lumberjacking.Cap = 90;
            pm.Skills.Macing.Cap = 80;
            pm.Skills.Magery.Cap = 120;
            pm.Skills.MagicResist.Cap = 120;
            pm.Skills.Meditation.Cap = 120;
            pm.Skills.Mining.Cap = 80;
            pm.Skills.Musicianship.Cap = 110;
            pm.Skills.Necromancy.Cap = 110;
            pm.Skills.Ninjitsu.Cap = 90;
            pm.Skills.Parry.Cap = 100;
            pm.Skills.Peacemaking.Cap = 110;
            pm.Skills.Poisoning.Cap = 100;
            pm.Skills.Provocation.Cap = 110;
            pm.Skills.RemoveTrap.Cap = 100;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 120;
            pm.Skills.SpiritSpeak.Cap = 110;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 100;
            pm.Skills.Swords.Cap = 80;
            pm.Skills.Tactics.Cap = 100;
            pm.Skills.Tailoring.Cap = 90;
            pm.Skills.TasteID.Cap = 100;
            pm.Skills.Tinkering.Cap = 90;
            pm.Skills.Tracking.Cap = 100;
            pm.Skills.Veterinary.Cap = 100;
            pm.Skills.Wrestling.Cap = 100;
        }

        private static void Protecteur(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 100;
            pm.Skills.Anatomy.Cap = 110;
            pm.Skills.AnimalLore.Cap = 100;
            pm.Skills.AnimalTaming.Cap = 100;
            pm.Skills.Archery.Cap = 90;
            pm.Skills.ArmsLore.Cap = 100;
            pm.Skills.Begging.Cap = 100;
            pm.Skills.Blacksmith.Cap = 100;
            pm.Skills.Bushido.Cap = 120;
            pm.Skills.Camping.Cap = 100;
            pm.Skills.Carpentry.Cap = 90;
            pm.Skills.Cartography.Cap = 90;
            pm.Skills.Chivalry.Cap = 110;
            pm.Skills.Cooking.Cap = 100;
            pm.Skills.DetectHidden.Cap = 110;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 100;
            pm.Skills.Fencing.Cap = 120;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 90;
            pm.Skills.Focus.Cap = 110;
            pm.Skills.Forensics.Cap = 110;
            pm.Skills.Healing.Cap = 110;
            pm.Skills.Herding.Cap = 100;
            pm.Skills.Hiding.Cap = 100;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 100;
            pm.Skills.Lockpicking.Cap = 100;
            pm.Skills.Lumberjacking.Cap = 110;
            pm.Skills.Macing.Cap = 100;
            pm.Skills.Magery.Cap = 80;
            pm.Skills.MagicResist.Cap = 120;
            pm.Skills.Meditation.Cap = 100;
            pm.Skills.Mining.Cap = 100;
            pm.Skills.Musicianship.Cap = 90;
            pm.Skills.Necromancy.Cap = 80;
            pm.Skills.Ninjitsu.Cap = 80;
            pm.Skills.Parry.Cap = 120;
            pm.Skills.Peacemaking.Cap = 90;
            pm.Skills.Poisoning.Cap = 90;
            pm.Skills.Provocation.Cap = 100;
            pm.Skills.RemoveTrap.Cap = 110;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 90;
            pm.Skills.SpiritSpeak.Cap = 100;
            pm.Skills.Stealing.Cap = 90;
            pm.Skills.Stealth.Cap = 100;
            pm.Skills.Swords.Cap = 110;
            pm.Skills.Tactics.Cap = 120;
            pm.Skills.Tailoring.Cap = 80;
            pm.Skills.TasteID.Cap = 110;
            pm.Skills.Tinkering.Cap = 90;
            pm.Skills.Tracking.Cap = 100;
            pm.Skills.Veterinary.Cap = 100;
            pm.Skills.Wrestling.Cap = 100;
        }

        private static void Assassin(PlayerMobile pm)
         {
            pm.Skills.Alchemy.Cap = 100;
            pm.Skills.Anatomy.Cap = 110;
            pm.Skills.AnimalLore.Cap = 100;
            pm.Skills.AnimalTaming.Cap = 100;
            pm.Skills.Archery.Cap = 100;
            pm.Skills.ArmsLore.Cap = 110;
            pm.Skills.Begging.Cap = 100;
            pm.Skills.Blacksmith.Cap = 80;
            pm.Skills.Bushido.Cap = 100;
            pm.Skills.Camping.Cap = 110;
            pm.Skills.Carpentry.Cap = 90;
            pm.Skills.Cartography.Cap = 100;
            pm.Skills.Chivalry.Cap = 80;
            pm.Skills.Cooking.Cap = 100;
            pm.Skills.DetectHidden.Cap = 100;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 100;
            pm.Skills.Fencing.Cap = 120;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 90;
            pm.Skills.Focus.Cap = 110;
            pm.Skills.Forensics.Cap = 100;
            pm.Skills.Healing.Cap = 100;
            pm.Skills.Herding.Cap = 100;
            pm.Skills.Hiding.Cap = 120;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 100;
	        pm.Skills.Lockpicking.Cap = 110;
            pm.Skills.Lumberjacking.Cap = 80;
            pm.Skills.Macing.Cap = 90;
            pm.Skills.Magery.Cap = 80;
            pm.Skills.MagicResist.Cap = 100;
            pm.Skills.Meditation.Cap = 100;
            pm.Skills.Mining.Cap = 100;
            pm.Skills.Musicianship.Cap = 90;
            pm.Skills.Necromancy.Cap = 80;
            pm.Skills.Ninjitsu.Cap = 120;
            pm.Skills.Parry.Cap = 100;
            pm.Skills.Peacemaking.Cap = 90;
            pm.Skills.Poisoning.Cap = 120;
            pm.Skills.Provocation.Cap = 100;
            pm.Skills.RemoveTrap.Cap = 100;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 90;
            pm.Skills.SpiritSpeak.Cap = 100;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 120;
            pm.Skills.Swords.Cap = 90;
            pm.Skills.Tactics.Cap = 110;
            pm.Skills.Tailoring.Cap = 90;
            pm.Skills.TasteID.Cap = 100;
            pm.Skills.Tinkering.Cap = 110;
            pm.Skills.Tracking.Cap = 110;
            pm.Skills.Veterinary.Cap = 90;
            pm.Skills.Wrestling.Cap = 110;
        }

        private static void Roublard(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 90;
            pm.Skills.Anatomy.Cap = 110;
            pm.Skills.AnimalLore.Cap = 100;
            pm.Skills.AnimalTaming.Cap = 90;
            pm.Skills.Archery.Cap = 110;
            pm.Skills.ArmsLore.Cap = 110;
            pm.Skills.Begging.Cap = 110;
            pm.Skills.Blacksmith.Cap = 80;
            pm.Skills.Bushido.Cap = 90;
            pm.Skills.Camping.Cap = 110;
            pm.Skills.Carpentry.Cap = 90;
            pm.Skills.Cartography.Cap = 100;
            pm.Skills.Chivalry.Cap = 80;
            pm.Skills.Cooking.Cap = 100;
            pm.Skills.DetectHidden.Cap = 100;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 100;
            pm.Skills.Fencing.Cap = 110;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 90;
            pm.Skills.Focus.Cap = 100;
            pm.Skills.Forensics.Cap = 100;
            pm.Skills.Healing.Cap = 80;
            pm.Skills.Herding.Cap = 110;
            pm.Skills.Hiding.Cap = 120;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 100;
            pm.Skills.Lockpicking.Cap = 120;
            pm.Skills.Lumberjacking.Cap = 100;
            pm.Skills.Macing.Cap = 100;
            pm.Skills.Magery.Cap = 90;
            pm.Skills.MagicResist.Cap = 100;
            pm.Skills.Meditation.Cap = 100;
            pm.Skills.Mining.Cap = 90;
            pm.Skills.Musicianship.Cap = 100;
            pm.Skills.Necromancy.Cap = 90;
            pm.Skills.Ninjitsu.Cap = 100;
            pm.Skills.Parry.Cap = 80;
            pm.Skills.Peacemaking.Cap = 100;
            pm.Skills.Poisoning.Cap = 100;
            pm.Skills.Provocation.Cap = 100;
            pm.Skills.RemoveTrap.Cap = 110;
            pm.Skills.Snooping.Cap = 120;
            pm.Skills.Spellweaving.Cap = 90;
            pm.Skills.SpiritSpeak.Cap = 100;
            pm.Skills.Stealing.Cap = 120;
            pm.Skills.Stealth.Cap = 120;
            pm.Skills.Swords.Cap = 100;
            pm.Skills.Tactics.Cap = 110;
            pm.Skills.Tailoring.Cap = 90;
            pm.Skills.TasteID.Cap = 100;
            pm.Skills.Tinkering.Cap = 100;
            pm.Skills.Tracking.Cap = 110;
            pm.Skills.Veterinary.Cap = 100;
            pm.Skills.Wrestling.Cap = 100;
        }

        private static void Traqueur(PlayerMobile pm)
        {
            pm.Skills.Alchemy.Cap = 100;
            pm.Skills.Anatomy.Cap = 110;
            pm.Skills.AnimalLore.Cap = 110;
            pm.Skills.AnimalTaming.Cap = 110;
            pm.Skills.Archery.Cap = 110;
            pm.Skills.ArmsLore.Cap = 100;
            pm.Skills.Begging.Cap = 100;
            pm.Skills.Blacksmith.Cap = 90;
            pm.Skills.Bushido.Cap = 90;
            pm.Skills.Camping.Cap = 110;
            pm.Skills.Carpentry.Cap = 90;
            pm.Skills.Cartography.Cap = 100;
            pm.Skills.Chivalry.Cap = 80;
            pm.Skills.Cooking.Cap = 100;
            pm.Skills.DetectHidden.Cap = 120;
            pm.Skills.Discordance.Cap = 100;
            pm.Skills.EvalInt.Cap = 100;
            pm.Skills.Fencing.Cap = 100;
            pm.Skills.Fishing.Cap = 100;
            pm.Skills.Fletching.Cap = 80;
            pm.Skills.Focus.Cap = 110;
            pm.Skills.Forensics.Cap = 110;
            pm.Skills.Healing.Cap = 110;
            pm.Skills.Herding.Cap = 100;
            pm.Skills.Hiding.Cap = 120;
            pm.Skills.Inscribe.Cap = 80;
            pm.Skills.ItemID.Cap = 100;
            pm.Skills.Lockpicking.Cap = 100;
            pm.Skills.Lumberjacking.Cap = 90;
            pm.Skills.Macing.Cap = 90;
            pm.Skills.Magery.Cap = 80;
            pm.Skills.MagicResist.Cap = 100;
            pm.Skills.Meditation.Cap = 100;
            pm.Skills.Mining.Cap = 90;
            pm.Skills.Musicianship.Cap = 90;
            pm.Skills.Necromancy.Cap = 80;
            pm.Skills.Ninjitsu.Cap = 100;
            pm.Skills.Parry.Cap = 100;
            pm.Skills.Peacemaking.Cap = 100;
            pm.Skills.Poisoning.Cap = 100;
            pm.Skills.Provocation.Cap = 100;
            pm.Skills.RemoveTrap.Cap = 110;
            pm.Skills.Snooping.Cap = 100;
            pm.Skills.Spellweaving.Cap = 90;
            pm.Skills.SpiritSpeak.Cap = 100;
            pm.Skills.Stealing.Cap = 100;
            pm.Skills.Stealth.Cap = 120;
            pm.Skills.Swords.Cap = 100;
            pm.Skills.Tactics.Cap = 120;
            pm.Skills.Tailoring.Cap = 90;
            pm.Skills.TasteID.Cap = 100;
            pm.Skills.Tinkering.Cap = 90;
            pm.Skills.Tracking.Cap = 120;
            pm.Skills.Veterinary.Cap = 110;
            pm.Skills.Wrestling.Cap = 100;
        }
        #endregion
    }
}
