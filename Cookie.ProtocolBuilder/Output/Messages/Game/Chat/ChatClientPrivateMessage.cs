namespace Cookie.API.Protocol.Network.Messages.Game.Chat
{
    using Utils.IO;

    public class ChatClientPrivateMessage : ChatAbstractClientMessage
    {
        public new const ushort ProtocolId = 851;
        public override ushort MessageID => ProtocolId;
        public string Receiver { get; set; }

        public ChatClientPrivateMessage(string receiver)
        {
            Receiver = receiver;
        }

        public ChatClientPrivateMessage() { }

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
