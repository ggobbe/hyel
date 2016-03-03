using System; //rendu à 0xF0F
using Server;
using Server.Items;

namespace Server.Items
{
    public class NewtEye : BaseReagent
    {
        [Constructable]
        public NewtEye()
            : this(1)
        {
        }

        [Constructable]
        public NewtEye(int amount)
            : base(0x87, amount)
        {
         
            Name = "Oeil de Newt";
        }

        public NewtEye(Serial serial)
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
