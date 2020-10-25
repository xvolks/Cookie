using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ContactLookErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6045;
        public override uint MessageID { get { return ProtocolId; } }

        public int RequestId = 0;

        public ContactLookErrorMessage()
        {
        }

        public ContactLookErrorMessage(
            int requestId
        )
        {
            RequestId = requestId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(RequestId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RequestId = reader.ReadVarInt();
        }
    }
}