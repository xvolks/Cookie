using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartOkEvolutiveObjectRecycleTradeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6778;

        public override ushort MessageID => ProtocolId;

        public ExchangeStartOkEvolutiveObjectRecycleTradeMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}
