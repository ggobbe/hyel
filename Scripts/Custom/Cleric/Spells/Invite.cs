using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server;
using Server.Items;

namespace Server.Spells.Cleric
{
	public class InviteSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Invitate Corpus", "Deus Sancti",
				423,
				9031

			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
		public override int RequiredTithing{ get{ return 80; } }
		public override double RequiredSkill{ get{ return 10.0; } }
		public override int RequiredMana{ get{ return 15; } }
        public override SpellCircle Circle { get { return SpellCircle.First; } }
		public InviteSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( Server.Misc.WeightOverloading.IsOverloaded(Caster) )
			{
				Caster.SendLocalizedMessage(502359, "", 0x22 );  // Trop charg pour lancer le sort
				return false;
			}
			return true;
		}

		public override void OnCast ()
		{
			Caster.Target = new InternalTarget (this);
		}

		public  void Target ( Mobile m )
		{
			 Map map = m.Map;           			
			if (!Caster.CanSee (m))
			{
				Caster.SendLocalizedMessage (500237); // La cible n'est pas visible
			}
			/*else if (m == Caster) // Si la cible est lui meme
			{
			}*/
			else if (!Caster.Alive) // Si le lanceur est mort :p
			{
			}
			else if (!m.Alive) // Si la cible est morte
			{
			}
			else if(!Caster.InRange (m,3) ) // si la distance est superieure a 3 cases
			{

			}
			else if ( CheckSequence() )
			{
				Caster.PlaySound( 0x212 );
				Caster.PlaySound( 0x206 );

				Effects.SendLocationParticles( EffectItem.Create( Caster.Location, Caster.Map, EffectItem.DefaultDuration ), 0x376A, 1, 29, 0x47D, 2, 9962, 0 );
				Effects.SendLocationParticles( EffectItem.Create( new Point3D( Caster.X, Caster.Y, Caster.Z - 7 ), Caster.Map, EffectItem.DefaultDuration ), 0x37C4, 1, 29, 0x47D, 2, 9502, 0 );
				m.Map = Map.Felucca ;
				// mettre ici la destination, les sons et les anim diverse 
				m.Location = new Point3D (5378,1813,6);


			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private InviteSpell m_Lanceur;

			public InternalTarget ( InviteSpell Lanceur) : base (12,true,TargetFlags.None)
			{
				m_Lanceur = Lanceur;
			}

			protected override void OnTarget (Mobile from, object cible)
			{
				if (cible is PlayerMobile)
					{
						m_Lanceur.Target ((PlayerMobile)cible);
					}
			}

			protected override void OnTargetFinish (Mobile from)
			{
				m_Lanceur.FinishSequence();
			}
		}

	}
}
