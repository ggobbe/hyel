using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
namespace Server.Spells.Magister
{
	public class seisme : MagisterSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Seisme", "Terra Or Kam",
				212,
				9041,
				Reagent.Katyl,
				Reagent.Onax	
			);
 
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3.0); } }
		public override double RequiredSkill{ get{ return 135.0; } }
		public override int RequiredMana{ get{ return 70; } }
		//public override int RequiredTithing{ get{ return 10; } }
		//public override int MantraNumber{ get{ return 1060724; } } // Augus Luminos
		public override bool BlocksMovement{ get{ return false; } }

		public seisme( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool DelayedDamage{ get{ return false; } }

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				ArrayList targets = new ArrayList();

				foreach ( Mobile m in Caster.GetMobilesInRange( 7 ) )
				{
					if ( Caster != m && SpellHelper.ValidIndirectTarget( Caster, m ) && Caster.CanBeHarmful( m, false ) )
						targets.Add( m );
				}

				Caster.PlaySound( 0x207 );
				//m.PlaySound( 0x207 );

				//IEntity from = new Entity( Serial.Zero, new Point3D( m.X + 10, m.Y, m.Z + 20 ), m.Map );
				IEntity from = new Entity( Serial.Zero, new Point3D( Caster.X + 0, Caster.Y + 0, Caster.Z + 0 ), Caster.Map );

				IEntity to2 = new Entity( Serial.Zero, new Point3D( Caster.X + 0, Caster.Y + 5, Caster.Z + 5 ), Caster.Map );
				IEntity to3 = new Entity( Serial.Zero, new Point3D( Caster.X - 5, Caster.Y + 0, Caster.Z + 5 ), Caster.Map );
				IEntity to4 = new Entity( Serial.Zero, new Point3D( Caster.X, Caster.Y - 5, Caster.Z + 5 ), Caster.Map );
				IEntity to = new Entity( Serial.Zero, new Point3D( Caster.X + 5, Caster.Y, Caster.Z + 5), Caster.Map );
				IEntity to5 = new Entity( Serial.Zero, new Point3D( Caster.X - 5, Caster.Y + 5, Caster.Z + 5), Caster.Map );
				IEntity to6 = new Entity( Serial.Zero, new Point3D( Caster.X + 5, Caster.Y + 5, Caster.Z + 5 ), Caster.Map );
				IEntity to7 = new Entity( Serial.Zero, new Point3D( Caster.X + 5, Caster.Y - 5, Caster.Z + 5 ), Caster.Map );
				IEntity to8 = new Entity( Serial.Zero, new Point3D( Caster.X - 5, Caster.Y - 5, Caster.Z + 5), Caster.Map );

			//	Caster.MovingParticles( m, 0x37C4, 5, 5, false, true, 132, 2, 0x37C4, 4019, 0x160, EffectLayer.LeftFoot, 0 );//3 couleur

				/*Effects.SendMovingParticles( from, to, 4952, 8, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to2, 4962, 8, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to3, 4954, 8, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to4, 4948, 8, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to5, 4952, 8, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to6, 4962, 8, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to7, 4954, 8, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to8, 4948, 8, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );*/
				Effects.SendMovingParticles( from, to8, 4952, 5, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to7, 4962, 5, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to6, 4954, 5, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to5, 4948, 5, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to4, 4952, 5, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to3, 4962, 5, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to2, 4954, 5, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 4948, 5, 0, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );





				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];

					//int damage = 25;

			            double damage = ( ( Caster.Skills[SkillName.Magery].Value + (Caster.Skills[SkillName.EvalInt].Value)) /2.5); //Utility.Random( 27, 50 ); metre * 4 en relle
					//damage += (Caster.Karma / 600);
				if ( m is BaseCreature )
					damage = damage * 2;
					
					else if ( m is PlayerMobile )
						damage = 0;

					Caster.DoHarmful( m );
					SpellHelper.Damage( this, m, damage, 100, 0, 0, 0, 0 );
				}
			}

			FinishSequence();
		}
	}
}
