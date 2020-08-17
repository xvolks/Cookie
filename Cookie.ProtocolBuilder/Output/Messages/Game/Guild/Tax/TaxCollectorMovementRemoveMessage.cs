namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Utils.IO;

    public class TaxCollectorMovementRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5915;
        public override ushort MessageID => ProtocolId;
        public int CollectorId { get; set; }

        public TaxCollectorMovementRemoveMessage(int collectorId)
        {
            CollectorId = collectorId;
        }

        public TaxCollectorMovementRemoveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(CollectorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CollectorId = reader.ReadInt();
        }

    }
}
