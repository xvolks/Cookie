using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChatClientPrivateMessage : ChatAbstractClientMessage
    {
        public new const ushort ProtocolId = 851;

        public override ushort MessageID => ProtocolId;

        public string Receiver { get; set; }
        public ChatClientPrivateMessage() { }

        public ChatClientPrivateMessage( string Receiver ){
            this.Receiver = Receiver;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Receiver);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Receiver = reader.ReadUTF();
        }
    }
}
