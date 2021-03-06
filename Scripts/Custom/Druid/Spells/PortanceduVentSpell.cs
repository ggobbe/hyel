using System;
using Server.Targeting;
using Server.Network;
using Server.Regions;
using Server.Items;

namespace Server.Spells.Druid
{
    public class PortanceduVentSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Portance du vent", "Re Ven",
				215,
				9031,
				Reagent.Bloodmoss,
				Reagent.PetrafiedWood
			);
        public override SpellCircle Circle { get { return SpellCircle.Third; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
      	public override double RequiredSkill{ get{ return 35.0; } }
      	public override int RequiredMana{ get{ return 10; } }

		public PortanceduVentSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( Server.Misc.WeightOverloading.IsOverloaded( Caster ) )
			{
				Caster.SendLocalizedMessage( 502359, "", 0x22 ); // Thou art too encumbered to move.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( IPoint3D p )
		{
			IPoint3D orig = p;
			Map map = Caster.Map;

			SpellHelper.GetSurfaceTop( ref p );

			if ( Server.Misc.WeightOverloading.IsOverloaded( Caster ) )
			{
				Caster.SendLocalizedMessage( 502359, "", 0x22 ); // Thou art too encumbered to move.
			}
			else if ( map == null || !map.CanSpawnMobile( p.X, p.Y, p.Z ) )
			{
				Caster.SendLocalizedMessage( 501942 ); // That location is blocked.
			}
			else if ( SpellHelper.CheckMulti( new Point3D( p ), map ) )
			{
				Caster.SendLocalizedMessage( 501942 ); // That location is blocked.
			}
			else if ( CheckSequence() )
			{
				SpellHelper.Turn( Caster, orig );

				Mobile m = Caster;

				Point3D from = m.Location;
				Point3D to = new Point3D( p );

				m.Location = to;
				m.ProcessDelta();

				Effects.SendLocationParticles( EffectItem.Create( from, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
				Effects.SendLocationParticles( EffectItem.Create(   to, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 5023 );

				m.PlaySound( 20 );
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private PortanceduVentSpell m_Owner;

			public InternalTarget( PortanceduVentSpell owner ) : base( 12, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				IPoint3D p = o as IPoint3D;

				if ( p != null )
					m_Owner.Target( p );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
