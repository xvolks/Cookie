namespace Cookie.API.Protocol.Network.Messages.Game.Report
{
    using Utils.IO;

    public class CharacterReportMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6079;
        public override ushort MessageID => ProtocolId;
        public ulong ReportedId { get; set; }
        public byte Reason { get; set; }

        public CharacterReportMessage(ulong reportedId, byte reason)
        {
            ReportedId = reportedId;
            Reason = reason;
        }

        public CharacterReportMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ReportedId);
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            ReportedId = reader.ReadVarUhLong();
            Reason = reader.ReadByte();
        }

    }
}
