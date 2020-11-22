using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeCraftPaymentModifiedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6578;

        public override ushort MessageID => ProtocolId;

        public ulong GoldSum { get; set; }
        public ExchangeCraftPaymentModifiedMessage() { }

        public ExchangeCraftPaymentModifiedMessage( ulong GoldSum ){
            this.GoldSum = GoldSum;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(GoldSum);
        }

        public override void Deserialize(IDataReader reader)
        {
            GoldSum = reader.ReadVarUhLong();
        }
    }
}
