using System;

using Server;
using Server.Items;
using Server.Gumps;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Regions;

namespace Server.Spells.Druid
{
    public class Insomnispell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"InSomnis", "Os vor In Somnis",
				212,
				9041,
            Reagent.DestroyingAngel
			);

        public override SpellCircle Circle { get { return SpellCircle.Fourth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
	      public override double RequiredSkill{ get{ return 80.0; } }
	      public override int RequiredMana{ get{ return 20; } }
		public override bool BlocksMovement{ get{ return false; } }

		public Insomnispell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

	

		public void Target( SleepingBody slumber )
		{
			if ( !Caster.CanSee( slumber ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			
			else if ( CheckSequence() )
			{
				
				
					if(this.Scroll!=null)
				Scroll.Consume();
						slumber.Owner.RevealingAction();
				slumber.Owner.Frozen=false;
				slumber.Owner.Squelched=false;
				slumber.Owner.Blessed=slumber.Invuln;
			
				slumber.Owner.Animate(21, 6, 1, false, false, 0);;
				slumber.Owner.SendMessage("You wake up!");
				if(slumber!=null)
					slumber.Delete();
				Caster.SendMessage("Vous le ranimez!");
					
				
				
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private Insomnispell m_Owner;

			public InternalTarget( Insomnispell owner ) : base( 12, false, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is SleepingBody )
				{
					m_Owner.Target( (SleepingBody) o );
				}
				else
				{
					from.SendMessage("Ceci ne peut etre ranim�." ); // I cannot mark that object.
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			
			}
		}
	}
}
