using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class URLOpenMessage : NetworkMessage
    {
        public const uint ProtocolId = 6266;
        public override uint MessageID { get { return ProtocolId; } }

        public byte UrlId = 0;

        public URLOpenMessage()
        {
        }

        public URLOpenMessage(
            byte urlId
        )
        {
            UrlId = urlId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(UrlId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            UrlId = reader.ReadByte();
        }
    }
}