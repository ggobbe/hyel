using System; //rendu à 0xF0F
using Server;
using Server.Items;

namespace Server.Items
{
    public class Blackmoor : BaseReagent
    {
        [Constructable]
        public Blackmoor()
            : this(1)
        {
        }

        [Constructable]
        public Blackmoor(int amount)
            : base(0xf79, amount)
        {

            Name = "Terre Noire";
        }

        public Blackmoor(Serial serial)
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
