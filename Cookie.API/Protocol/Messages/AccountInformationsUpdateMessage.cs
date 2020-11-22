using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AccountInformationsUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6740;

        public override ushort MessageID => ProtocolId;

        public double SubscriptionEndDate { get; set; }
        public double UnlimitedRestatEndDate { get; set; }
        public AccountInformationsUpdateMessage() { }

        public AccountInformationsUpdateMessage( double SubscriptionEndDate, double UnlimitedRestatEndDate ){
            this.SubscriptionEndDate = SubscriptionEndDate;
            this.UnlimitedRestatEndDate = UnlimitedRestatEndDate;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(SubscriptionEndDate);
            writer.WriteDouble(UnlimitedRestatEndDate);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubscriptionEndDate = reader.ReadDouble();
            UnlimitedRestatEndDate = reader.ReadDouble();
        }
    }
}
