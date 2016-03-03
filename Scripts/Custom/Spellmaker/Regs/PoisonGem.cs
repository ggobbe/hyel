using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class PoisonGem : BaseReagent
    {
        [Constructable]
        public PoisonGem()
            : this(1)
        {
        }

        [Constructable]
        public PoisonGem(int amount)
            : base(0x23C, amount)
        {
         
            Name = "gemme de poison";
        }

        public PoisonGem(Serial serial)
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
    }
}
