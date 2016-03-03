using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells.Cleric
{
	public class RobeSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Robe Divin", "Deus Capia",
				212,
				9041
			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3.0); } }
		public override int RequiredTithing{ get{ return 50; } }
		public override double RequiredSkill{ get{ return 55.0; } }
		public override int RequiredMana{ get{ return 50; } }
        public override SpellCircle Circle { get { return SpellCircle.Fifth; } }
		public RobeSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				Item weap = new Robe( Caster );

				Caster.AddToBackpack( weap );
				Caster.SendMessage( "Les dieux vous donnent une Robe  Divine." );

				Caster.PlaySound( 0x212 );
				Caster.PlaySound( 0x206 );

				Effects.SendLocationParticles( EffectItem.Create( Caster.Location, Caster.Map, EffectItem.DefaultDuration ), 0x376A, 1, 29, 0x47D, 2, 9962, 0 );
				Effects.SendLocationParticles( EffectItem.Create( new Point3D( Caster.X, Caster.Y, Caster.Z - 7 ), Caster.Map, EffectItem.DefaultDuration ), 0x37C4, 1, 29, 0x47D, 2, 9502, 0 );
			}
		}


	public class Robe : BaseArmor
	{
			private Mobile m_Owner;
			
			private Timer m_Timer;

		public override int BasePhysicalResistance{ get{ return 0; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 0; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 0; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 95; } }
		public override int OldStrReq{ get{ return 60; } }

		public override int OldDexBonus{ get{ return -8; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }



			[Constructable]
			public Robe( Mobile owner ) : base( 0x1f03 )
			{
				m_Owner = owner;
				Weight = 10.0;
				//Layer = Layer.OneHanded;
				Hue = 0x5b;
				BlessedFor = owner;
				//Slayer = SlayerName.Silver;
				Name = "Robe Divine";
				ArmorAttributes.MageArmor = 1;				
				double Testpuissance = ((owner.Skills[SkillName.SpiritSpeak].Value)+ (owner.Skills[SkillName.Magery].Value) )/2 ; //Moyenne de spiritspeak et Evalint et magie

			if ( owner.Karma > 5000 )
			{
			
				if (Testpuissance > 120)
				{
					Hue = 2923;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 100)
				{
					Hue = 2123;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 90)
				{
					Hue = 2122;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 80)
				{
					Hue = 2121;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 70)
				{
					Hue = 2120;
					PuissanceAos(owner);
				}
				else 
				{
					Hue = 2119;
					PuissanceAos(owner);
				}	
			}
			else if ( owner.Karma < 5001 || owner.Karma > -5000 )
			{
			
				if (Testpuissance > 120)
				{
					Hue = 0x20;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 100)
				{
					Hue = 0x21;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 90)
				{
					Hue = 0x22;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 80)
				{
					Hue = 0x23;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 70)
				{
					Hue = 0x24;
					PuissanceAos(owner);
				}
				else 
				{
					Hue = 0x155;
					PuissanceAos(owner);
				}	
			}

			if ( owner.Karma < -4999 )
			{
			
				if (Testpuissance > 120)
				{
					Hue = 0x83a;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 100)
				{
					Hue = 0x839;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 90)
				{
					Hue = 0x838;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 80)
				{
					Hue = 0x837;
					PuissanceAos(owner);
				}
				else if (Testpuissance > 70)
				{
					Hue = 0x836;
					PuissanceAos(owner);
				}
				else 
				{
					Hue = 0x835;
					PuissanceAos(owner);
				}	
			}

				
				double time = ( owner.Skills[SkillName.SpiritSpeak].Value / 2.0 ) * DivineFocusSpell.GetScalar( owner );
				int time2 = (int)time;
				m_Timer = new RobeTimer( this, time2 );

				m_Timer.Start();
			}

		public void PuissanceAos(Mobile from)
		{
			double Moyenne = ((from.Skills[SkillName.SpiritSpeak].Value)+ (from.Skills[SkillName.Magery].Value) )/2 ;
			double x = (Moyenne * 0.15) + 1;  // calcul pour reflection degat compris entre 5% et 20% suivant le niveau du gars
			PhysicalBonus = FireBonus = ColdBonus = PoisonBonus = EnergyBonus = Attributes.ReflectPhysical = (int)x; 
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

			public void Remove()
			{
				m_Owner.SendMessage( "Votre Robe disparait." );
				if(m_Timer != null)
				{
					if (m_Timer.Running)
						m_Timer.Stop();
				}
				Delete();
			}

			public Robe( Serial serial ) : base( serial )
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
				
				m_Timer = new RobeTimer( this, 0 );
				m_Timer.Start();
			}
		}

		private class RobeTimer : Timer
		{
			private Robe m_Robe;


			public RobeTimer( Robe robe, int time ) : base( TimeSpan.FromMinutes (time))
			{
				m_Robe = robe;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Robe.Remove();
			}
		}
	}
}
