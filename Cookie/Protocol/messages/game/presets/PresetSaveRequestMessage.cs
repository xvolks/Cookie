using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PresetSaveRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6761;
        public override uint MessageID { get { return ProtocolId; } }

        public short PresetId = 0;
        public byte SymbolId = 0;
        public bool UpdateData = false;

        public PresetSaveRequestMessage()
        {
        }

        public PresetSaveRequestMessage(
            short presetId,
            byte symbolId,
            bool updateData
        )
        {
            PresetId = presetId;
            SymbolId = symbolId;
            UpdateData = updateData;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(PresetId);
            writer.WriteByte(SymbolId);
            writer.WriteBoolean(UpdateData);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PresetId = reader.ReadShort();
            SymbolId = reader.ReadByte();
            UpdateData = reader.ReadBoolean();
        }
    }
}