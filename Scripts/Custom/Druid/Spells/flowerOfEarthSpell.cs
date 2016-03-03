using System;
using Server.Targeting;
using Server.Network;
using Server.Misc;
using Server.Items;
using System.Collections; 
using Server.Mobiles; 

namespace Server.Spells.Druid
{
    public class flowerOfEarthSpell : DruidSpell
	{
		private static SpellInfo m_Info = new SpellInfo
		(
			"flower Of Earth Spell", "En Ante Ohm Floras",
            266,
            9040,
            Reagent.SpringWater
         );
        public override SpellCircle Circle { get { return SpellCircle.Third; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2.0); } }
      public override double RequiredSkill{ get{ return 25.0; } }
      public override int RequiredMana{ get{ return 10; } }

     

      public flowerOfEarthSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
         else if ( SpellHelper.CheckTown( p, Caster ) && CheckSequence() )
         {
         		if(this.Scroll!=null)
				Scroll.Consume();
				SpellHelper.Turn( Caster, p );

				SpellHelper.GetSurfaceTop( ref p );


				Effects.PlaySound( p, Caster.Map, 0x2 );

            
				Point3D loc = new Point3D( p.X, p.Y, p.Z );
               	int grovex;
				int grovey;
				int grovez;
InternalItem grovecentre = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X;
				grovey=loc.Y;
				grovez=loc.Z;
				grovecentre.ItemID=0x0C4C;
				Point3D centrexyz = new Point3D(grovex,grovey,grovez);
				grovecentre.MoveToWorld( centrexyz, Caster.Map );

InternalItem grovea = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X-2;
				grovey=loc.Y-2;
				grovez=loc.Z;
				grovea.ItemID=3144;
				Point3D grovexyz = new Point3D(grovex,grovey,grovez);
				grovea.MoveToWorld( grovexyz, Caster.Map );
         	
InternalItem grovec = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X;
				grovey=loc.Y-3;
				grovez=loc.Z;
				grovec.ItemID=3149;
				Point3D grovexyzb = new Point3D(grovex,grovey,grovez);
				grovec.MoveToWorld( grovexyzb, Caster.Map );
         	
InternalItem groved = new InternalItem( Caster.Location, Caster.Map, Caster );
				groved.ItemID=3144;
				grovex=loc.X+2;
				grovey=loc.Y-2;
				grovez=loc.Z;
				Point3D grovexyzc = new Point3D(grovex,grovey,grovez);
				groved.MoveToWorld( grovexyzc, Caster.Map );
InternalItem grovee = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X+3;
				grovee.ItemID=3144;
				grovey=loc.Y;
				grovez=loc.Z;
				Point3D grovexyzd = new Point3D(grovex,grovey,grovez);
				grovee.MoveToWorld( grovexyzd, Caster.Map );
InternalItem grovef = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovef.ItemID=3149;
				grovex=loc.X+2;
				grovey=loc.Y+2;
				grovez=loc.Z;
				Point3D grovexyze = new Point3D(grovex,grovey,grovez);
				grovef.MoveToWorld( grovexyze, Caster.Map );
InternalItem groveg = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X;
				groveg.ItemID=3144;
				grovey=loc.Y+3;
				grovez=loc.Z;
				Point3D grovexyzf = new Point3D(grovex,grovey,grovez);
				groveg.MoveToWorld( grovexyzf, Caster.Map );
InternalItem groveh = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X-2;
				groveh.ItemID=3149;
				grovey=loc.Y+2;
				grovez=loc.Z;
				Point3D grovexyzg = new Point3D(grovex,grovey,grovez);
				groveh.MoveToWorld( grovexyzg, Caster.Map );
				
InternalItem grovei = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X-3;
				grovei.ItemID=3149;
				grovey=loc.Y;
				grovez=loc.Z;
				Point3D grovexyzh = new Point3D(grovex,grovey,grovez);
				grovei.MoveToWorld( grovexyzh, Caster.Map );

//debut d'ajout fleurs interieur
InternalItem grove1 = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X-1;
				grove1.ItemID=3149;
				grovey=loc.Y-1;
				grovez=loc.Z;
				Point3D grovexyz1 = new Point3D(grovex,grovey,grovez);
				grove1.MoveToWorld( grovexyz1, Caster.Map );
      	
InternalItem grove2 = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X;
				grovey=loc.Y-2;
				grovez=loc.Z;
				grove2.ItemID=3144;
				Point3D grovexyz2 = new Point3D(grovex,grovey,grovez);
				grove2.MoveToWorld( grovexyz2, Caster.Map );
         	
InternalItem grove3 = new InternalItem( Caster.Location, Caster.Map, Caster );
				grove3.ItemID=3149;
				grovex=loc.X+1;
				grovey=loc.Y-1;
				grovez=loc.Z;
				Point3D grovexyz3 = new Point3D(grovex,grovey,grovez);
				grove3.MoveToWorld( grovexyz3, Caster.Map );
				
InternalItem grove4 = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X+2;
				grove4.ItemID=3149;
				grovey=loc.Y;
				grovez=loc.Z;
				Point3D grovexyz4 = new Point3D(grovex,grovey,grovez);
				grove4.MoveToWorld( grovexyz4, Caster.Map );
				
InternalItem grove5 = new InternalItem( Caster.Location, Caster.Map, Caster );
				grove5.ItemID=3144;
				grovex=loc.X+1;
				grovey=loc.Y+1;
				grovez=loc.Z;
				Point3D grovexyz5 = new Point3D(grovex,grovey,grovez);
				grove5.MoveToWorld( grovexyz5, Caster.Map );
				
InternalItem grove6 = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X;
				grove6.ItemID=3149;
				grovey=loc.Y+2;
				grovez=loc.Z;
				Point3D grovexyz6 = new Point3D(grovex,grovey,grovez);
				grove6.MoveToWorld( grovexyz6, Caster.Map );
				
InternalItem grove7 = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X-1;
				grove7.ItemID=3144;
				grovey=loc.Y+1;
				grovez=loc.Z;
				Point3D grovexyz7 = new Point3D(grovex,grovey,grovez);
				grove7.MoveToWorld( grovexyz7, Caster.Map );
				
InternalItem grove8 = new InternalItem( Caster.Location, Caster.Map, Caster );
				grovex=loc.X-2;
				grove8.ItemID=3144;
				grovey=loc.Y;
				grovez=loc.Z;
				Point3D grovexyz8 = new Point3D(grovex,grovey,grovez);
				grove8.MoveToWorld( grovexyz8, Caster.Map );
//fin d'ajout fleurs interieur         	
            }
         

