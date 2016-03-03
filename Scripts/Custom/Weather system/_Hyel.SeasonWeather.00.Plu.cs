//Script modifié ln125 pour compatibilité V2, Plume

using System; 
using System.Collections;
using System.Collections.Generic;
using Server; 
using Server.Network;
using Server.Commands; 

namespace Server.Misc 
{ 
    public enum SeasonList 
    { 
        Spring, 
        Summer, 
        Fall, 
        Winter, 
        Desolation 
    } 

    /*public enum WeatherList 
    { 
        Rain, 
        Storm, 
        Snow, 
        BrewingStorm 
    } */

    public class SeasonWeather 
    { 
        public static void Initialize() 
        {
            CommandSystem.Register("Season", AccessLevel.Administrator, new CommandEventHandler(Season_OnCommand)); 
            //Server.Commands.Register( "Weather", AccessLevel.Seer, new CommandEventHandler( Weather_OnCommand ) ); 
        }

        [Usage( "Season spring | summer | fall | winter | desolation" )] 
        [Description( "Changes seasons." )] 
        
        private static void Season_OnCommand( CommandEventArgs e ) 
        { 
            Mobile m = e.Mobile; 

            if( e.Length == 1 ) 
            { 
                string seasonType = e.GetString( 0 ).ToLower(); 
                SeasonList season; 

                try 
                { 
                    season = (SeasonList) Enum.Parse( typeof( SeasonList ), seasonType, true ); 
                } 
                catch 
                { 
                    m.SendMessage( "Usage: Season spring | summer | fall | winter | desolation" ); 
                    return; 
                } 

                m.SendMessage( "Setting season to: " + seasonType + "." ); 
                //SetSeason( m, season ); 
                 SetGlobalSeason( season );            	
            } 
            else 
                m.SendMessage( "Usage: Season spring | summer | fall | winter | desolation" ); 
        } 

       /* [Usage( "Weather rain | storm | snow | brewingstorm" )] 
        [Description( "Changes the weather." )] 
        private static void Weather_OnCommand( CommandEventArgs e ) 
        { 
            Mobile m = e.Mobile; 

            if( e.Length == 1 ) 
            { 
                string weatherType = e.GetString( 0 ).ToLower(); 
                WeatherList weather; 

                try 
                { 
                    weather = (WeatherList) Enum.Parse( typeof( WeatherList ), weatherType, true ); 
                } 
                catch 
                { 
                    m.SendMessage( "Usage: Weather rain | storm | snow | brewingstorm" ); 
                    return; 
                } 

                m.SendMessage( "Setting weather to: " + weatherType + "." ); 
               // SetWeather( m, weather, true );
            	SetGlobalWeather(weather );
            } 
            else 
                m.SendMessage( "Usage: Weather rain | storm | snow | brewingstorm" ); 
        } */


        public static void SetSeason( Mobile m, SeasonList season ) 
        { 
            m.Send( new SeasonChange( (int) season ) ); 
        } 

        /*public static void SetWeather( Mobile m, WeatherList weather, bool reset ) 
        { 
            // Reset weather on the client 
            if( reset ) 
            { 
                Point3D originalLocation = m.Location; 
                m.Location = new Point3D( originalLocation.X, originalLocation.Y, originalLocation.Z + 1 ); 
                m.Location = originalLocation; 
            } 

            m.Send( new Weather( (int) weather, ( weather == WeatherList.Rain ? 30 : 60 ), 1 ) ); 
        } */

       /* public static void ClearWeather( Mobile m ) 
        { 
            // Reset weather on the client 
            Point3D originalLocation = m.Location; 
            m.Location = new Point3D( originalLocation.X, originalLocation.Y, originalLocation.Z + 1 ); 
            m.Location = originalLocation; 
        } */

        public static void SetGlobalSeason( SeasonList season ) 
        {
            List<NetState> states = NetState.Instances; 
          
            for( int i = 0; i < states.Count; ++i ) 
            {
                NetState ns = states[i];
                Mobile m = ns.Mobile; 

                if ( m != null ) 
                    SetSeason( m, season ); 
            } 
        } 

       /* public static void SetGlobalWeather( WeatherList weather ) 
        { 
            ArrayList states = NetState.Instances; 
          
            for( int i = 0; i < states.Count; ++i ) 
            { 
                Mobile m = ( (NetState) states[i] ).Mobile; 

                if ( m != null ) 
                    SetWeather( m, weather, true ); 
            } 
        } */
    } 
} 
