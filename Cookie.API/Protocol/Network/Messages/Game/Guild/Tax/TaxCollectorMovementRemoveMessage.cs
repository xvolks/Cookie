using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class TaxCollectorMovementRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5915;

        public TaxCollectorMovementRemoveMessage(double collectorId)
        {
            CollectorId = collectorId;
        }

        public TaxCollectorMovementRemoveMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double CollectorId { get; set; }

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