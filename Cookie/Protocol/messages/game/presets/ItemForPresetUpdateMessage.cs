using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ItemForPresetUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6760;
        public override uint MessageID { get { return ProtocolId; } }

        public short PresetId = 0;
        public ItemForPreset PresetItem;

        public ItemForPresetUpdateMessage()
        {
        }

        public ItemForPresetUpdateMessage(
            short presetId,
            ItemForPreset presetItem
        )
        {
            PresetId = presetId;
            PresetItem = presetItem;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(PresetId);
            PresetItem.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PresetId = reader.ReadShort();
            PresetItem = new ItemForPreset();
            PresetItem.Deserialize(reader);
        }
    }
}