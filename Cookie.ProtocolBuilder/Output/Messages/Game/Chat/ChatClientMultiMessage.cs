namespace Cookie.API.Protocol.Network.Messages.Game.Chat
{
    using Utils.IO;

    public class ChatClientMultiMessage : ChatAbstractClientMessage
    {
        public new const ushort ProtocolId = 861;
        public override ushort MessageID => ProtocolId;
        public byte Channel { get; set; }

        public ChatClientMultiMessage(byte channel)
        {
            Channel = channel;
        }

        public ChatClientMultiMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Channel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Channel = reader.ReadByte();
        }

    }
}
