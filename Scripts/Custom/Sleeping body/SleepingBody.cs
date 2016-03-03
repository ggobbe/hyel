using System;
using System.Collections;
using Server;
using Server.Engines.PartySystem;
using Server.Misc;
using Server.Guilds;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;

namespace Server.Items
{
	public class SleepingBody : Item
	{
		private Mobile m_Owner;
		private string m_SleepingBodyName;			// Value of the SleepingBodyNameAttribute attached to the owner when he died -or- null if the owner had no SleepingBodyNameAttribute; use "the remains of ~name~"
		private bool m_Blessed;
		private Timer m_Timer;
			private ArrayList	m_EquipItems;			// List of items equiped when the owner died. Ingame, these items display /on/ the SleepingBody, not just inside
	
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Owner
		{
			get{ return m_Owner; }
		}
			public ArrayList EquipItems
		{
			get{ return m_EquipItems; }
		}
			[CommandProperty( AccessLevel.GameMaster )]
		public bool Invuln
		{
			get{ return m_Blessed; }
		}
	
	
 [Constructable] 
		public SleepingBody( Mobile owner, bool blessed) : base( 0x2006 )
		{
			// To supress console warnings, stackable must be true
			Stackable = true;
			Amount = owner.Body; // protocol defines that for itemid 0x2006, amount=body
			Stackable = false;
			m_Blessed=blessed;
			Movable = false;
		
			

			m_Owner = owner;
			Name=m_Owner.Name;
			m_SleepingBodyName = Name;//GetBodyName( owner );
				Hue = m_Owner.Hue;
			Direction = m_Owner.Direction;
		//	Name = "a sleeping body";
		
			m_Timer = new InternalTimer( m_Owner, this );

				m_Timer.Start();
			

		
		}
		

      		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage("You cannot perform negative actions on this being");
		}
      	
     
      
public override void OnAfterDelete()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			m_Timer = null;
			if(m_Owner!=null)
			{
				m_Owner.Z=this.Z;
				m_Owner.Blessed=this.m_Blessed;
				
			}

			base.OnAfterDelete();
		}
		
		public SleepingBody( Serial serial ) : base( serial )
		{
		
			
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			if ( ItemID == 0x2006 ) // Corpse form
			{
				if ( m_SleepingBodyName != null )
					list.Add( m_SleepingBodyName );
				else
					list.Add( 1046414, this.Name ); // the remains of ~1_NAME~
			}
			else // Bone form
			{
				list.Add( 1046414, this.Name ); // the remains of ~1_NAME~
			}
			list.Add( 1049644,"asleep" ); // the remains of ~1_NAME~
		}

		public override void OnSingleClick( Mobile from )
		{
			int hue = 10;

			if ( ItemID == 0x2006 ) // Corpse form
			{
				if ( m_SleepingBodyName != null )
					from.Send( new AsciiMessage( Serial, ItemID, MessageType.Label, hue, 3, "", m_SleepingBodyName ) );
				else
					from.Send( new MessageLocalized( Serial, ItemID, MessageType.Label, hue, 3, 1046414, "", Name ) );
			}
			else // Bone form
			{
				from.Send( new MessageLocalized( Serial, ItemID, MessageType.Label, hue, 3, 1046414, "", Name ) );
			}
		}
				
						
			
		public static string GetBodyName( Mobile m )
		{
			Type t = m.GetType();

			object[] attrs = t.GetCustomAttributes( typeof( CorpseNameAttribute ), true );

			if ( attrs != null && attrs.Length > 0 )
			{
				CorpseNameAttribute attr = attrs[0] as CorpseNameAttribute;

				if ( attr != null )
					return attr.Name;
			}

			return m.Name;
		}

	
		 public override void Serialize( GenericWriter writer ) 
      { 
         base.Serialize( writer ); 

         writer.Write( (int) 0 ); // version 
         writer.Write(m_Owner);
      	writer.Write(m_SleepingBodyName);
      	writer.Write(m_Blessed);
      	
      } 

      public override void Deserialize( GenericReader reader ) 
      { 
         base.Deserialize( reader ); 

         int version = reader.ReadInt(); 
      	m_Owner=reader.ReadMobile();
      	m_SleepingBodyName=reader.ReadString();
      		m_Blessed=reader.ReadBool();
      	
      	
      	
      } 
      	private class InternalTimer : Timer
		{
			private Mobile m_Owner;
			private Item m_Body;
			

			public InternalTimer( Mobile m, Item body ) : base( TimeSpan.FromSeconds(10),TimeSpan.FromSeconds(10) )
			{
				m_Owner=m;
				m_Body=body;
			}
       protected override void OnTick() 
      { 
         if(m_Body!=null)
         m_Body.PublicOverheadMessage(0,m_Owner.SpeechHue,false,"zZz"); 
    if(m_Owner!=null)
         m_Owner.PlaySound(  m_Owner.Female ? 819 : 1093);      
      	//seems to crash certain clients
      } 
		}
	}
}
