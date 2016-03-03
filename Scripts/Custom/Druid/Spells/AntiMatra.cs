using System;
using Server.Misc;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Druid
{
    public class AntiMatraSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"AntiMatra", "An Ort Nat",
				218,
				9002,
				Reagent.Garlic,
				Reagent.DestroyingAngel
			);
        public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2.0); } }
		public override double RequiredSkill{ get{ return 50.0; } }
		public override int RequiredMana{ get{ return 30; } }
		
//		private static Hashtable m_Table = new Hashtable();
		
		public AntiMatraSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}
		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			Type t = m.GetType();
			bool dispellable = false;

			if ( m is BaseCreature )
				dispellable = ((BaseCreature)m).Summoned && !((BaseCreature)m).IsAnimatedDead;

			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( !dispellable )
			{
				Caster.SendLocalizedMessage( 1005049 ); // That cannot be dispelled.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				if ( CheckResisted( m ) )
				{
					m.FixedEffect( 0x3779, 10, 20 );
				}
				else
				{
					Effects.SendLocationParticles( EffectItem.Create( m.Location, m.Map, EffectItem.DefaultDuration ), 0x3728, 8, 20, 5042 );
					Effects.PlaySound( m, m.Map, 0x201 );

					m.Delete();
				}
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private AntiMatraSpell m_Owner;

			public InternalTarget( AntiMatraSpell owner ) : base( 12, false, TargetFlags.Harmful )
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