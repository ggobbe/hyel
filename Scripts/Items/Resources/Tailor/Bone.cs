using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public abstract class BaseBones : Item
    {
        private CraftResource m_Resource;

        [CommandProperty(AccessLevel.GameMaster)]
        public CraftResource Resource
        {
            get { return m_Resource; }
            set { m_Resource = value; InvalidateProperties(); }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            writer.Write((int)m_Resource);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        m_Resource = (CraftResource)reader.ReadInt();
                        break;
                    }
                case 0:
                    {
                        OreInfo info = new OreInfo(reader.ReadInt(), reader.ReadInt(), reader.ReadString());

                        m_Resource = CraftResources.GetFromOreInfo(info);
                        break;
                    }
            }
        }

        public BaseBones(CraftResource resource) : this(resource, 1)
        {
        }

        public BaseBones(CraftResource resource, int amount) : base(0xf7e)
        {
            Stackable = true;
            Weight = 1.0;
            Amount = amount;
            Hue = CraftResources.GetHue(resource);

            m_Resource = resource;
        }

        public BaseBones(Serial serial) : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (!CraftResources.IsStandard(m_Resource))
            {
                int num = CraftResources.GetLocalizationNumber(m_Resource);

                if (num > 0)
                    list.Add(num);
                else
                    list.Add(CraftResources.GetName(m_Resource));
            }
        }



    }

    public class Bones : BaseBones
    {
        [Constructable]
        public Bones()
            : this(1)
        {
        }

        [Constructable]
        public Bones(int amount)
            : base(CraftResource.RegularBones, amount)
        {
        }
        public override int LabelNumber { get { return 1023786; } }
        public Bones(Serial serial)
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
    public class DaemonBones : BaseBones
    {
        [Constructable]
        public DaemonBones() : this(1)
        {
        }

        [Constructable]
        public DaemonBones(int amount) : base(CraftResource.DaemonBones, amount)
        {
        }
        public override int LabelNumber { get { return 1063653; } }
        public DaemonBones(Serial serial)
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

    public class OgreBones : BaseBones
    {
        [Constructable]
        public OgreBones()
            : this(1)
        {
        }

        [Constructable]
        public OgreBones(int amount)
            : base(CraftResource.OgreBones, amount)
        {
        }
        public override int LabelNumber { get { return 1063655; } }
        public OgreBones(Serial serial)
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
    public class DragonBones : BaseBones
    {
        [Constructable]
        public DragonBones()
            : this(1)
        {
        }

        [Constructable]
        public DragonBones(int amount)
            : base(CraftResource.DragonBones, amount)
        {
        }
        public override int LabelNumber { get { return 1063657; } }
        public DragonBones(Serial serial)
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