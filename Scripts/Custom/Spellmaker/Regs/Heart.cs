using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class Heart : BaseReagent
    {
        [Constructable]
        public Heart()
            : this(1)
        {
        }

        [Constructable]
        public Heart(int amount)
            : base(0x24B, amount)
        {
         
            Name = "coeur";
        }

        public Heart(Serial serial)
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
