using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Items;

namespace Server.Spells.Druid
{
    public class Somnispell : DruidSpell
	{
		private SleepingBody m_Body;
		private bool m_Blessed;
		private static SpellInfo m_Info = new SpellInfo(
				"Somnis", "En Vos Somnis ",
				212,
				9041,
            Reagent.DestroyingAngel
			);
        public override SpellCircle Circle { get { return SpellCircle.Fourth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
	      public override double RequiredSkill{ get{ return 80.0; } }
	      public override int RequiredMana{ get{ return 20; } }
		public override bool BlocksMovement{ get{ return false; } }

		public Somnispell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
			else if ( m.Player )
			{
				Caster.SendMessage("Vous ne pouvez pas viser un humain"); // Target can not be seen.
			}
			else if ( ( m.Str + m.Dex + m.Int ) > 400 )
			{
				Caster.SendMessage("Vous n'etes pas assez puissant pour ce monstre"); // Target can not be seen.
			}


			else if ( CheckBSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );
	if(this.Scroll!=null)
				Scroll.Consume();
				Effects.SendLocationParticles( EffectItem.Create( new Point3D( m.X, m.Y, m.Z + 16 ), Caster.Map, EffectItem.DefaultDuration ), 0x376A, 10, 15, 5045 );
				m.PlaySound( 0x3C4 );

				m.Hidden = true;
				m.Frozen=true;
				m.Squelched=true;
			
				m_Blessed=m.Blessed;
				m.Blessed=true;
				SleepingBody body = new SleepingBody(m, m_Blessed);
				body.Map=m.Map;
				body.Location=m.Location;
				m_Body=body;
				m.Z-=100;
				m_Body.AddItem(new Shirt());
				CopyFromLayer(m, m_Body, Layer.FirstValid);
CopyFromLayer(m, m_Body, Layer.TwoHanded);
CopyFromLayer(m, m_Body, Layer.Shoes);
CopyFromLayer(m, m_Body, Layer.Pants);
CopyFromLayer(m, m_Body, Layer.Shirt);
CopyFromLayer(m, m_Body, Layer.Helm);
CopyFromLayer(m, m_Body, Layer.Gloves);
CopyFromLayer(m, m_Body, Layer.Ring);
CopyFromLayer(m, m_Body, Layer.Neck);
CopyFromLayer(m, m_Body, Layer.Hair);
CopyFromLayer(m, m_Body, Layer.Waist);
CopyFromLayer(m, m_Body, Layer.InnerTorso);
CopyFromLayer(m, m_Body, Layer.Bracelet);
CopyFromLayer(m, m_Body, Layer.FacialHair);
CopyFromLayer(m, m_Body, Layer.MiddleTorso);
CopyFromLayer(m, m_Body, Layer.Earrings);
CopyFromLayer(m, m_Body, Layer.Arms);
CopyFromLayer(m, m_Body, Layer.Cloak);
CopyFromLayer(m, m_Body, Layer.OuterTorso);
CopyFromLayer(m, m_Body, Layer.OuterLegs);
CopyFromLayer(m, m_Body, Layer.LastUserValid);
				
			
				m.SendMessage("Vous tombez de sommeille");

				RemoveTimer( m );

				TimeSpan duration = TimeSpan.FromSeconds( Caster.Skills[SkillName.Magery].Value * 1.5 ); // 120% of magery

				Timer t = new InternalTimer( m, duration, m_Body, m_Blessed );

				m_Table[m] = t;

				t.Start();
			}

			FinishSequence();
		}
	private void CopyFromLayer( Mobile from, SleepingBody sleeping, Layer layer ) 
      {
      	Item worn = from.FindItemOnLayer(layer);
      	if (worn != null)
     	{
     		
    	Item cloth = new Item(); 
     		cloth.ItemID=worn.ItemID;
     cloth.Hue = worn.Hue;
      		cloth.Layer=layer;
      	cloth.ItemID = worn.ItemID;
    
     sleeping.AddItem(cloth); 
    	}
      	
      	
      	
     
      }
		private static Hashtable m_Table = new Hashtable();

		public static void RemoveTimer( Mobile m )
		{
			Timer t = (Timer)m_Table[m];

			if ( t != null )
			{
				t.Stop();
				m_Table.Remove( m );
			}
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private Item m_Body;
			private bool m_Blessed;

			public InternalTimer( Mobile m, TimeSpan duration, Item body, bool blessed ) : base( duration )
			{
				m_Mobile = m;
				m_Body=body;
			}

			protected override void OnTick()
			{
				m_Mobile.RevealingAction();
				m_Mobile.Frozen=false;
				m_Mobile.Squelched=false;
				m_Mobile.Blessed=m_Blessed;
				
			
				if(m_Body!=null)
				{
					m_Body.Delete();
				m_Mobile.SendMessage("Vous vous levez!");
					m_Mobile.Z=m_Body.Z;
					m_Mobile.Animate(21, 6, 1, false, false, 0);
				}
				RemoveTimer( m_Mobile );
			}
		}

		public class InternalTarget : Target
		{
			private Somnispell m_Owner;

			public InternalTarget( Somnispell owner ) : base( 12, false, TargetFlags.Beneficial )
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
