using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChatAbstractServerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 880;

        public override ushort MessageID => ProtocolId;

        public sbyte Channel { get; set; }
        public string Content { get; set; }
        public int Timestamp { get; set; }
        public string Fingerprint { get; set; }
        public ChatAbstractServerMessage() { }

        public ChatAbstractServerMessage( sbyte Channel, string Content, int Timestamp, string Fingerprint ){
            this.Channel = Channel;
            this.Content = Content;
            this.Timestamp = Timestamp;
            this.Fingerprint = Fingerprint;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Channel);
            writer.WriteUTF(Content);
            writer.WriteInt(Timestamp);
            writer.WriteUTF(Fingerprint);
        }

        public override void Deserialize(IDataReader reader)
        {
            Channel = reader.ReadSByte();
            Content = reader.ReadUTF();
            Timestamp = reader.ReadInt();
            Fingerprint = reader.ReadUTF();
        }
    }
}
