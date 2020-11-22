using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartOkNpcTradeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5785;

        public override ushort MessageID => ProtocolId;

        public double NpcId { get; set; }
        public ExchangeStartOkNpcTradeMessage() { }

        public ExchangeStartOkNpcTradeMessage( double NpcId ){
            this.NpcId = NpcId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(NpcId);
        }

        public override void Deserialize(IDataReader reader)
        {
            NpcId = reader.ReadDouble();
        }
    }
}
