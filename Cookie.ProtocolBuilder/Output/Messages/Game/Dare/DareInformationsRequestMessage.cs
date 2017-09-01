namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    using Utils.IO;

    public class DareInformationsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6659;
        public override ushort MessageID => ProtocolId;
        public double DareId { get; set; }

        public DareInformationsRequestMessage(double dareId)
        {
            DareId = dareId;
        }

        public DareInformationsRequestMessage() { }

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
