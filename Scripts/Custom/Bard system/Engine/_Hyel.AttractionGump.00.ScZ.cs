using System;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
    public class AttractionGump : Gump
    {
        private Mobile m_Owner;
        ArrayList m_List;

        public AttractionGump(Mobile owner)
            : base(100, 100)
        {
            m_Owner = owner;

            Skill music = owner.Skills[SkillName.Musicianship];
            Skill track = owner.Skills[SkillName.Tracking];
            music.Update();
            track.Update();

            int range = (int)(50 + (music.Value / 2) + track.Value);
            ArrayList list = new ArrayList();

            foreach (Mobile m in owner.GetMobilesInRange(range))
            {
                if (m != owner && (!Core.AOS || m.Alive) && (!m.Hidden && (m.AccessLevel == AccessLevel.Player || owner.AccessLevel > m.AccessLevel)))
                {
                    if (m is PlayerMobile) // vérifie s'il s'agit bien d'un joueur ou d'un mobile quelconque
                    {
                        list.Add(m);
                    }
                }
            }
            m_List = list;

            this.Closable = true;
            this.Disposable = false;
            this.Dragable = true;
            this.Resizable = false;

            this.AddPage(0);

            int height = (list.Count * 20) + 60;

            this.AddBackground(0, 0, 250, height, 9200);
            this.AddLabel(35, 10, 0, @"Liste des PJ's attractables");
            this.AddImageTiled(5, 28, 238, 12, 50);

            int posY = 45;

            for (int i = 0; i < list.Count; i++)
            {
                this.AddButton(10, posY, 1209, 1210, i + 1, GumpButtonType.Reply, 1);

                Mobile tracked = (Mobile)list[i];
                this.AddLabel(30, posY - 5, 0, tracked.Name.ToString());

                posY += 20;
            }

            if (list.Count == 0)
            {
                this.AddLabel(30, posY - 5, 0, @"Aucun PJ trouvé");
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            int but = info.ButtonID;

            if (but != 0)
            {
                Mobile ToTeleport = (Mobile)m_List[but - 1];

                Point3D to = from.Location;

                ToTeleport.MoveToWorld(to, from.Map);

                Server.Spells.SpellHelper.Turn(from, ToTeleport);
                Server.Spells.SpellHelper.Turn(ToTeleport, from);

                ToTeleport.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                ToTeleport.PlaySound(0x1FE);

                from.SendMessage("Vous téléportez à vos cotés  '" + ToTeleport.Name.ToString() + "'.");
                ToTeleport.SendMessage("'" + from.Name.ToString() + "' vous téléporte à ses côtés.");
            }
        }
    }
}
