/** Baghera@01/12/2007 : Script permettant d'assombrir l'écran du joueur via un gump
 * .nuit xx : xx = temps d'assombrissement
 * Le gump sera utilisé dans les sorts de bardes (aveuglement)
 * 
 * Scriptiz@01/12/2007 : Corrections de quelques erreurs
 **/
using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Commands;
using Server.Mobiles;
using Server.SkillHandlers;
using Server.Gumps;
using Server.Spells.Barde;

namespace Server.Commands
{
	public class Nuit
	{
		public static int NuitTime = 5;
		public static void Initialize()
		{
			Register();
		}

		public static void Register()
		{
			CommandSystem.Register( "Nuit", AccessLevel.Seer, new CommandEventHandler( Nuit_OnCommand ) );
		}

		private class NuitTarget : Target
		{
			public NuitTarget( ) : base( -1, true, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object o )
			{
                Mobile isPlayer = (Mobile)o;

				if (isPlayer is PlayerMobile)
					isPlayer.SendGump(new NuitGump((PlayerMobile)o, NuitTime));
					
                else
                    from.SendMessage("Cette commande ne s'applique que sur les joueurs.");
                
			}
		}

		[Usage( "Nuit <secondes>" )]
		[Description( "La cible visée se retrouve aveugle." )]
		private static void Nuit_OnCommand( CommandEventArgs e )
		{
            if (e.Length >= 1)
            {
                NuitTime = e.GetInt32(0);
            }
						
			e.Mobile.Target = new NuitTarget();
		}
	}
}
namespace Server.Gumps
{
    public class NuitGump: Gump
    {
        public NuitGump(Mobile m, int time): base(0, 0)
        {
            this.Closable = false;
            this.Disposable = false;
            this.Dragable = false;
            this.Resizable = false;
            this.AddPage(0);
            this.AddImageTiled(0, 0, 1280, 1024, 2702);
            NuitTimer timer = new NuitTimer(m, time);
            timer.Start();
        }
    }

    public class NuitTimer : Timer
    {
        public Mobile m_mob;
        public NuitTimer(Mobile m, int seconds)
            : base(TimeSpan.FromSeconds(seconds))
        {
            m_mob = m;
            m_mob.PrivateOverheadMessage(0, 32, true, "*aveugle*", m_mob.NetState);
			m_mob.SendMessage("Vous êtes aveugle.");
        }

        protected override void OnTick()
        {
            m_mob.CloseGump(typeof(NuitGump));

            // rajout pour le sort Aveuglement (Barde)
            m_mob.EndAction(typeof(AveuglementSpell));

            m_mob.SendMessage("Vous retrouvez la vue.");
        }
    }
}