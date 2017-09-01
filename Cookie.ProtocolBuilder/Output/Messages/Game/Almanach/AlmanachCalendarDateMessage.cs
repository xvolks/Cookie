namespace Cookie.API.Protocol.Network.Messages.Game.Almanach
{
    using Utils.IO;

    public class AlmanachCalendarDateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6341;
        public override ushort MessageID => ProtocolId;
        public int Date { get; set; }

        public AlmanachCalendarDateMessage(int date)
        {
            Date = date;
        }

        public AlmanachCalendarDateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Date);
        }

        public override void Deserialize(IDataReader reader)
        {
            Date = reader.ReadInt();
        }

    }
}
