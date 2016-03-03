using System; //rendu à 0xF0F
using Server;
using Server.Items;

namespace Server.Items
{
    public class CoagulateBlood : BaseReagent
    {
        [Constructable]
        public CoagulateBlood()
            : this(1)
        {
        }

        [Constructable]
        public CoagulateBlood(int amount)
            : base(0xf7C, amount)
        {

            Name = "Sang Coagulé";
            Hue = 34;
        }

        public CoagulateBlood(Serial serial)
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
