using System;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.Regions;

namespace Server.Spells.Druid
{
    public class MarqueSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Marquer une Rune", "Kel Par Lem",
				218,
				9002,
				Reagent.SpringWater,
				Reagent.PetrafiedWood,
				Reagent.MandrakeRoot
			);
        public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2.0); } }
        public override double RequiredSkill{ get{ return 60.0; } }
        public override int RequiredMana{ get{ return 20; } }	

		public MarqueSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			return SpellHelper.CheckTravel( Caster, TravelCheckType.Mark );
		}

		public void Target( RecallRune rune )
		{
			if ( !Caster.CanSee( rune ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( !SpellHelper.CheckTravel( Caster, TravelCheckType.Mark ) )
			{
			}
			else if ( SpellHelper.CheckMulti( Caster.Location, Caster.Map, !Core.AOS ) )
			{
				Caster.SendLocalizedMessage( 501942 ); // That location is blocked.
			}
			else if ( CheckSequence() )
			{
				rune.Mark( Caster );

				Caster.PlaySound( 0x1FA );
				Effects.SendLocationEffect( Caster, Caster.Map, 14201, 16 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private MarqueSpell m_Owner;

			public InternalTarget( MarqueSpell owner ) : base( 12, false, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is RecallRune )
				{
					m_Owner.Target( (RecallRune) o );
				}
				else
				{
					from.Send( new MessageLocalized( from.Serial, from.Body, MessageType.Regular, 0x3B2, 3, 501797, from.Name, "" ) ); // I cannot mark that object.
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
