using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Magister
{
    public class meteorz : MagisterSpell  // pas fini
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Apocalypse", "Ka Vas Or Tam Flam",
				212,
				9041,
				Reagent.Onax,
				Reagent.Nightshade,
				Reagent.Bloodmoss,
				Reagent.Katyl								
			);
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
		private static Hashtable m_Table = new Hashtable();
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(4.0); } }
		//public override int RequiredTithing{ get{ return 1; } }
		public override double RequiredSkill{ get{ return 150.0; } }
		public override int RequiredMana{ get{ return 125; } }
		public override bool BlocksMovement{ get{ return true; } }		
      public meteorz( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
      {
      }

      public override void GetCastSkills( out double min, out double max )
      {
         min = RequiredSkill;
         max = RequiredSkill + 10.0;
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

            if ( p is Item )
               p = ((Item)p).GetWorldLocation();

            double damage = ( ( Caster.Skills[SkillName.Magery].Value + (Caster.Skills[SkillName.SpiritSpeak].Value)) *4 ); //Utility.Random( 27, 50 ); metre * 4 en relle
            Caster.Skills[SkillName.Magery].Base =( Caster.Skills[SkillName.Magery].Base - 0.2);



            ArrayList targets = new ArrayList();

            IPooledEnumerable eable = Caster.Map.GetMobilesInRange( new Point3D( p ), 1 + (int)(Caster.Skills[SkillName.EvalInt].Value / 10.0) );

            foreach ( Mobile m in eable )
            {
               if ( SpellHelper.ValidIndirectTarget( Caster, m ) && Caster.CanBeHarmful( m, false ) )
                  targets.Add( m );
            }

            eable.Free();

            if ( targets.Count > 0 )
            {
               //damage /= targets.Count; // ~ divides damage between targets, kinda sux

               for ( int i = 0; i < targets.Count; ++i )
               {
                  Mobile m = (Mobile)targets[i];

                  double toDeal = damage;

                  if (CheckResisted (m))
                  {
                      toDeal *= 0.7;

                     m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
                  }
		//double damage = ( ( Caster.Skills[SkillName.Magery].Value + (Caster.Skills[SkillName.SpiritSpeak].Value)) *2 );

                  Caster.DoHarmful( m );
                  SpellHelper.Damage( this, m, toDeal, 50, 100, 0, 0, 0 );


				Caster.PlaySound( 0x207 );
				m.PlaySound( 0x207 );
				//Caster.PlaySound( soundID );
				Caster.FixedParticles( 0x3779, 1, 30, 9964, 3, 3, EffectLayer.Waist );
				//int boum = Caster.FixedParticles( 0x3779, 1, 30, 9964, 3, 3, EffectLayer.Waist );


				IEntity from = new Entity( Serial.Zero, new Point3D( m.X, m.Y, m.Z + 100 ), m.Map );
				IEntity to = new Entity( Serial.Zero, new Point3D( m.X, m.Y, m.Z + 2), m.Map );
				Effects.SendMovingParticles( from, to, 0x1358, 7, 0, true, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 0x1358, 7, 0, false, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33

				Effects.SendMovingParticles( from, to, 4964, 7, 0, true, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 4973, 6, 0, true, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 6004, 5, 0, true, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33
				Effects.SendMovingParticles( from, to, 4963, 4, 0, true, true, 132, 5, 14089, 14089, 0x207, EffectLayer.LeftFoot, 0x100 );//coul 33
				Caster.PlaySound( 0x207 );
				m.PlaySound( 0x207 );		

				//SendMovingParticles( IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, EffectLayer layer, int unknown )
		

				Effects.SendMovingParticles( from, to, 14089, 7, 0, false, true, 0, 3, 14000, 14000, 0x207, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14027, 7, 0, true, true, 132, 3, 14013, 14013, 0x207, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 6, 0, false, true, 0, 3, 14000, 14000, 0x207, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14000, 6, 0, true, true, 0, 3, 14078, 14078, 0x207, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14027, 5, 0, true, true, 132, 3, 14089, 14089, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 5, 0, false, true, 0, 3, 14000, 14000, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 4, 0, false, true, 132, 3, 14078, 14078, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14000, 5, 0, true, true, 0, 3, 14089, 14089, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14027, 3, 0, false, true, 132, 3, 14013, 14013, 0, EffectLayer.LeftFoot, 0x100 );
				Effects.SendMovingParticles( from, to, 14089, 3, 0, true, true, 0, 3, 14089, 14089, 0, EffectLayer.LeftFoot, 0x100 );

				Caster.PlaySound( 0x207 );
				m.PlaySound( 0x207 );
			Effects.SendLocationEffect( new Point3D( m.X - 3, m.Y - 2, m.Z  ), m.Map, 0x1CF9, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 3, m.Y - 1, m.Z  ), m.Map, 0x1CF8, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 3, m.Y + 0, m.Z  ), m.Map, 0x1CF7, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 3, m.Y + 1, m.Z  ), m.Map, 0x1CF6, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 3, m.Y + 2, m.Z  ), m.Map, 0x1CF5, 30 );

			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y -3, m.Z  ), m.Map, 0x1CFB, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y - 2, m.Z  ), m.Map, 0x1CFA, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y - 1, m.Z  ), m.Map, 0x1D09, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y + 0, m.Z  ), m.Map, 0x1D08, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y + 1, m.Z  ), m.Map, 0x1D07, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 2, m.Y + 2, m.Z  ), m.Map, 0x1CF4, 30 );

			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y - 3, m.Z  ), m.Map, 0x1CFC, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y - 2, m.Z  ), m.Map, 0x1D0A, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y - 1, m.Z  ), m.Map, 0x1D11, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y + 0, m.Z  ), m.Map, 0x1D10, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y + 1, m.Z  ), m.Map, 0x1D06, 30 );
			Effects.SendLocationEffect( new Point3D( m.X - 1, m.Y + 2, m.Z  ), m.Map, 0x1CF3, 30 );

			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y - 3, m.Z  ), m.Map, 0x1CFD, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y - 2, m.Z  ), m.Map, 0x1D0B, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y - 1, m.Z  ), m.Map, 0x1D12, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y + 0, m.Z  ), m.Map, 0x1D0F, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y + 1, m.Z  ), m.Map, 0x1D05, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 0, m.Y + 2, m.Z  ), m.Map, 0x1CF2, 30 );

			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y - 3, m.Z  ), m.Map, 0x1CFE, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y - 2, m.Z  ), m.Map, 0x1D0C, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y - 1, m.Z  ), m.Map, 0x1D0D, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 0, m.Z  ), m.Map, 0x1D0E, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z  ), m.Map, 0x1D04, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 2, m.Z  ), m.Map, 0x1CF1, 30 );

			Effects.SendLocationEffect( new Point3D( m.X + 2, m.Y - 3, m.Z  ), m.Map, 0x1CFF, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 2, m.Y - 2, m.Z  ), m.Map, 0x1D00, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 2, m.Y - 1, m.Z  ), m.Map, 0x1D01, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 2, m.Y + 0, m.Z  ), m.Map, 0x1D02, 30 );
			Effects.SendLocationEffect( new Point3D( m.X + 2, m.Y + 1, m.Z  ), m.Map, 0x1D03, 30 );


               }
            }
         }

         FinishSequence();
      }

      private class InternalTarget : Target
      {
         private meteorz m_Owner;

         public InternalTarget( meteorz owner ) : base( 12, true, TargetFlags.None )
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
