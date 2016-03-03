using System; //rendu à 0xF0F
using Server;
using Server.Items;

namespace Server.Items
{
    public class FertileDirt : BaseReagent
    {
        [Constructable]
        public FertileDirt()
            : this(1)
        {
        }

        [Constructable]
        public FertileDirt(int amount)
            : base(0xf81, amount)
        {

            Name = "Terre Fertile";
        }

        public FertileDirt(Serial serial)
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
