using System;
using System.Collections;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Items;
namespace Server.Spells.Druid
{
    public class Protspell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Peau de Pierre", "Hoc Pao Pieras",
				269,
				9020,
            Reagent.SpringWater
			);

        public override SpellCircle Circle { get { return SpellCircle.First; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
      public override double RequiredSkill{ get{ return 30.0; } }
      public override int RequiredMana{ get{ return 20; } }
		
		public Protspell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( Core.AOS )
				return true;

			if ( Caster.MeleeDamageAbsorb > 0 )
			{
				Caster.SendLocalizedMessage( 1005559 ); // This spell is already in effect.
				return false;
			}
			else if ( !Caster.CanBeginAction( typeof( DefensiveSpell ) ) )
			{
				Caster.SendLocalizedMessage( 1005385 ); // The spell will not adhere to you at this time.
				return false;
			}

			return true;
		}

		private static Hashtable m_Table = new Hashtable();

		public override void OnCast()
		{
			if ( Core.AOS )
			{
				/* The reactive armor spell increases the caster's physical resistance, while lowering the caster's elemental resistances.
				 * 15 + (Inscription/20) Physcial bonus
				 * -5 Elemental
				 * The reactive armor spell has an indefinite duration, becoming active when cast, and deactivated when re-cast. 
				 * Reactive Armor, Protection, and Magic Reflection will stay on—even after logging out, even after dying—until you “turn them off” by casting them again. 
				 * (+20 physical -5 elemental at 100 Inscription)
				 */

				if ( CheckSequence() )
				{
					Mobile targ = Caster;

					ResistanceMod[] mods = (ResistanceMod[])m_Table[targ];

					if ( mods == null )
					{
						targ.PlaySound( 0x1E9 );
						targ.FixedParticles( 14170, 9, 32, 5008, EffectLayer.Waist );

						mods = new ResistanceMod[5]
							{
								new ResistanceMod( ResistanceType.Physical, 15 + (int)(targ.Skills[SkillName.AnimalLore].Value / 20) ),
								new ResistanceMod( ResistanceType.Fire, +15 ),
								new ResistanceMod( ResistanceType.Cold, +15 ),
								new ResistanceMod( ResistanceType.Poison, +15 ),
								new ResistanceMod( ResistanceType.Energy, +15 )
							};

						m_Table[targ] = mods;

						for ( int i = 0; i < mods.Length; ++i )
							targ.AddResistanceMod( mods[i] );
					}
					else
					{
						targ.PlaySound( 0x1ED );
						targ.FixedParticles( 0x376A, 9, 32, 5008, EffectLayer.Waist );

						m_Table.Remove( targ );

						for ( int i = 0; i < mods.Length; ++i )
							targ.RemoveResistanceMod( mods[i] );
					}
				}

				FinishSequence();
			}
			else
			{
				if ( Caster.MeleeDamageAbsorb > 0 )
				{
					Caster.SendLocalizedMessage( 1005559 ); // This spell is already in effect.
				}
				else if ( !Caster.CanBeginAction( typeof( DefensiveSpell ) ) )
				{
					Caster.SendLocalizedMessage( 1005385 ); // The spell will not adhere to you at this time.
				}
				else if ( CheckSequence() )
				{
					if ( Caster.BeginAction( typeof( DefensiveSpell ) ) )
					{
						int value = (int)(Caster.Skills[SkillName.AnimalLore].Value + Caster.Skills[SkillName.Magery].Value + Caster.Skills[SkillName.Anatomy].Value);
						value /= 3;

						if ( value < 0 )
							value = 1;
						else if ( value > 75 )
							value = 75;

						Caster.MeleeDamageAbsorb = value;

						Caster.FixedParticles( 0x376A, 9, 32, 5008, EffectLayer.Waist );
						Caster.PlaySound( 0x1F2 );
					}
					else
					{
						Caster.SendLocalizedMessage( 1005385 ); // The spell will not adhere to you at this time.
					}
				}

				FinishSequence();
			}
		}
	}
}