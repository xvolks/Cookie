namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    using Utils.IO;

    public class DareCanceledMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6679;
        public override ushort MessageID => ProtocolId;
        public double DareId { get; set; }

        public DareCanceledMessage(double dareId)
        {
            DareId = dareId;
        }

        public DareCanceledMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
        }

    }
}
