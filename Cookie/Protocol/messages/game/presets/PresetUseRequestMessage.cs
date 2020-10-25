using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PresetUseRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6759;
        public override uint MessageID { get { return ProtocolId; } }

        public short PresetId = 0;

        public PresetUseRequestMessage()
        {
        }

        public PresetUseRequestMessage(
            short presetId
        )
        {
            PresetId = presetId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(PresetId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PresetId = reader.ReadShort();
        }
    }
}