         FinishSequence();
      }
    
  [DispellableField]
      private class InternalItem : Item
      {
         private Timer m_Timer;
      	private Timer m_Bless;
         private DateTime m_End;
      	private Mobile m_Caster;

         public override bool BlocksFit{ get{ return true; } }

         public InternalItem( Point3D loc, Map map, Mobile caster ) : base( 0x3274 )
         {
            Visible = false;
            Movable = false;
            MoveToWorld( loc, map );
         	m_Caster=caster;

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

            switch ( version )
            {
               case 1:
               {
                  TimeSpan duration = reader.ReadTimeSpan();

                  m_Timer = new InternalTimer( this, duration );
                  m_Timer.Start();

                  m_End = DateTime.Now + duration;

                  break;
               }
               case 0:
               {
                  TimeSpan duration = TimeSpan.FromSeconds( 10.0 );

                  m_Timer = new InternalTimer( this, duration );
                  m_Timer.Start();

                  m_End = DateTime.Now + duration;

                  break;
               }
            }
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
         private flowerOfEarthSpell m_Owner;

         public InternalTarget( flowerOfEarthSpell owner ) : base( 12, true, TargetFlags.None )
         {
            m_Owner = owner;
         }

         protected override void OnTarget( Mobile from, object o )
         {
            if ( o is IPoint3D )
               m_Owner.Target( (IPoint3D)o );
         }

         protected override void OnTargetFinish( Mobile from )
         {
            m_Owner.FinishSequence();
         }
      }
              
	}
}
