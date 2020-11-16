using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ItemForPresetUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6760;

        public override ushort MessageID => ProtocolId;

        public short PresetId { get; set; }
        public ItemForPreset PresetItem { get; set; }
        public ItemForPresetUpdateMessage() { }

        public ItemForPresetUpdateMessage( short PresetId, ItemForPreset PresetItem ){
            this.PresetId = PresetId;
            this.PresetItem = PresetItem;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PresetId);
            PresetItem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadShort();
            PresetItem = new ItemForPreset();
            PresetItem.Deserialize(reader);
        }
    }
}
