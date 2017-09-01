using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    public class IdolsPresetUseResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6614;

        public IdolsPresetUseResultMessage(byte presetId, byte code, List<ushort> missingIdols)
        {
            PresetId = presetId;
            Code = code;
            MissingIdols = missingIdols;
        }

        public IdolsPresetUseResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }
        public byte Code { get; set; }
        public List<ushort> MissingIdols { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
            writer.WriteByte(Code);
            writer.WriteShort((short) MissingIdols.Count);
            for (var missingIdolsIndex = 0; missingIdolsIndex < MissingIdols.Count; missingIdolsIndex++)
                writer.WriteVarUhShort(MissingIdols[missingIdolsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
            Code = reader.ReadByte();
            var missingIdolsCount = reader.ReadUShort();
            MissingIdols = new List<ushort>();
            for (var missingIdolsIndex = 0; missingIdolsIndex < missingIdolsCount; missingIdolsIndex++)
                MissingIdols.Add(reader.ReadVarUhShort());
        }
    }
}