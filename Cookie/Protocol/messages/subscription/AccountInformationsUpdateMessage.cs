using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AccountInformationsUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6740;
        public override uint MessageID { get { return ProtocolId; } }

        public double SubscriptionEndDate = 0;
        public double UnlimitedRestatEndDate = 0;

        public AccountInformationsUpdateMessage()
        {
        }

        public AccountInformationsUpdateMessage(
            double subscriptionEndDate,
            double unlimitedRestatEndDate
        )
        {
            SubscriptionEndDate = subscriptionEndDate;
            UnlimitedRestatEndDate = unlimitedRestatEndDate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(SubscriptionEndDate);
            writer.WriteDouble(UnlimitedRestatEndDate);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubscriptionEndDate = reader.ReadDouble();
            UnlimitedRestatEndDate = reader.ReadDouble();
        }
    }
}