using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PresetSaveErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6762;
        public override uint MessageID { get { return ProtocolId; } }

        public short PresetId = 0;
        public byte Code = 2;

        public PresetSaveErrorMessage()
        {
        }

        public PresetSaveErrorMessage(
            short presetId,
            byte code
        )
        {
            PresetId = presetId;
            Code = code;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(PresetId);
            writer.WriteByte(Code);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PresetId = reader.ReadShort();
            Code = reader.ReadByte();
        }
    }
}