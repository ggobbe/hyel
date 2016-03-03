using System; //rendu à 0xF0F
using Server;
using Server.Items;

namespace Server.Items
{
    public class BloodGem : BaseReagent
    {
        [Constructable]
        public BloodGem()
            : this(1)
        {
        }

        [Constructable]
        public BloodGem(int amount)
            : base(0x23E, amount)
        {
         
            Name = "Gemme de sang";
        }

        public BloodGem(Serial serial)
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
