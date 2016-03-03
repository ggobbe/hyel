using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Items
{
	public class Mausole
	{
		public const int TitheRange = 2;
		public const int LockRange = 2;


        public static void GetContextMenuEntries(Mobile from, Item item, List<ContextMenuEntry> list)
        {
            if (from is PlayerMobile && from.Karma < 0)
            {
                list.Add(new LockKarmaEntry((PlayerMobile)from));
                list.Add(new TitheEntry(from));
            }
        }


        private class LockKarmaEntry : ContextMenuEntry
        {
            private PlayerMobile m_Mobile;

            public LockKarmaEntry(PlayerMobile mobile)
                : base(mobile.KarmaLocked ? 6197 : 6196, LockRange)
            {
                m_Mobile = mobile;
            }

            public override void OnClick()
            {
                m_Mobile.KarmaLocked = !m_Mobile.KarmaLocked;

                if (m_Mobile.KarmaLocked)
                    m_Mobile.SendLocalizedMessage(1060192); // Your karma has been locked. Your karma can no longer be raised.
                else
                    m_Mobile.SendLocalizedMessage(1060191); // Your karma has been unlocked. Your karma can be raised again.
            }
        }

		private class TitheEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			

			public TitheEntry( Mobile mobile ) : base( 6198, TitheRange )
			//public TitheEntry( Mobile mobile ) : base( M_e, TitheRange )			
			{
				m_Mobile = mobile;
				
				//Name = "Sombre";

				Enabled = m_Mobile.Alive;
			}

			public override void OnClick()
			{
				if ( m_Mobile.CheckAlive() || (m_Mobile.Karma < 0))
					m_Mobile.SendGump( new DarkTithingGump( m_Mobile, 0 ) );
			}
			
		}
	}

	public class Mausolee : Item
	{

		[Constructable]
		public Mausolee() : base( 0xED4 )
		{
			Movable = false;
			Name = "Mausolée Maléfique";
			Hue = 0xb5c;


		}

		public Mausolee( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version


		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

		}


	}


}
