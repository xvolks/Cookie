using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChatAbstractClientMessage : NetworkMessage
    {
        public const ushort ProtocolId = 850;

        public override ushort MessageID => ProtocolId;

        public string Content { get; set; }
        public ChatAbstractClientMessage() { }

        public ChatAbstractClientMessage( string Content ){
            this.Content = Content;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            Content = reader.ReadUTF();
        }
    }
}
