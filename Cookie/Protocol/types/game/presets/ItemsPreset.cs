using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class ItemsPreset : Preset
    {
        public new const short ProtocolId = 517;
        public override short TypeId { get { return ProtocolId; } }

        public List<ItemForPreset> Items;
        public bool MountEquipped = false;
        public EntityLook Look;

        public ItemsPreset(): base()
        {
        }

        public ItemsPreset(
            short id_,
            List<ItemForPreset> items,
            bool mountEquipped,
            EntityLook look
        ): base(
            id_
        )
        {
            Items = items;
            MountEquipped = mountEquipped;
            Look = look;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Items.Count());
            foreach (var current in Items)
            {
                current.Serialize(writer);
            }
            writer.WriteBoolean(MountEquipped);
            Look.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countItems = reader.ReadShort();
            Items = new List<ItemForPreset>();
            for (short i = 0; i < countItems; i++)
            {
                ItemForPreset type = new ItemForPreset();
                type.Deserialize(reader);
                Items.Add(type);
            }
            MountEquipped = reader.ReadBoolean();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}