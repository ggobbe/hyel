using System;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Items
{
    public interface ISawable
    {
        bool WoodSaw(Mobile from, WoodSaw woodsaw);
    }

    [FlipableAttribute(0x1034, 0x1035)]
    public class WoodSaw : Item
    {
        [Constructable]
        public WoodSaw()
            : base(0x1034)
        {
            Weight = 1.0;
            Name = "Scie à planches";
        }

        public WoodSaw(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.SendLocalizedMessage(1064997);

            from.Target = new InternalTarget(this);
        }

        private class InternalTarget : Target
        {
            private WoodSaw m_Item;

            public InternalTarget(WoodSaw item)
                : base(1, false, TargetFlags.None)
            {
                m_Item = item;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (m_Item.Deleted)
                    return;

                /*if ( targeted is Item && !((Item)targeted).IsStandardLoot() )
                {
                    from.SendLocalizedMessage( 502440 ); // Scissors can not be used on that to produce anything.
                }
                else */
                if (Core.AOS && targeted == from)
                {
                    from.SendLocalizedMessage(1062845 + Utility.Random(3));	//"That doesn't seem like the smartest thing to do." / "That was an encounter you don't wish to repeat." / "Ha! You missed!"
                }
                else if (Core.SE && Utility.RandomDouble() > .20 && (from.Direction & Direction.Running) != 0 && (Core.TickCount - from.LastMoveTime) < from.ComputeMovementSpeed(from.Direction))
                {
                    from.SendLocalizedMessage(1064998); // Didn't your parents ever tell you not to run with scissors in your hand?!
                }
                else if (targeted is Item && !((Item)targeted).Movable)
                {
                    return;
                }
                else if (targeted is ISawable)
                {
                    ISawable obj = (ISawable)targeted;

                    if (obj.WoodSaw(from, m_Item))
                        from.PlaySound(0x248);
                }
                else
                {
                    from.SendLocalizedMessage(1064999); // Scissors can not be used on that to produce anything.
                }
            }
        }
    }
}