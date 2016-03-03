using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Engines.PartySystem;
namespace Server.Spells.Cleric
{
	public class MassoinSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Pluie Divine", "Todas Vitale",
				212,
				9041
			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2.0); } }
		public override int RequiredTithing{ get{ return 20; } }
		public override double RequiredSkill{ get{ return 70.0; } }
		public override int RequiredMana{ get{ return 40; } }
        public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
		public MassoinSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
         else if ( CheckSequence() )
         {
            SpellHelper.Turn( Caster, p );

            SpellHelper.GetSurfaceTop( ref p );

            ArrayList targets = new ArrayList();

	Map map = Caster.Map;
	
	if ( map != null )	
 	{
            IPooledEnumerable eable = Caster.Map.GetMobilesInRange( new Point3D( p ), Core.AOS ? 5 : 6 );

            foreach ( Mobile m in eable )//em
            {
               if ( Caster.CanBeBeneficial( m, false ) )
                  targets.Add( m );
            }

            eable.Free();
    	 }

				if ( Core.AOS )
				{
					Party party = Party.Get( Caster );

					for ( int i = 0; i < targets.Count; ++i )
					{
						Mobile m = (Mobile)targets[i];

						if ( m == Caster || (party != null && party.Contains( m )) )
						{
							Caster.DoBeneficial( m );
                     					int toHeal = (int)(Caster.Skills[SkillName.SpiritSpeak].Value * 1.0);
                   					  toHeal += Utility.Random( 1, 10 );

                    					 m.Heal( toHeal );							
							m.PlaySound( 0xF6 );
							m.PlaySound( 0x1F7 );
							m.FixedParticles( 0x375a, 1, 30, 0x550, 13, 3, EffectLayer.Head );
						}
					}
				}
		else
		{
            Effects.PlaySound( p, Caster.Map, 0x11 );

            int val = (int)(Caster.Skills[SkillName.SpiritSpeak].Value * 1.0);

            if ( targets.Count > 0 )
            {
               for ( int i = 0; i < targets.Count; ++i )
               {
                  Mobile m = (Mobile)targets[i];//em

                  if ( m.BeginAction( typeof( MassoinSpell ) ) )
                  {
                     Caster.DoBeneficial( m );
				m.PlaySound( 0xF6 );
				m.PlaySound( 0x1F7 );
				m.FixedParticles( 0x375a, 1, 30, 0x550, 13, 3, EffectLayer.Head );

                     int toHeal = (int)(Caster.Skills[SkillName.SpiritSpeak].Value * 1.0);
                     toHeal += Utility.Random( 1, 10 );

                     m.Heal( toHeal );

                     new InternalTimer( m, Caster, val ).Start();
				m.PlaySound( 0xF6 );
				m.PlaySound( 0x1F7 );
				m.FixedParticles( 0x375a, 1, 30, 0x550, 13, 3, EffectLayer.Head );
                  }
               }
            }
         }
	}
         FinishSequence();
      }

      private class InternalTimer : Timer
      {
         private Mobile m_Owner;
         private int m_Val;

         public InternalTimer( Mobile target, Mobile caster, int val ) : base( TimeSpan.FromSeconds( 0 ) )
         {
            double time = caster.Skills[SkillName.Magery].Value / 100.0;
            if ( time > 300 )
               time = 300;
            Delay = TimeSpan.FromSeconds( time );
            Priority = TimerPriority.TwoFiftyMS;

            m_Owner = target;
            m_Val = val;
         }

         protected override void OnTick()
         {
            m_Owner.EndAction( typeof( MassoinSpell ) );
           // m_Owner.Str -= m_Val;
           
         }
      }

      private class InternalTarget : Target
      {
         private MassoinSpell m_Owner;

         public InternalTarget( MassoinSpell owner ) : base( 12, true, TargetFlags.None )
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
