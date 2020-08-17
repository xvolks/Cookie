namespace Cookie.API.Protocol.Network.Messages.Web.Ankabox
{
    using Utils.IO;

    public class MailStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6275;
        public override ushort MessageID => ProtocolId;
        public ushort Unread { get; set; }
        public ushort Total { get; set; }

        public MailStatusMessage(ushort unread, ushort total)
        {
            Unread = unread;
            Total = total;
        }

        public MailStatusMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Unread);
            writer.WriteVarUhShort(Total);
        }

        public override void Deserialize(IDataReader reader)
        {
            Unread = reader.ReadVarUhShort();
            Total = reader.ReadVarUhShort();
        }

    }
}
