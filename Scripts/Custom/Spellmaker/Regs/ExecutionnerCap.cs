using System; //rendu à 0xF0F
using Server;
using Server.Items;

namespace Server.Items
{
    public class ExecutionnerCap : BaseReagent
    {
        [Constructable]
        public ExecutionnerCap()
            : this(1)
        {
        }

        [Constructable]
        public ExecutionnerCap(int amount)
            : base(0xf83, amount)
        {

            Name = "Chapeau d'exécuteur";
        }

        public ExecutionnerCap(Serial serial)
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
