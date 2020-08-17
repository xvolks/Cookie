using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Chat
{
    public class ChatAbstractServerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 880;

        public ChatAbstractServerMessage(byte channel, string content, int timestamp, string fingerprint)
        {
            Channel = channel;
            Content = content;
            Timestamp = timestamp;
            Fingerprint = fingerprint;
        }

        public ChatAbstractServerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Channel { get; set; }
        public string Content { get; set; }
        public int Timestamp { get; set; }
        public string Fingerprint { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Channel);
            writer.WriteUTF(Content);
            writer.WriteInt(Timestamp);
            writer.WriteUTF(Fingerprint);
        }

        public override void Deserialize(IDataReader reader)
        {
            Channel = reader.ReadByte();
            Content = reader.ReadUTF();
            Timestamp = reader.ReadInt();
            Fingerprint = reader.ReadUTF();
        }
    }
}