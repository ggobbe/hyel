using System;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.Regions;

namespace Server.Spells.Druid
{
    public class CreationFruitSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Apparition Fruits", "Ni Fru Lem",
				224,
				9011                              
			);

        public override SpellCircle Circle { get { return SpellCircle.First; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(1.0); } }
      public override double RequiredSkill{ get{ return 20.0; } }
      public override int RequiredMana{ get{ return 10; } }

		public CreationFruitSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		private static FruitInfo[] m_Fruit = new FruitInfo[]
			{
				new FruitInfo( typeof( Grapes ), "Une Grape" ),
				new FruitInfo( typeof( Banana ), "Une Banane" ),
				new FruitInfo( typeof( Bananas ), "Un Regime de banane" ),
				new FruitInfo( typeof( SplitCoconut ), "Une Noix de coco" ),
				new FruitInfo( typeof( Lemon ), "Un Citron" ),
				new FruitInfo( typeof( Dates ), "Une Dates" ),
				new FruitInfo( typeof( Apple ), "Une Pomme" ),
				new FruitInfo( typeof( Watermelon ), "Un Melon d'eau" ),
				new FruitInfo( typeof( Cantaloupe ), "Un Melon Cantaloupe" ),
				new FruitInfo( typeof( Peach ), "Une Peche" ),
				new FruitInfo( typeof( Coconut ), "Une Noix de coco" ),
				new FruitInfo( typeof( Pear ), "Une Poire" ),
				new FruitInfo( typeof( Lime ), "Un Citron vert" ),
				new FruitInfo( typeof( Squash ), "Une Citrouille" )
				
				
			};

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}
		
		
		public void Target( IPoint3D p )
		{
			IPoint3D orig = p;
			Map map = Caster.Map;

			SpellHelper.GetSurfaceTop( ref p );

			if ( map == null || !map.CanSpawnMobile( p.X, p.Y, p.Z ) )
			{
				Caster.SendLocalizedMessage( 501942 ); // That location is blocked.
			}
			else if ( SpellHelper.CheckMulti( new Point3D( p ), map ) )
			{
				Caster.SendLocalizedMessage( 501942 ); // That location is blocked.
			}
			else if ( CheckSequence() )
			{
				SpellHelper.Turn( Caster, orig );
		
				
				FruitInfo Fruitinfo = m_Fruit[Utility.Random( m_Fruit.Length )];
				Item fruit = Fruitinfo.Create();

				if ( fruit != null )
				{
					Point3D to = new Point3D(p);
					fruit.Location = to;
					fruit.Map = Caster.Map;

					Caster.SendMessage("Vous faite apparaitre  " + Fruitinfo.Name );

					Caster.FixedParticles( 0, 10, 5, 2003, EffectLayer.RightHand );
					Caster.PlaySound( 0x1E2 );
				}
			}

			FinishSequence();
		}
		
		public class InternalTarget : Target
		{
			private CreationFruitSpell m_Owner;

			public InternalTarget( CreationFruitSpell owner ) : base( 5, true, TargetFlags.None )
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

	public class FruitInfo
	{
		private Type m_Type;
		private string m_Name;

		public Type Type{ get{ return m_Type; } set{ m_Type = value; } }
		public string Name{ get{ return m_Name; } set{ m_Name = value; } }

		public FruitInfo( Type type, string name )
		{
			m_Type = type;
			m_Name = name;
		}

		public Item Create()
		{
			Item item;

			try
			{
				item = (Item)Activator.CreateInstance( m_Type );
			}
			catch
			{
				item = null;
			}

			return item;
		}
	}
}
