using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChatServerCopyMessage : ChatAbstractServerMessage
    {
        public new const ushort ProtocolId = 882;

        public override ushort MessageID => ProtocolId;

        public ulong ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public ChatServerCopyMessage() { }

        public ChatServerCopyMessage( ulong ReceiverId, string ReceiverName ){
            this.ReceiverId = ReceiverId;
            this.ReceiverName = ReceiverName;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(ReceiverId);
            writer.WriteUTF(ReceiverName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ReceiverId = reader.ReadVarUhLong();
            ReceiverName = reader.ReadUTF();
        }
    }
}
