using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells.Druid
{
    public class MassAbeillesSpell : DruidSpell
	{
		
		
		private static SpellInfo m_Info = new SpellInfo(
				"Mass Death", "Vas Corp Nat",
				233,
				9012,
				Reagent.Bloodmoss,
				Reagent.DestroyingAngel,
				Reagent.MandrakeRoot
			);

		public MassAbeillesSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}
        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(5.0); } }
		public override double RequiredSkill{ get{ return 130.0; } }
		public override int RequiredMana{ get{ return 50; } }

		

		public override bool DelayedDamage{ get{ return !Core.AOS; } }

		public override void OnCast()
		{
			if ( SpellHelper.CheckTown( Caster, Caster ) && CheckSequence() )
			{
					if(this.Scroll!=null)
				Scroll.Consume();
				ArrayList targets = new ArrayList();

				Map map = Caster.Map;

				if ( map != null )
				{
					foreach ( Mobile m in Caster.GetMobilesInRange( 1 + (int)(Caster.Skills[SkillName.Magery].Value / 15.0) ) )
					{
						if ( Caster != m && SpellHelper.ValidIndirectTarget( Caster, m ) && Caster.CanBeHarmful( m, false ) && (!Core.AOS || Caster.InLOS( m )) )
							targets.Add( m );
					}
				}

				//Caster.PlaySound( 0x309 );
				

				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];
					double damage = ( ( Caster.Skills[SkillName.Magery].Value + (Caster.Skills[SkillName.AnimalLore].Value))/1.5);
					if ( m is BaseCreature )
					damage = damage * 2;
					
					else if ( m is PlayerMobile )
						damage = 0;

					Caster.DoHarmful( m );
					SpellHelper.Damage( this, m, damage, 0, 0, 0, 100, 0 );
					m.FixedParticles( 0x91B, 1, 240, 9916, 0, 3, EffectLayer.Head );
					m.PlaySound( 0x230 );
					
					
				}
			}

			FinishSequence();
		}
	}
}
