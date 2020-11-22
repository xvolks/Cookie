using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class OrnamentLostMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6770;

        public override ushort MessageID => ProtocolId;

        public short OrnamentId { get; set; }
        public OrnamentLostMessage() { }

        public OrnamentLostMessage( short OrnamentId ){
            this.OrnamentId = OrnamentId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(OrnamentId);
        }

        public override void Deserialize(IDataReader reader)
        {
            OrnamentId = reader.ReadShort();
        }
    }
}
