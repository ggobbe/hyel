using System;
using Server;
using Server.Network;
using Server.Targets;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Druid;

namespace Server.Gumps
{
	public class ApparenceAnimaleGump : Gump
	{
		private class PolymorphEntry
		{
			private int m_Art, m_Body;
			private string m_Num;

			public PolymorphEntry( int Art, int Body, string LocNum )
			{
				m_Art = Art;
				m_Body = Body;
				m_Num = LocNum;
			}

			public int ArtID { get { return m_Art; } }
			public int BodyID { get { return m_Body; } }
			public string LocNumber{ get { return m_Num; } }
		}

		private class PolymorphCategory
		{
			private string m_Num;
			private PolymorphEntry[] m_Entries;

			public PolymorphCategory( string num, PolymorphEntry[] entries )
			{
				m_Num = num;
				m_Entries = entries;
			}

			public PolymorphEntry[] Entries{ get { return m_Entries; } }
			public string LocNumber{ get { return m_Num; } }
		}

		private static PolymorphCategory[] Categories = new PolymorphCategory[]
		{
			new PolymorphCategory( "Animaux communs", new PolymorphEntry[] //Animals 1015235
			{
			    new PolymorphEntry( 8475, 0xC9, "Chat" ),
			    new PolymorphEntry( 8479, 0xE4, "Cheval" ),
			    new PolymorphEntry( 8405, 0xD9, "Chien" ),
			    new PolymorphEntry( 8449, 0xCB, "Cochon" ),
			    new PolymorphEntry( 8485, 0xCD, "Lapin" ),
				new PolymorphEntry( 8427, 0xCF, "Mouton" ),
			    new PolymorphEntry( 8474, 0x6, "Oiseau" ),
				new PolymorphEntry( 8401, 0xD0, "Poulet" ),
				new PolymorphEntry( 8483, 0xEE, "Rat" ),
			    new PolymorphEntry( 8451, 0xD8, "Vache" ),               	
			    

			} ),

			new PolymorphCategory( "Animaux sauvages", new PolymorphEntry[] //Monsters  1015245
			{
			    new PolymorphEntry( 8404, 0xEA, "Cerf" ),
				new PolymorphEntry( 8404, 0xED, "Biche" ),
				new PolymorphEntry( 8426, 0xE1, "Loup" ),
				new PolymorphEntry( 8437, 0x1D, "Gorille" ),
				new PolymorphEntry( 8450, 0xD6, "Panthere" ),
				new PolymorphEntry( 8472, 0xD3, "Ours" ),
				new PolymorphEntry( 8417, 0xD5, "Ours polaire" ),
				new PolymorphEntry( 8434, 0x5, "Aigle" ),
				new PolymorphEntry( 8444, 0x34, "Serpent" ),
			    new PolymorphEntry( 8410, 0xCA, "Alligator" ),
			    new PolymorphEntry( 8478, 0xD4, "Grizzly" )

			} )
		};

		private Mobile m_Caster;
		private Item m_Scroll;

		public ApparenceAnimaleGump( Mobile caster, Item scroll ) : base( 50, 50 )
		{
			m_Caster = caster;
			m_Scroll = scroll;

			int x,y;
			AddPage( 0 );
			AddBackground( 0, 0, 585, 393, 5054 );
			AddBackground( 195, 36, 387, 275, 3000 );
			AddHtml( 0, 0, 510, 18, "Menu d'apparence animale druide", false, false ); // <center>Polymorph Selection Menu</center>
			AddHtmlLocalized( 60, 355, 150, 18, 1011036, false, false ); // OKAY
			AddButton( 25, 355, 4005, 4007, 1, GumpButtonType.Reply, 1 );
			AddHtmlLocalized( 320, 355, 150, 18, 1011012, false, false ); // CANCEL
			AddButton( 285, 355, 4005, 4007, 0, GumpButtonType.Reply, 2 );

			y = 35;
			for ( int i=0;i<Categories.Length;i++ )
			{
				PolymorphCategory cat = (PolymorphCategory)Categories[i];
				AddHtml( 5, y, 150, 25, cat.LocNumber, true, false );
				AddButton( 155, y, 4005, 4007, 0, GumpButtonType.Page, i+1 );
				y += 25;
			}

			for ( int i=0;i<Categories.Length;i++ )
			{
				PolymorphCategory cat = (PolymorphCategory)Categories[i];
				AddPage( i+1 );

				for ( int c=0;c<cat.Entries.Length;c++ )
				{
					PolymorphEntry entry = (PolymorphEntry)cat.Entries[c];
					x = 198 + (c%3)*129;
					y = 38 + (c/3)*67;

					AddHtml( x, y, 100, 18, entry.LocNumber, false, false );
					AddItem( x+20, y+25, entry.ArtID );
					AddRadio( x, y+20, 210, 211, false, (c<<8) + i );
				}
			}
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			if ( info.ButtonID == 1 && info.Switches.Length > 0 )
			{
				int cnum = info.Switches[0];
				int cat = cnum%256;
				int ent = cnum>>8;

				if ( cat < Categories.Length )
				{
					if ( ent < Categories[cat].Entries.Length )
					{
						Spell spell = new ApparenceAnimaleSpell( m_Caster, m_Scroll , Categories[cat].Entries[ent].BodyID );
						spell.Cast();
					}
				}
			}
		}
	}
}
