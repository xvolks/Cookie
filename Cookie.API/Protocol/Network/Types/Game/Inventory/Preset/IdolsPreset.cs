using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Inventory.Preset
{
    public class IdolsPreset : NetworkType
    {
        public const ushort ProtocolId = 491;

        public IdolsPreset(byte presetId, byte symbolId, List<ushort> idolId)
        {
            PresetId = presetId;
            SymbolId = symbolId;
            IdolId = idolId;
        }

        public IdolsPreset()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte PresetId { get; set; }
        public byte SymbolId { get; set; }
        public List<ushort> IdolId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
            writer.WriteByte(SymbolId);
            writer.WriteShort((short) IdolId.Count);
            for (var idolIdIndex = 0; idolIdIndex < IdolId.Count; idolIdIndex++)
                writer.WriteVarUhShort(IdolId[idolIdIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
            SymbolId = reader.ReadByte();
            var idolIdCount = reader.ReadUShort();
            IdolId = new List<ushort>();
            for (var idolIdIndex = 0; idolIdIndex < idolIdCount; idolIdIndex++)
                IdolId.Add(reader.ReadVarUhShort());
        }
    }
}