using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ContactLookRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5932;
        public override uint MessageID { get { return ProtocolId; } }

        public byte RequestId = 0;
        public byte ContactType = 0;

        public ContactLookRequestMessage()
        {
        }

        public ContactLookRequestMessage(
            byte requestId,
            byte contactType
        )
        {
            RequestId = requestId;
            ContactType = contactType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(RequestId);
            writer.WriteByte(ContactType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RequestId = reader.ReadByte();
            ContactType = reader.ReadByte();
        }
    }
}