using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server;

namespace Server.Spells.Cleric
{
	public class ImmobileSpell : ClericSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Immobilium", "Immobilis",
				236,
				9031

			);
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(5.0); } }
		public override int RequiredTithing{ get{ return 50; } }
		public override double RequiredSkill{ get{ return 75.0; } }
		public override int RequiredMana{ get{ return 75; } }
        public override SpellCircle Circle { get { return SpellCircle.First; } }


      public ImmobileSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
         else if ( CheckHSequence( m ) )
         {
            SpellHelper.Turn( Caster, m );

            double duration;

            // Algorithm: ((20% of AnimalTamin) + 7) seconds [- 50% if resisted] seems to work??
            duration = 7.0 + (Caster.Skills[SkillName.SpiritSpeak].Value * 0.4);

            // Resist if Str + Dex / 2 is greater than CastSkill eg. AnimalLore seems to work??
            if ( ( Caster.Skills[CastSkill].Value ) < ( ( m.Str + m.Dex ) * 0.5 ) )
               duration *= 0.5;

            // no less than 0 seconds no more than 9 seconds
            if ( duration < 0.0 )
               duration = 0.0;
            if ( duration > 15.0 )
               duration = 15.0;

            m.PlaySound( 0x108 );

            m.Paralyze( TimeSpan.FromSeconds( duration ) );
            m.FixedParticles( 0x37c4, 2, 10, 5027, 0x3D, 2, EffectLayer.Waist );

            {
               Point3D loc = new Point3D( m.X, m.Y, m.Z );

               Item item = new InternalItem( loc, Caster.Map, Caster );

            }


         }

         FinishSequence();
      }

      //[DispellableField]
      private class InternalItem : Item
      {
         private Timer m_Timer;
         private DateTime m_End;

         //public override bool BlocksFit{ get{ return true; } }

         public InternalItem( Point3D loc, Map map, Mobile caster ) : base( 0x3789 )//c5f
         {
            Visible = false;
            Movable = false;

            MoveToWorld( loc, map );

            if ( caster.InLOS( this ) )
               Visible = true;
            else
               Delete();

            if ( Deleted )
               return;

            m_Timer = new InternalTimer( this, TimeSpan.FromSeconds( 30.0 ) );
            m_Timer.Start();

            m_End = DateTime.Now + TimeSpan.FromSeconds( 30.0 );
         }

         public InternalItem( Serial serial ) : base( serial )
         {
         }

         public override void Serialize( GenericWriter writer )
         {
            base.Serialize( writer );

            writer.Write( (int) 1 ); // version

            writer.Write( m_End - DateTime.Now );
         }

         public override void Deserialize( GenericReader reader )
         {
            base.Deserialize( reader );

            int version = reader.ReadInt();
         }

         public override void OnAfterDelete()
         {
            base.OnAfterDelete();

            if ( m_Timer != null )
               m_Timer.Stop();
         }

         private class InternalTimer : Timer
         {
            private InternalItem m_Item;

            public InternalTimer( InternalItem item, TimeSpan duration ) : base( duration )
            {
               m_Item = item;
            }

            protected override void OnTick()
            {
               m_Item.Delete();
            }
         }
      }

      private class InternalTarget : Target
      {
         private ImmobileSpell m_Owner;

         public InternalTarget( ImmobileSpell owner ) : base( 12, true, TargetFlags.None )
         {
            m_Owner = owner;
         }

         protected override void OnTarget( Mobile from, object o )
         {
            if ( o is Mobile )
               m_Owner.Target( (Mobile)o );
         }

         protected override void OnTargetFinish( Mobile from )
         {
            m_Owner.FinishSequence();
         }
      }
   }
}
