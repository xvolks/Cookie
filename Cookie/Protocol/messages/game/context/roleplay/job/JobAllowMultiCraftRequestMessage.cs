using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class JobAllowMultiCraftRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5748;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Enabled = false;

        public JobAllowMultiCraftRequestMessage()
        {
        }

        public JobAllowMultiCraftRequestMessage(
            bool enabled
        )
        {
            Enabled = enabled;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Enabled);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Enabled = reader.ReadBoolean();
        }
    }
}