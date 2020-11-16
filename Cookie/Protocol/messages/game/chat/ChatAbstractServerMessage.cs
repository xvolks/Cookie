using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatAbstractServerMessage : NetworkMessage
    {
        public const uint ProtocolId = 880;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Channel = 0;
        public string Content;
        public int Timestamp = 0;
        public string Fingerprint;

        public ChatAbstractServerMessage()
        {
        }

        public ChatAbstractServerMessage(
            byte channel,
            string content,
            int timestamp,
            string fingerprint
        )
        {
            Channel = channel;
            Content = content;
            Timestamp = timestamp;
            Fingerprint = fingerprint;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Channel);
            writer.WriteUTF(Content);
            writer.WriteInt(Timestamp);
            writer.WriteUTF(Fingerprint);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Channel = reader.ReadByte();
            Content = reader.ReadUTF();
            Timestamp = reader.ReadInt();
            Fingerprint = reader.ReadUTF();
        }
    }
}