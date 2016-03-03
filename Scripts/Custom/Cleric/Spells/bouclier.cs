using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells.Cleric
{
	public class BouclierSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Pavois Divin", "Deus Pavis",
				212,
				9041
			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3.0); } }
		public override int RequiredTithing{ get{ return 50; } }
		public override double RequiredSkill{ get{ return 70.0; } }
		public override int RequiredMana{ get{ return 50; } }
        public override SpellCircle Circle { get { return SpellCircle.Fifth; } }
		public BouclierSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				Item weap = new Bouclier( Caster );

				Caster.AddToBackpack( weap );
				Caster.SendMessage( "Les dieux vous donnent un Pavois Divin." );

				Caster.PlaySound( 0x212 );
				Caster.PlaySound( 0x206 );

				Effects.SendLocationParticles( EffectItem.Create( Caster.Location, Caster.Map, EffectItem.DefaultDuration ), 0x376A, 1, 29, 0x47D, 2, 9962, 0 );
				Effects.SendLocationParticles( EffectItem.Create( new Point3D( Caster.X, Caster.Y, Caster.Z - 7 ), Caster.Map, EffectItem.DefaultDuration ), 0x37C4, 1, 29, 0x47D, 2, 9502, 0 );
			}
		}
[FlipableAttribute( 7108, 7109 )]
	public class Bouclier : BaseShield
	{

		private Mobile m_Owner;

		private Timer m_Timer;

		public override int BasePhysicalResistance{ get{ return 0; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 0; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 0; } }

		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 125; } }

		public override int AosStrReq{ get{ return 95; } }

		public override int ArmorBase{ get{ return 30; } }



			[Constructable]
			public Bouclier( Mobile owner ) : base( 0x1BC4 )
			{
				m_Owner = owner;
				Weight = 10.0;
				//Layer = Layer.OneHanded;
				Hue = 0x5b;
				BlessedFor = owner;
				//Slayer = SlayerName.Silver;
				Name = "Bouclier Divin";
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
				

				double time = ( owner.Skills[SkillName.SpiritSpeak].Value / 3.0 ) * DivineFocusSpell.GetScalar( owner );
				int time2 = (int)time;
				m_Timer = new BouclierTimer( this,time2);

				m_Timer.Start();
			}

	public void PuissanceAos(Mobile from)
	{
		double Moyenne = ((from.Skills[SkillName.SpiritSpeak].Value)+ (from.Skills[SkillName.Magery].Value) )/2 ;
		double x = (Moyenne * 0.2) + 6;  // calcul pour resistance comprises entre 10% et 30 % 
		double x1 = (Moyenne * 0.15) + 1;  // calcul pour reflectiondegat compris entre 5% et 20%
		PhysicalBonus = FireBonus = ColdBonus = PoisonBonus = EnergyBonus = (int)x; 
		Attributes.ReflectPhysical = (int) x1;
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
				m_Owner.SendMessage( "Votre Bouclier disparait." );
				if(m_Timer != null)
				{
					if (m_Timer.Running)
						m_Timer.Stop();
				}
				Delete();
			}

			public Bouclier( Serial serial ) : base( serial )
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

				m_Timer = new BouclierTimer( this, 0 );
				m_Timer.Start();
			}
		}

		private class BouclierTimer : Timer
		{
			private Bouclier m_Bouclier;

			public BouclierTimer( Bouclier bouclier, int time ) : base( TimeSpan.FromMinutes (time))
			{
				m_Bouclier = bouclier;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Bouclier.Remove();
			}
		}
	}
}
