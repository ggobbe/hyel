using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells.Cleric
{
	public class DivineFocusSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Divin Focus", "Deus powwa",
				212,
				9041
			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3.0); } }
		public override int RequiredTithing{ get{ return 200; } }
		public override double RequiredSkill{ get{ return 100.0; } }
		public override int RequiredMana{ get{ return 90; } }
        public override SpellCircle Circle { get { return SpellCircle.First; } }
		private static Hashtable m_Table = new Hashtable();

		public DivineFocusSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public static double GetScalar( Mobile m )
		{
			double val = 1.0;

			if ( m.CanBeginAction( typeof( DivineFocusSpell ) ) )
				val = 1.5;

			return val;
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
			{
				return false;
			}
			if ( !Caster.CanBeginAction( typeof( DivineFocusSpell ) ) )
			{
				Caster.SendMessage( "Le sort est actif" );
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( !Caster.CanBeginAction( typeof( DivineFocusSpell ) ) )
			{
				Caster.SendMessage( "Le sort est actif" );
				return;
			}

			if ( CheckSequence() )
			{
				Caster.BeginAction( typeof( DivineFocusSpell ) );				

				Timer t = new InternalTimer( Caster );
				m_Table[Caster] = t;
				t.Start();

				Caster.FixedParticles( 0x375A, 1, 15, 0x480, 1, 4, EffectLayer.Waist );
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
				if ( !m_Owner.CheckAlive() || m_Owner.Mana < 3 )
				{
					m_Owner.EndAction( typeof( DivineFocusSpell ) );
					m_Table.Remove( m_Owner );
					m_Owner.SendMessage( "Vous fatiguez vous ne pouvez maintenir ce sort" );
					Stop();
				}
				else
				{
					m_Owner.Mana -= 3;
				}
			}
		}
	}
}
