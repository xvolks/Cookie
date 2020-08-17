using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Chat
{
    public class ChatAbstractClientMessage : NetworkMessage
    {
        public const ushort ProtocolId = 850;

        public ChatAbstractClientMessage(string content)
        {
            Content = content;
        }

        public ChatAbstractClientMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Content { get; set; }

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