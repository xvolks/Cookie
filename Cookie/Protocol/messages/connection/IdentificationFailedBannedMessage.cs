using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IdentificationFailedBannedMessage : IdentificationFailedMessage
    {
        public new const uint ProtocolId = 6174;
        public override uint MessageID { get { return ProtocolId; } }

        public double BanEndDate = 0;

        public IdentificationFailedBannedMessage(): base()
        {
        }

        public IdentificationFailedBannedMessage(
            byte reason,
            double banEndDate
        ): base(
            reason
        )
        {
            BanEndDate = banEndDate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(BanEndDate);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            BanEndDate = reader.ReadDouble();
        }
    }
}