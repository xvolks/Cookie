using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    public class InventoryPresetSaveCustomMessage : AbstractPresetSaveMessage
    {
        public new const ushort ProtocolId = 6329;

        public InventoryPresetSaveCustomMessage(List<byte> itemsPositions, List<uint> itemsUids)
        {
            ItemsPositions = itemsPositions;
            ItemsUids = itemsUids;
        }

        public InventoryPresetSaveCustomMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<byte> ItemsPositions { get; set; }
        public List<uint> ItemsUids { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) ItemsPositions.Count);
            for (var itemsPositionsIndex = 0; itemsPositionsIndex < ItemsPositions.Count; itemsPositionsIndex++)
                writer.WriteByte(ItemsPositions[itemsPositionsIndex]);
            writer.WriteShort((short) ItemsUids.Count);
            for (var itemsUidsIndex = 0; itemsUidsIndex < ItemsUids.Count; itemsUidsIndex++)
                writer.WriteVarUhInt(ItemsUids[itemsUidsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var itemsPositionsCount = reader.ReadUShort();
            ItemsPositions = new List<byte>();
            for (var itemsPositionsIndex = 0; itemsPositionsIndex < itemsPositionsCount; itemsPositionsIndex++)
                ItemsPositions.Add(reader.ReadByte());
            var itemsUidsCount = reader.ReadUShort();
            ItemsUids = new List<uint>();
            for (var itemsUidsIndex = 0; itemsUidsIndex < itemsUidsCount; itemsUidsIndex++)
                ItemsUids.Add(reader.ReadVarUhInt());
        }
    }
}