using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ItemsPreset : Preset
    {
        public new const ushort ProtocolId = 517;

        public override ushort TypeID => ProtocolId;

        public List<ItemForPreset> Items { get; set; }
        public bool MountEquipped { get; set; }
        public EntityLook Look { get; set; }
        public ItemsPreset() { }

        public ItemsPreset( List<ItemForPreset> Items, bool MountEquipped, EntityLook Look ){
            this.Items = Items;
            this.MountEquipped = MountEquipped;
            this.Look = Look;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Items.Count);
			foreach (var x in Items)
			{
				x.Serialize(writer);
			}
            writer.WriteBoolean(MountEquipped);
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var ItemsCount = reader.ReadShort();
            Items = new List<ItemForPreset>();
            for (var i = 0; i < ItemsCount; i++)
            {
                var objectToAdd = new ItemForPreset();
                objectToAdd.Deserialize(reader);
                Items.Add(objectToAdd);
            }
            MountEquipped = reader.ReadBoolean();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}
