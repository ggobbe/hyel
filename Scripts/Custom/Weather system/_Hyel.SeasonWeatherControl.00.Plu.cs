//Script transféré intact, Plume

using System; 
using System.Collections; 
using Server; 
using Server.Network; 
using Server.Misc; 

namespace Server.Custom.Regions 
{ 
   public class weatherTimer : Timer 
   { 
      public static void Initialize()  
      {    
         new weatherTimer(); 
      } 
      public weatherTimer() : base(TimeSpan.FromSeconds(10),TimeSpan.FromHours(96)) 
//delay 10 secs, and restart after 12 hours
      { 
         this.Start(); 
      } 
      protected override void OnTick() 
      { 
//***********************************************
       /*  int weather = Utility.RandomMinMax( 0, 3 ); 
         switch(weather) 
         { 
            case 0:Console.WriteLine("Weather: Rain"); 
            Misc.SeasonWeather.SetGlobalWeather(Misc.WeatherList.Rain); 
            break; 
            case 1:Console.WriteLine("Weather: Storm"); 
            Misc.SeasonWeather.SetGlobalWeather(Misc.WeatherList.Storm); 
            break; 
            case 2:Console.WriteLine("Weather: Snow"); 
            Misc.SeasonWeather.SetGlobalWeather(Misc.WeatherList.Snow); 
            break; 
            case 3:Console.WriteLine("Weather: BrewingStorm"); 
            Misc.SeasonWeather.SetGlobalWeather(Misc.WeatherList.BrewingStorm); 
            break; 
            default: Console.WriteLine( "Weather: Unknown Weather" ); break; 
         }; */
//***********************************************(3 = vinter hivers)
         switch(DateTime.Now.Month) 
         { 
            case 1:case 11:case 12: 
            { 
               Map.Felucca.Season = 3; 
              // Map.Trammel.Season = 4;  
               //Map.Ilshenar.Season = 4;  
               //Map.Malas.Season = 4; 
		Misc.SeasonWeather.SetGlobalSeason(Misc.SeasonList.Winter);
               Console.WriteLine( "Season: Winter" ); 
            } break; 
            case 2:case 3:case 4:case 5: 
            { 
               Map.Felucca.Season = 0; 
               //Map.Trammel.Season = 0;  
               //Map.Ilshenar.Season = 0;  
               //Map.Malas.Season = 0; 
		Misc.SeasonWeather.SetGlobalSeason(Misc.SeasonList.Spring);
               Console.WriteLine( "Season: Spring" ); 
            } break; 
            case 6:case 7:case 8: 
            { 
               Map.Felucca.Season = 1;    
              // Map.Trammel.Season = 1;  
               //Map.Ilshenar.Season = 1;  
               //Map.Malas.Season = 1; 
		Misc.SeasonWeather.SetGlobalSeason(Misc.SeasonList.Summer);
               Console.WriteLine( "Season: Summer" ); 
            } break; 
            case 9:case 10: 
            { 
               Map.Felucca.Season = 2; 
              // Map.Trammel.Season = 2;  
              // Map.Ilshenar.Season = 2;  
              // Map.Malas.Season = 2; 
		Misc.SeasonWeather.SetGlobalSeason(Misc.SeasonList.Fall);
               Console.WriteLine( "Season: Fall" ); 
            } break; 
            default: 
            Console.WriteLine( "Season: End of the world man, unknown month." ); 
            break; 
         } 
      } 
   } 
}
