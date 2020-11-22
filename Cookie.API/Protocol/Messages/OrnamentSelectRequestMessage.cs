using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class OrnamentSelectRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6374;

        public override ushort MessageID => ProtocolId;

        public ushort OrnamentId { get; set; }
        public OrnamentSelectRequestMessage() { }

        public OrnamentSelectRequestMessage( ushort OrnamentId ){
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
