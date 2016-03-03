using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells.Druid
{
    public class DruideFocusSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Force de la Nature", "Nos Te Houuuur",
				269,
				9020,
            Reagent.PetrafiedWood
			);

        public override SpellCircle Circle { get { return SpellCircle.First; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(5.0); } }
		public override double RequiredSkill{ get{ return 100.0; } }
		public override int RequiredMana{ get{ return 40; } }
		private static Hashtable m_Table = new Hashtable();

		public DruideFocusSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public static double GetScalar( Mobile m )
		{
			double val = 1.0;

			if ( m.CanBeginAction( typeof( DruideFocusSpell ) ) )
				val = 1.5;

			return val;
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
			{
				return false;
			}
			if ( !Caster.CanBeginAction( typeof( DruideFocusSpell ) ) )
			{
				Caster.SendMessage( "Le sort est actif" );
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( !Caster.CanBeginAction( typeof( DruideFocusSpell ) ) )
			{
				Caster.SendMessage( "Le sort est actif" );
				return;
			}

			if ( CheckSequence() )
			{
				Caster.BeginAction( typeof( DruideFocusSpell ) );				

				Timer t = new InternalTimer( Caster );
				m_Table[Caster] = t;
				t.Start();

				Caster.FixedParticles( 14170, 1, 15, 0x480, 1, 4, EffectLayer.Waist );
			}
		}


		private class InternalTimer : Timer
		{
			private Mobile m_Owner;

			public InternalTimer( Mobile owner ) : base( TimeSpan.Zero, TimeSpan.FromSeconds( 2.5 ) )
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if ( !m_Owner.CheckAlive() || m_Owner.Mana < 30 )
				{
					m_Owner.EndAction( typeof( DruideFocusSpell ) );
					m_Table.Remove( m_Owner );
					m_Owner.SendMessage( "Vous fatiguez vous ne pouvez maintenir ce sort" );
					Stop();
				}
				else
				{
					m_Owner.Mana -= 5;
				}
			}
		}
	}
}