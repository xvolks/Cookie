using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ContactLookRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5932;

        public override ushort MessageID => ProtocolId;

        public byte RequestId { get; set; }
        public sbyte ContactType { get; set; }
        public ContactLookRequestMessage() { }

        public ContactLookRequestMessage( byte RequestId, sbyte ContactType ){
            this.RequestId = RequestId;
            this.ContactType = ContactType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(RequestId);
            writer.WriteSByte(ContactType);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadByte();
            ContactType = reader.ReadSByte();
        }
    }
}
