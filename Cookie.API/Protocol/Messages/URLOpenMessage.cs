using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class URLOpenMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6266;

        public override ushort MessageID => ProtocolId;

        public sbyte UrlId { get; set; }
        public URLOpenMessage() { }

        public URLOpenMessage( sbyte UrlId ){
            this.UrlId = UrlId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(UrlId);
        }

        public override void Deserialize(IDataReader reader)
        {
            UrlId = reader.ReadSByte();
        }
    }
}
