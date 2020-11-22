using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class OrnamentSelectedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6369;

        public override ushort MessageID => ProtocolId;

        public ushort OrnamentId { get; set; }
        public OrnamentSelectedMessage() { }

        public OrnamentSelectedMessage( ushort OrnamentId ){
            this.OrnamentId = OrnamentId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(OrnamentId);
        }

        public override void Deserialize(IDataReader reader)
        {
            OrnamentId = reader.ReadVarUhShort();
        }
    }
}
