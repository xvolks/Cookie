using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHouseItemRemoveOkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5946;

        public override ushort MessageID => ProtocolId;

        public int SellerId { get; set; }
        public ExchangeBidHouseItemRemoveOkMessage() { }

        public ExchangeBidHouseItemRemoveOkMessage( int SellerId ){
            this.SellerId = SellerId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SellerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SellerId = reader.ReadInt();
        }
    }
}
