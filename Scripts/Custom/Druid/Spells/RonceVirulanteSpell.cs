using System;
using Server.Targeting;
using Server.Network;
using Server.Items;

namespace Server.Spells.Druid
{
    public class RonceVirulanteSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Ronce Virulante", "Ax Nox Pla",
				203,
				9051,
				Reagent.Nightshade,
				Reagent.DestroyingAngel
			);
        public override SpellCircle Circle { get { return SpellCircle.Third; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.5); } }
      public override double RequiredSkill{ get{ return 35.0; } }
      public override int RequiredMana{ get{ return 15; } }

		public RonceVirulanteSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn(Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

				if ( m.Spell != null )
					m.Spell.OnCasterHurt();

				m.Paralyzed = false;

				if ( CheckResisted( m ) )
				{
					m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
				}
				else
				{
					double total = Caster.Skills[SkillName.Magery].Value + (((Caster.Skills[SkillName.Poisoning].Value)+(Caster.Skills[SkillName.AnimalLore].Value)) / 2);

					double dist = Caster.GetDistanceToSqrt( m );

					if ( dist >= 3.0 )
						total -= (dist - 3.0) * 10.0;

					int level;

					if ( total >= 260.0 && (Core.AOS || Utility.Random( 1, 100 ) <= 10) )
						level = 3;
					else if ( total > (Core.AOS ? 220.1 : 220.0) )
						level = 2;
					else if ( total > (Core.AOS ? 180.1 : 180.0) )
						level = 1;
					else
						level = 0;

					m.ApplyPoison( Caster, Poison.GetPoison( level ) );
				}
				
				m.FixedParticles( 6814, 10, 15, 5028, EffectLayer.Waist );
				m.FixedParticles( 6815, 10, 15, 5028, EffectLayer.RightFoot );				
				m.FixedParticles( 6816, 10, 15, 5028, EffectLayer.LeftFoot );
				m.FixedParticles( 6817, 10, 15, 5028, EffectLayer.LeftFoot );
				m.PlaySound( 0x477 );

			}

			FinishSequence();
		}
		

		private class InternalTarget : Target
		{
			private RonceVirulanteSpell m_Owner;

			public InternalTarget( RonceVirulanteSpell owner ) : base( 12, false, TargetFlags.Harmful )
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
