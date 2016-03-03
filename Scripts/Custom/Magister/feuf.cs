using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells.Magister
{
    public class feuf : MagisterSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Feu Follet", "Orh Flam",
				212,
				9041,
				Reagent.MandrakeRoot				
			);
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
		//public override int RequiredTithing{ get{ return 5; } }
		public override double RequiredSkill{ get{ return 30.0; } }
		public override int RequiredMana{ get{ return 5; } }
		public override bool BlocksMovement{ get{ return false; } }


		public feuf( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			
				return true;

		
		}

		private static Hashtable m_Table = new Hashtable();
public static void DrawFirework( Mobile from )
      {
         int[] intEffectID = {14138,14154,14201};

         Point3D EffectLocation = new Point3D( ( from.X + Utility.Random( -4, 8 ) ), ( from.Y + Utility.Random( -4, 8 ) ), from.Z + 20 );
      //	Effects.SendMovingParticles( from, EffectLocation, 0x36E4, 5, 0, false, false, 3006, 4006, 9501, 1, 0, EffectLayer.RightHand, 0x100 );
		IEntity to = new Entity( Serial.Zero,EffectLocation,from.Map);
		                        from.MovingParticles( to, 0x36E4, 5, 0, false, false, 3006, 4006, 0 );
      	Timer t = new InternalTimer( from, EffectLocation, intEffectID);

				m_Table[from] = t;

				t.Start();
        }
      	private class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private Point3D EffectLocation;
			private int[] intEffectID;
		

			public InternalTimer( Mobile m, Point3D local, int[] fwoosh) : base( TimeSpan.FromSeconds( 0.6) )
			{
				m_Mobile = m;
				EffectLocation=local;
				intEffectID=fwoosh;
			}

			protected override void OnTick()
			{
			Effects.SendLocationEffect( EffectLocation, m_Mobile.Map, intEffectID[ Utility.Random( 0, 3 ) ], 70, (int)( 5 * Utility.Random( 0, 20 ) ) + 3, 2 );
       switch ( Utility.Random( 3 ) )
       		  {
       		  case 0: m_Mobile.PlaySound(0x11C); break;
       		  case 1: m_Mobile.PlaySound(0x11E); break;
       		  case 2: m_Mobile.PlaySound(0x11D); break;
       		  }
			}
		}
		public override void OnCast()
		{
			if(this.Scroll!=null)
				Scroll.Consume();
				DrawFirework( Caster );
			if (Caster.Skills[SkillName.Magery].Base>=110)
         DrawFirework( Caster );
        if (Caster.Skills[SkillName.Magery].Base>=100)
        DrawFirework( Caster );
			if (Caster.Skills[SkillName.Magery].Base>=75)
         DrawFirework( Caster );
			if (Caster.Skills[SkillName.Magery].Base>=50)
         DrawFirework( Caster );
			if (Caster.Skills[SkillName.Magery].Base>=25)
         DrawFirework( Caster );

        		FinishSequence();
			
		
		}
	}
}
