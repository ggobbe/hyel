/* Créé part Scriptiz pour le livre de barde de Plume */
using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Misc;
using Server.Spells.Barde;

namespace Server.Spells.Barde
{
    public class CarapaceSpell : BardeSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
            "Carapace",
            "Au nom des mecenes, laisse-moi en paix"
            );
        public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(2 - ((double)Caster.Int / 120)); } }

        public override double RequiredSkill { get { return 30.0; } }
        public override int RequiredMana { get { return 20; } }

        public CarapaceSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (Caster.Spell != null)
                Caster.Spell.OnCasterHurt();

            if (Caster.BeginAction(typeof(CarapaceSpell)))
            {
                Caster.FixedParticles(0x3779, 10, 15, 5009, EffectLayer.Waist);
                Caster.PlaySound(0x1E6);

                Caster.BeginAction(typeof(CarapaceSpell));

                Point3D loc0 = new Point3D(Caster.X, Caster.Y, Caster.Z);
                Point3D loc1 = new Point3D(Caster.X + 1, Caster.Y, Caster.Z);
                Point3D loc2 = new Point3D(Caster.X - 1, Caster.Y, Caster.Z);
                Point3D loc3 = new Point3D(Caster.X, Caster.Y + 1, Caster.Z);
                Point3D loc4 = new Point3D(Caster.X, Caster.Y - 1, Caster.Z);
                Point3D loc5 = new Point3D(Caster.X + 1, Caster.Y + 1, Caster.Z);
                Point3D loc6 = new Point3D(Caster.X + 1, Caster.Y - 1, Caster.Z);
                Point3D loc7 = new Point3D(Caster.X - 1, Caster.Y + 1, Caster.Z);
                Point3D loc8 = new Point3D(Caster.X - 1, Caster.Y - 1, Caster.Z);

                Item item0 = new InternalItem(loc0, Caster.Map, Caster);
                Item item1 = new InternalItem(loc1, Caster.Map, Caster);
                Item item2 = new InternalItem(loc2, Caster.Map, Caster);
                Item item3 = new InternalItem(loc3, Caster.Map, Caster);
                Item item4 = new InternalItem(loc4, Caster.Map, Caster);
                Item item5 = new InternalItem(loc5, Caster.Map, Caster);
                Item item6 = new InternalItem(loc6, Caster.Map, Caster);
                Item item7 = new InternalItem(loc7, Caster.Map, Caster);
                Item item8 = new InternalItem(loc8, Caster.Map, Caster);
            }
            else
            {
                Caster.SendMessage("Votre cible est déjà sous l'effet de ce sort !");
            }
        }

        [DispellableField]
        private class InternalItem : Item
        {
            private Timer m_Timer;
            private DateTime m_End;
            public Mobile m_Caster;

            public override bool BlocksFit { get { return true; } }

            public InternalItem(Point3D loc, Map map, Mobile caster)
                : base(0x80)
            {
                Visible = false;
                Movable = false;

                MoveToWorld(loc, map);

                if (caster.InLOS(this))
                    Visible = true;
                else
                    Delete();

                if (Deleted)
                    return;

                Skill peace = caster.Skills[SkillName.Peacemaking];
                peace.Update();

                Skill music = caster.Skills[SkillName.Musicianship];
                music.Update();

                //x=(n/20)+(y/10)+15    n=peacemaking ; y=musicianship
                double time = (peace.Value / 20) + (music.Value / 10) + 15;
                m_Caster = caster;
                m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(time), caster);
                m_Timer.Start();

                m_End = DateTime.Now + TimeSpan.FromSeconds(time);
            }

            public InternalItem(Serial serial)
                : base(serial)
            {
            }

            public override void Serialize(GenericWriter writer)
            {
                base.Serialize(writer);

                writer.Write((int)1); // version

                writer.WriteDeltaTime(m_End);
            }

            public override void Deserialize(GenericReader reader)
            {
                base.Deserialize(reader);

                int version = reader.ReadInt();

                switch (version)
                {
                    case 1:
                        {
                            m_End = reader.ReadDeltaTime();

                            m_Timer = new InternalTimer(this, m_End - DateTime.Now, m_Caster);
                            m_Timer.Start();

                            break;
                        }
                    case 0:
                        {
                            TimeSpan duration = TimeSpan.FromSeconds(10.0);

                            m_Timer = new InternalTimer(this, duration, m_Caster);
                            m_Timer.Start();

                            m_End = DateTime.Now + duration;

                            break;
                        }
                }
            }

            public override void OnAfterDelete()
            {
                base.OnAfterDelete();

                if (m_Timer != null)
                    m_Timer.Stop();
            }

            private class InternalTimer : Timer
            {
                private InternalItem m_Item;
                private Mobile m_Caster;

                public InternalTimer(InternalItem item, TimeSpan duration, Mobile caster)
                    : base(duration)
                {
                    Priority = TimerPriority.OneSecond;
                    m_Item = item;
                    m_Caster = caster;
                }

                protected override void OnTick()
                {
                    m_Item.Delete();
                    m_Caster.EndAction(typeof(CarapaceSpell));
                }
            }
        }
    }
}
