using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class FireGem : BaseReagent
    {
        [Constructable]
        public FireGem()
            : this(1)
        {
        }

        [Constructable]
        public FireGem(int amount)
            : base(0x23D, amount)
        {
         
            Name = "Gemme de feu";
        }

        public FireGem(Serial serial)
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
