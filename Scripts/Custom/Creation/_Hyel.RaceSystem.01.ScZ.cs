using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server.Misc
{
	public enum HyelRace
	{
		None        = 0,
		Humain      = 1,
		Nain        = 2,
		Elfe        = 3,
        ElfeNoir    = 4,
        ElfeGlace   = 5
	}

	public class HyelRaceSystem
	{
		public static void ChangeRace( PlayerMobile pm, HyelRace newRace )
		{
			switch( newRace ) {
				case HyelRace.Elfe:
                    pm.BodyValue = pm.Female ? 0x25E : 0x25D;
                    break;

                case HyelRace.ElfeGlace:
                    pm.BodyValue = pm.Female ? 0x25E : 0x25D;
                    pm.Hue = 406;
                    break;

                case HyelRace.ElfeNoir:
                    pm.BodyValue = pm.Female ? 0x25E : 0x25D;
                    pm.Hue = 1109;
                    break;
				
                default: 
                    pm.BodyValue = pm.Female ? 0x191 : 0x190; 
                    break;
			}

            pm.SendMessage("Vous êtes maintenant un " + newRace.ToString());
		}

		public static int DeathBody( HyelRace race, bool female )
		{
			switch( race ) {
                case HyelRace.Elfe:
                case HyelRace.ElfeGlace:
                case HyelRace.ElfeNoir:
                    return female ? 0x260 : 0x25F;
				
                default: 
                    return female ? 0x193 : 0x192;
			}
		}

		public static int AliveBody( HyelRace race, bool female )
		{
			switch( race ) {
                case HyelRace.Elfe:
                case HyelRace.ElfeGlace:
                case HyelRace.ElfeNoir:
                    return female ? 0x25E : 0x25D;

				default: 
                    return female ? 0x191 : 0x190;
			}
		}
	}
}