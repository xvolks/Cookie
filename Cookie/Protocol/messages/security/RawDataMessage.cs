using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class RawDataMessage : NetworkMessage
    {
        public const uint ProtocolId = 6253;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Content;

        public RawDataMessage()
        {
        }

        public RawDataMessage(
            byte content
        )
        {
            Content = content;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Content);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Content = reader.ReadByte();
        }
    }
}