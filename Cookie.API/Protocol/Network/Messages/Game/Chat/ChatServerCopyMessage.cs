namespace Cookie.API.Protocol.Network.Messages.Game.Chat
{
    using Utils.IO;

    public class ChatServerCopyMessage : ChatAbstractServerMessage
    {
        public new const ushort ProtocolId = 882;
        public override ushort MessageID => ProtocolId;
        public ulong ReceiverId { get; set; }
        public string ReceiverName { get; set; }

        public ChatServerCopyMessage(ulong receiverId, string receiverName)
        {
            ReceiverId = receiverId;
            ReceiverName = receiverName;
        }

        public ChatServerCopyMessage() { }

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
