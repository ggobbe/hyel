using System; //rendu à 0xF0F
using Server;
using Server.Items;

namespace Server.Items
{
    public class HumanBone : BaseReagent
    {
        [Constructable]
        public HumanBone()
            : this(1)
        {
        }

        [Constructable]
        public HumanBone(int amount)
            : base(0xF7E, amount)
        {
         
            Name = "Os Humain";
        }

        public HumanBone(Serial serial)
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
