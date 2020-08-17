namespace Cookie.API.Protocol.Network.Messages.Connection
{
    using Utils.IO;

    public class IdentificationFailedBannedMessage : IdentificationFailedMessage
    {
        public new const ushort ProtocolId = 6174;
        public override ushort MessageID => ProtocolId;
        public double BanEndDate { get; set; }

        public IdentificationFailedBannedMessage(double banEndDate)
        {
            BanEndDate = banEndDate;
        }

        public IdentificationFailedBannedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(BanEndDate);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            BanEndDate = reader.ReadDouble();
        }

    }
}
