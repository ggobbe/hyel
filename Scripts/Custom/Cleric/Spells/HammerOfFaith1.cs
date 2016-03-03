using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells.Cleric
{
	public class HammerOfFaithSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Marteau Divin", "Deus Arma",
				212,
				9041
			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3.0); } }
		public override int RequiredTithing{ get{ return 20; } }
		public override double RequiredSkill{ get{ return 45.0; } }
		public override int RequiredMana{ get{ return 15; } }
        public override SpellCircle Circle { get { return SpellCircle.Fifth; } }
		public HammerOfFaithSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				Item weap = new HammerOfFaith( Caster );

				Caster.AddToBackpack( weap );
				Caster.SendMessage( "Les dieux vous donnent une Masse Divine." );

				Caster.PlaySound( 0x212 );
				Caster.PlaySound( 0x206 );

				Effects.SendLocationParticles( EffectItem.Create( Caster.Location, Caster.Map, EffectItem.DefaultDuration ), 0x376A, 1, 29, 0x47D, 2, 9962, 0 );
				Effects.SendLocationParticles( EffectItem.Create( new Point3D( Caster.X, Caster.Y, Caster.Z - 7 ), Caster.Map, EffectItem.DefaultDuration ), 0x37C4, 1, 29, 0x47D, 2, 9502, 0 );
			}
		}

		[FlipableAttribute( 0xf5c, 0xf5d )]
		private class HammerOfFaith : BaseBashing
		{
			private Mobile m_Owner;

			private Timer m_Timer;

			public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
			public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.CrushingBlow; } }

			public override int AosStrengthReq{ get{ return 70; } }
			public override int AosMinDamage{ get{ return 20; } }
			public override int AosMaxDamage{ get{ return 22; } }
			public override int AosSpeed{ get{ return 45; } }

			public override int OldStrengthReq{ get{ return 40; } }
			public override int OldMinDamage{ get{ return 8; } }
			public override int OldMaxDamage{ get{ return 36; } }
			public override int OldSpeed{ get{ return 40; } }

			public override int InitMinHits{ get{ return 20; } }
			public override int InitMaxHits{ get{ return 30; } }

			public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash1H; } }

			[Constructable]
			public HammerOfFaith( Mobile owner ) : base( 0xF5d )
			{
				m_Owner = owner;
				Weight = 10.0;
				Layer = Layer.OneHanded;

				BlessedFor = owner;
				Slayer = SlayerName.Silver;
				Name = "Masse Divine";
				double Testpuissance = ((owner.Skills[SkillName.SpiritSpeak].Value)+ (owner.Skills[SkillName.Magery].Value) )/2 ; //Moyenne de spiritspeak et Evalint et magie

			if ( owner.Karma > 5000 )
			{
				if (Core.AOS)
				{
					if (Testpuissance > 125)
					{
						Hue = 2923;
						Speed = AosVitesse(owner);
						WeaponAttributes.HitFireball = 40;
						Cursed = true;
						Consecrated = true;		
					}
					else if (Testpuissance > 100)
					{
						Hue = 2123;
						Speed = AosVitesse(owner);
						WeaponAttributes.HitFireball = 20;
					}
					else if (Testpuissance > 90)
					{
						Hue = 2122;
						Speed = AosVitesse(owner);
						WeaponAttributes.HitFireball = 10;						
					}
					else if (Testpuissance > 80)
					{
						Hue = 2121;
						Speed = AosVitesse(owner);
					}
					else if (Testpuissance > 70)
					{
						Hue = 2120;
						Speed = AosVitesse(owner);
					}
					else 
					{
						Hue = 2119;
						Speed = AosVitesse(owner);
					}
				}
				else
				{
					if (Testpuissance > 125)
					{
						Hue = 2923;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 100)
					{
						Hue = 2123;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 90)
					{
						Hue = 2122;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 80)
					{
						Hue = 2121;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 70)
					{
						Hue = 2120;
						Speed = OldVitesse(owner);
					}
					else 
					{
						Hue = 2119;
						Speed = OldVitesse(owner);
					}
				}
			}

			else if ( owner.Karma < 5001 || owner.Karma > -5000 )
			{
				if (Core.AOS)
				{
					if (Testpuissance > 125)
					{
						Hue = 0x20;
						Speed = AosVitesse(owner);
						WeaponAttributes.HitFireball = 40;
						Cursed = true;
						Consecrated = true;		
					}
					else if (Testpuissance > 100)
					{
						Hue = 0x21;
						Speed = AosVitesse(owner);
						WeaponAttributes.HitFireball = 20;
					}
					else if (Testpuissance > 90)
					{
						Hue = 0x22;
						Speed = AosVitesse(owner);
						WeaponAttributes.HitFireball = 10;
					}
					else if (Testpuissance > 80)
					{
						Hue = 0x23;
						Speed = AosVitesse(owner);
					}
					else if (Testpuissance > 70)
					{
						Hue = 0x24;
						Speed = AosVitesse(owner);
					}
					else 
					{
						Hue = 0x155;
						Speed = AosVitesse(owner);
					}
				}
				else
				{
					if (Testpuissance > 125)
					{
						Hue = 0x20;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 100)
					{
						Hue = 0x21;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 90)
					{
						Hue = 0x22;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 80)
					{
						Hue = 0x23;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 70)
					{
						Hue = 0x24;
						Speed = OldVitesse(owner);
					}
					else 
					{
						Hue = 0x155;
						Speed = OldVitesse(owner);
					}
				}
			}

			if ( owner.Karma < -4999 )
			{
				if (Core.AOS)
				{
					if (Testpuissance > 125)
					{
						Hue = 0x83a;
						Speed = AosVitesse(owner);
						WeaponAttributes.HitFireball = 40;
						Cursed = true;
						Consecrated = true;								
					}
					else if (Testpuissance > 100)
					{
						Hue = 0x839;
						Speed = AosVitesse(owner);
						WeaponAttributes.HitFireball = 20;
					}
					else if (Testpuissance > 90)
					{
						Hue = 0x838;
						Speed = AosVitesse(owner);
						WeaponAttributes.HitFireball = 10;
					}
					else if (Testpuissance > 80)
					{
						Hue = 0x837;
						Speed = AosVitesse(owner);
					}
					else if (Testpuissance > 70)
					{
						Hue = 0x836;
						Speed = AosVitesse(owner);
					}
					else 
					{
						Hue = 0x835;
						Speed = AosVitesse(owner);
					}
				}
				else
				{
					if (Testpuissance > 125)
					{
						Hue = 0x83a;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 100)
					{
						Hue = 0x839;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 90)
					{
						Hue = 0x838;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 80)
					{
						Hue = 0x837;
						Speed = OldVitesse(owner);
					}
					else if (Testpuissance > 70)
					{
						Hue = 0x836;
						Speed = OldVitesse(owner);
					}
					else 
					{
						Hue = 0x835;
						Speed = OldVitesse(owner);
					}
				}
			}

				double time = ( owner.Skills[SkillName.SpiritSpeak].Value / 3.0 ) * DivineFocusSpell.GetScalar( owner );
				int time2 = (int)time;
				m_Timer = new HammerTimer( this,time2);

				m_Timer.Start();
			}

            public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
           {
				phys = fire = cold = pois = chaos = direct = 0;
				nrgy = 100;
			}

			public override void OnDelete()
			{
				if ( m_Timer != null )
					m_Timer.Stop();

				base.OnDelete();
			}

			public override bool CanEquip( Mobile m )
			{
				if ( m != m_Owner )
					return false;

				return true;
			}

			public int AosVitesse(Mobile from) // Calcul de la vitesse pour la version AOS  minimum 36,  maximum 50 avec 150%magery et 100%spirit
			{
				double Moyenne = ((from.Skills[SkillName.SpiritSpeak].Value)+ (from.Skills[SkillName.Magery].Value) )/2 ;
				double x = (Moyenne * 0.15) + 32;
				return (int)x;
			}

			public int OldVitesse(Mobile from)
			{
				double y = AosVitesse(from) * 0.9 ; // // Calcul de la vitesse pour les anciennes versions ( AOSvitesse - 10%) 
				return (int)y;
			}

			public void Remove()
			{
				m_Owner.SendMessage( "Votre masse disparait." );
				if(m_Timer != null)
				{
					if (m_Timer.Running)
					m_Timer.Stop();
				}
				Delete();
			}

			public HammerOfFaith( Serial serial ) : base( serial )
			{
			}

			public override void Serialize( GenericWriter writer )
			{
				base.Serialize( writer );

				writer.Write( (int) 0 ); // version
				writer.Write( m_Owner );

			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );

				int version = reader.ReadInt();
				m_Owner = reader.ReadMobile();

				m_Timer = new HammerTimer( this,0);
				m_Timer.Start();
			}
		}

		private class HammerTimer : Timer
		{
			private HammerOfFaith m_Hammer;

			public HammerTimer( HammerOfFaith hammer, int time) : base( TimeSpan.FromMinutes (time))
			{
				
				m_Hammer = hammer;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Hammer.Remove();
			}
		}
	}
}
