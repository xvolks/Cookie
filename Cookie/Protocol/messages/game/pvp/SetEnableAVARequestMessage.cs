using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SetEnableAVARequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6443;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Enable = false;

        public SetEnableAVARequestMessage()
        {
        }

        public SetEnableAVARequestMessage(
            bool enable
        )
        {
            Enable = enable;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}