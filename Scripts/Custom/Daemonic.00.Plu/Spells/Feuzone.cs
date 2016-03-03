using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
namespace Server.Spells.Daemonic
{
    public class Feuzone : DaemonicSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"feu zone", "Horrrr's'Sheerr",
				212,
				9041,
				Reagent.Katyl,
				Reagent.Onax	
			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
		public override double RequiredSkill{ get{ return 120.0; } }
		public override int RequiredMana{ get{ return 70; } }
		//public override int RequiredTithing{ get{ return 5; } }
		//public override int MantraNumber{ get{ return 1060724; } } // Augus Luminos
		public override bool BlocksMovement{ get{ return true; } }
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
		public Feuzone( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool DelayedDamage{ get{ return false; } }

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				ArrayList targets = new ArrayList();

				foreach ( Mobile m in Caster.GetMobilesInRange( 5 ) )
				{
					if ( Caster != m && SpellHelper.ValidIndirectTarget( Caster, m ) && Caster.CanBeHarmful( m, false ) )
						targets.Add( m );
				}

				Caster.PlaySound( 0x207 );
				//m.PlaySound( 0x207 );

				//IEntity from = new Entity( Serial.Zero, new Point3D( m.X + 10, m.Y, m.Z + 20 ), m.Map );
				IEntity from = new Entity( Serial.Zero, new Point3D( Caster.X + 0, Caster.Y + 0, Caster.Z + 0 ), Caster.Map );

				IEntity to2 = new Entity( Serial.Zero, new Point3D( Caster.X + 0, Caster.Y + 10, Caster.Z + 10 ), Caster.Map );
				IEntity to3 = new Entity( Serial.Zero, new Point3D( Caster.X - 10, Caster.Y + 0, Caster.Z + 10 ), Caster.Map );
				IEntity to4 = new Entity( Serial.Zero, new Point3D( Caster.X, Caster.Y - 10, Caster.Z + 10 ), Caster.Map );
				IEntity to = new Entity( Serial.Zero, new Point3D( Caster.X + 10, Caster.Y, Caster.Z + 10), Caster.Map );
				IEntity to5 = new Entity( Serial.Zero, new Point3D( Caster.X - 10, Caster.Y + 10, Caster.Z + 10), Caster.Map );
				IEntity to6 = new Entity( Serial.Zero, new Point3D( Caster.X + 10, Caster.Y + 10, Caster.Z + 10 ), Caster.Map );
				IEntity to7 = new Entity( Serial.Zero, new Point3D( Caster.X + 10, Caster.Y - 10, Caster.Z + 10 ), Caster.Map );
				IEntity to8 = new Entity( Serial.Zero, new Point3D( Caster.X - 10, Caster.Y - 10, Caster.Z + 10), Caster.Map );

			//	Caster.MovingParticles( m, 0x37C4, 5, 5, false, true, 132, 2, 0x37C4, 4019, 0x160, EffectLayer.LeftFoot, 0 );//3 couleur

//void MovingParticles( IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, EffectLayer layer, int unknown )


				Effects.SendMovingParticles( from, to, 14000, 8, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to2, 14013, 8, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to3, 14026, 8, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to4, 14078, 8, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to5, 14000, 8, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to6, 14013, 8, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to7, 14026, 8, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to8, 14078, 8, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to8, 14078, 5, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to7, 14000, 5, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to6, 14013, 5, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to5, 14026, 5, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to4, 14000, 5, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to3, 14013, 5, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to2, 14026, 5, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 14013, 5, 9, false, true, 0, 5, 4963, 1, 0, EffectLayer.LeftFoot, 0x100 );





				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];

					//int damage = 25;

			            double damage = ( ( Caster.Skills[SkillName.Necromancy].Value + (Caster.Skills[SkillName.SpiritSpeak].Value)) /2.5); //Utility.Random( 27, 50 ); metre * 4 en relle
					damage += ((Caster.Karma / 1200)* -1);
				if ( m is BaseCreature )
					damage = damage * 1.2;
					/*if ( damage < 2 )
						damage = 2;
					else if ( damage > 50 )
						damage = 50;*/

					Caster.DoHarmful( m );
					SpellHelper.Damage( this, m, damage, 0, 100, 0, 0, 0 );
				}
			}

			FinishSequence();
		}
	}
}
