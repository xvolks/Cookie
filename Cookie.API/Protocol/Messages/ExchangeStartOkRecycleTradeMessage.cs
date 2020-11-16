using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartOkRecycleTradeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6600;

        public override ushort MessageID => ProtocolId;

        public short PercentToPrism { get; set; }
        public short PercentToPlayer { get; set; }
        public ExchangeStartOkRecycleTradeMessage() { }

        public ExchangeStartOkRecycleTradeMessage( short PercentToPrism, short PercentToPlayer ){
            this.PercentToPrism = PercentToPrism;
            this.PercentToPlayer = PercentToPlayer;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PercentToPrism);
            writer.WriteShort(PercentToPlayer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PercentToPrism = reader.ReadShort();
            PercentToPlayer = reader.ReadShort();
        }
    }
}
