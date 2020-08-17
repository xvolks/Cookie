using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    public class InventoryPresetUseResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6163;

        public InventoryPresetUseResultMessage(byte presetId, byte code, List<byte> unlinkedPosition)
        {
            PresetId = presetId;
            Code = code;
            UnlinkedPosition = unlinkedPosition;
        }

        public InventoryPresetUseResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }
        public byte Code { get; set; }
        public List<byte> UnlinkedPosition { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
            writer.WriteByte(Code);
            writer.WriteShort((short) UnlinkedPosition.Count);
            for (var unlinkedPositionIndex = 0; unlinkedPositionIndex < UnlinkedPosition.Count; unlinkedPositionIndex++)
                writer.WriteByte(UnlinkedPosition[unlinkedPositionIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
            Code = reader.ReadByte();
            var unlinkedPositionCount = reader.ReadUShort();
            UnlinkedPosition = new List<byte>();
            for (var unlinkedPositionIndex = 0; unlinkedPositionIndex < unlinkedPositionCount; unlinkedPositionIndex++)
                UnlinkedPosition.Add(reader.ReadByte());
        }
    }
}