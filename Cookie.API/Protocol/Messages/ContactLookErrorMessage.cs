using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ContactLookErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6045;

        public override ushort MessageID => ProtocolId;

        public uint RequestId { get; set; }
        public ContactLookErrorMessage() { }

        public ContactLookErrorMessage( uint RequestId ){
            this.RequestId = RequestId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(RequestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadVarUhInt();
        }
    }
}
