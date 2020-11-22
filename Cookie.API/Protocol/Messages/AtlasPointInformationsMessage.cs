using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AtlasPointInformationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5956;

        public override ushort MessageID => ProtocolId;

        public AtlasPointsInformations Type { get; set; }
        public AtlasPointInformationsMessage() { }

        public AtlasPointInformationsMessage( AtlasPointsInformations Type ){
            this.Type = Type;
        }

        public override void Serialize(IDataWriter writer)
        {
            Type.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = new AtlasPointsInformations();
            Type.Deserialize(reader);
        }
    }
}
