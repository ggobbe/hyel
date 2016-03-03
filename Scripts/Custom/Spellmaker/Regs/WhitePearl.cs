using System; //rendu à 0xF0F
using Server;
using Server.Items;

namespace Server.Items
{
    public class WhitePearl : BaseReagent
    {
        [Constructable]
        public WhitePearl()
            : this(1)
        {
        }

        [Constructable]
        public WhitePearl(int amount)
            : base(0xF7A, amount)
        {
         
            Name = "Perle Blanche";
            Hue = 1150;
        }

        public WhitePearl(Serial serial)
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
