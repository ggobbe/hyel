using System;
using Server.Targeting;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells.Druid
{
    public class DonnerFaimSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Donner Faim", "Lem Ne",
				203,
				9051,
				Reagent.SpringWater
			);
        public override SpellCircle Circle { get { return SpellCircle.Third; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(0.5); } }
      public override double RequiredSkill{ get{ return 50.0; } }
      public override int RequiredMana{ get{ return 10; } }

		public DonnerFaimSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}
		

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m )  )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if (m is PlayerMobile)
			{
				
				if ( CheckBSequence( m ) )
					{
					SpellHelper.Turn(Caster, m );

					int old_Hunger = m.Hunger;
					int hunger = old_Hunger - ( m.Hunger * 25 ) / 100;
					m.Hunger = hunger;
					m.SendMessage(38,"Vous avez d'un seul coup, trés trés faim");
					Caster.SendMessage(38,"Vous venez de donner faim à votre cible");
				
					m.FixedParticles( 0x376A, 9, 32, 5008, EffectLayer.Waist );
					Caster.FixedParticles( 0x376A, 9, 32, 5008, EffectLayer.Waist );
					m.PlaySound( 0x477 );
					
			   		}
				FinishSequence();
				return;
				
			}
			Caster.SendMessage(38,"Vous ne pouvez rien faire sur cette cette cible");
			FinishSequence();
		}
		

		private class InternalTarget : Target
		{
			private DonnerFaimSpell m_Owner;

			public InternalTarget( DonnerFaimSpell owner ) : base( 6, false, TargetFlags.Beneficial )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
				{
					m_Owner.Target( (Mobile)o );
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
