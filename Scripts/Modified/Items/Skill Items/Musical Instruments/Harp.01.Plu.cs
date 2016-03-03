using System;

namespace Server.Items
{
	public class Harp : BaseInstrument
	{
		[Constructable]
		public Harp() : base( 0xEB1, 0x43, 0x44 )
		{
			Weight = 35.0;
		}

		public Harp( Serial serial ) : base( serial )
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

			if ( Weight == 3.0 )
				Weight = 35.0;
		}
	
     public override void OnDoubleClick(Mobile from)
        {
            if ( !from.InRange( GetWorldLocation(), 1 ) )
            {
                from.SendLocalizedMessage( 500446 ); // That is too far away.
            }
             
             else if ( this.IsChildOf(from.Backpack) ) 
                 {
                 from.SendLocalizedMessage ( 500446); //That is too far away.
                 }
             else if ( from.BeginAction( typeof( BaseInstrument ) ) )
                    {
                    SetInstrument( from, this );

                    // Delay of 7 second before beign able to play another instrument again
                    new InternalTimer( from ).Start();

                    if ( CheckMusicianship( from ) )
                      PlayInstrumentWell( from );
                    else
                        PlayInstrumentBadly( from );
                    }
                    else
                    {
                from.SendLocalizedMessage( 500119 ); // You must wait to perform another action
                 }   
                 }
        private class InternalTimer : Timer
        {
            private Mobile m_From;

            public InternalTimer(Mobile from)
                : base(TimeSpan.FromSeconds(6.0))
            {
                m_From = from;
                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                m_From.EndAction(typeof(BaseInstrument));
            }
        }
        }
    }

    
