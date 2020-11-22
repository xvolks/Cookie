using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeMoneyMovementInformationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6834;

        public override ushort MessageID => ProtocolId;

        public ulong Limit { get; set; }
        public ExchangeMoneyMovementInformationMessage() { }

        public ExchangeMoneyMovementInformationMessage( ulong Limit ){
            this.Limit = Limit;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Limit);
        }

        public override void Deserialize(IDataReader reader)
        {
            Limit = reader.ReadVarUhLong();
        }
    }
}
