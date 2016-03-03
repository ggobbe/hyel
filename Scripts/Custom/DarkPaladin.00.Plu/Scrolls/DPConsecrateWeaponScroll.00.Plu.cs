using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DPConsecrateWeaponScroll : SpellScroll
    {
        [Constructable]
        public DPConsecrateWeaponScroll()
            : this(1)
        {
        }

        [Constructable]
        public DPConsecrateWeaponScroll(int amount)
            : base(222, 0x1F65, amount)
        {
            Hue = 45;
            Name = "Dark Consecrate Weapon Scroll";
        }

        public DPConsecrateWeaponScroll(Serial serial)
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
