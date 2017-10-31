namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Utils.IO;

    public class TaxCollectorMovementRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5915;
        public override ushort MessageID => ProtocolId;
        public double CollectorId { get; set; }

        public TaxCollectorMovementRemoveMessage(double collectorId)
        {
            CollectorId = collectorId;
        }

        public TaxCollectorMovementRemoveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(CollectorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CollectorId = reader.ReadDouble();
        }

    }
}
