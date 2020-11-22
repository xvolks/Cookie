using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TitlesAndOrnamentsListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6363;

        public override ushort MessageID => ProtocolId;

        public TitlesAndOrnamentsListRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}
