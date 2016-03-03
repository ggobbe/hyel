using System;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.Misc;

namespace Server.Spells.Druid
{
    public class NaturalParalyzeFieldSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Mur Naturel Paralisant", "En Kes Grav",
				230,
				9012,
				Reagent.PetrafiedWood
			);
        public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
	    public override double RequiredSkill{ get{ return 40.0; } }
	    public override int RequiredMana{ get{ return 15; } }
		//public override bool BlocksMovement{ get{ return false; } }
		
		public NaturalParalyzeFieldSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( IPoint3D p )
		{
			if ( !Caster.CanSee( p ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( SpellHelper.CheckTown( p, Caster ) && CheckSequence() )
			{
				SpellHelper.Turn( Caster, p );

				SpellHelper.GetSurfaceTop( ref p );

				int dx = Caster.Location.X - p.X;
				int dy = Caster.Location.Y - p.Y;
				int rx = (dx - dy) * 44;
				int ry = (dx + dy) * 44;

				bool eastToWest;

				if ( rx >= 0 && ry >= 0 )
					eastToWest = false;
				else if ( rx >= 0 )
					eastToWest = true;
				else if ( ry >= 0 )
					eastToWest = true;
				else
					eastToWest = false;

				Effects.PlaySound( p, Caster.Map, 0x20B );

				int itemID = eastToWest ? 0x1AA1 : 0x1AA1;

				TimeSpan duration = TimeSpan.FromSeconds( 3.0 + (Caster.Skills[SkillName.Magery].Value / 3.0) );

				for ( int i = -2; i <= 2; ++i )
				{
					Point3D loc = new Point3D( eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z );
					bool canFit = SpellHelper.AdjustField( ref loc, Caster.Map, 12, false );

					if ( !canFit )
						continue;

					Item item = new InternalItem( Caster, itemID, loc, Caster.Map, duration );
					item.ProcessDelta();

					Effects.SendLocationParticles( EffectItem.Create( loc, Caster.Map, EffectItem.DefaultDuration ), 0xC5F, 2, 10, 5027, 0x3D );
																													
				}
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Item
		{
			private Timer m_Timer;
			private Mobile m_Caster;
			private DateTime m_End;

			public override bool BlocksFit{ get{ return true; } }

			public InternalItem( Mobile caster, int itemID, Point3D loc, Map map, TimeSpan duration ) : base( itemID )
			{
				Visible = false;
				Movable = false;
				Light = LightType.Circle300;

				MoveToWorld( loc, map );

				if ( caster.InLOS( this ) )
					Visible = true;
				else
					Delete();

				if ( Deleted )
					return;

				m_Caster = caster;

				m_Timer = new InternalTimer( this, duration );
				m_Timer.Start();

				m_End = DateTime.Now + duration;
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if ( m_Timer != null )
					m_Timer.Stop();
			}

			public InternalItem( Serial serial ) : base( serial )
			{
			}

			public override void Serialize( GenericWriter writer )
			{
				base.Serialize( writer );

				writer.Write( (int) 0 ); // version

				writer.Write( m_Caster );
				writer.WriteDeltaTime( m_End );
			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );

				int version = reader.ReadInt();

				switch ( version )
				{
					case 0:
					{
						m_Caster = reader.ReadMobile();
						m_End = reader.ReadDeltaTime();

						m_Timer = new InternalTimer( this, m_End - DateTime.Now );
						m_Timer.Start();

						break;
					}
				}
			}

		

			public override bool OnMoveOver( Mobile m )
			{
				if ( Visible && m_Caster != null && (m.AccessLevel <= AccessLevel.GameMaster) )
				{
					m_Caster.DoHarmful( m );

					double duration;

					if ( Core.AOS )
					{
						duration = ((((m_Caster.Skills[SkillName.Magery].Value)+(m_Caster.Skills[SkillName.AnimalLore].Value))*0.5) - m.Skills[SkillName.MagicResist].Value) * 0.3;
						if ( duration < 0.0 )
							duration = 1.0;
					}
					else
					{
						duration = 7.0 + ((m_Caster.Skills[SkillName.Magery].Value) + (m_Caster.Skills[SkillName.AnimalLore].Value) * 0.2);
					}
					if (m_Caster == m)
					{
						duration = (m_Caster.Skills[SkillName.Magery].Value * 0.1);
					}

					m.Paralyze( TimeSpan.FromSeconds( duration ) );

					m.PlaySound( 0x204 );
					m.FixedParticles( 0x375A, 2, 10, 5027, 0x3D, 2, EffectLayer.Waist );
					
				}
				return true;
			}

			private class InternalTimer : Timer
			{
				private Item m_Item;

				public InternalTimer( Item item, TimeSpan duration ) : base( duration )
				{
					Priority = TimerPriority.OneSecond;
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}

		private class InternalTarget : Target
		{
			private NaturalParalyzeFieldSpell m_Owner;

			public InternalTarget( NaturalParalyzeFieldSpell owner ) : base( 12, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is IPoint3D )
					m_Owner.Target( (IPoint3D)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
