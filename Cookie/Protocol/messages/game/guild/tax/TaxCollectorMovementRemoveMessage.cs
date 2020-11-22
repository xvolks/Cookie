using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TaxCollectorMovementRemoveMessage : NetworkMessage
    {
        public const uint ProtocolId = 5915;
        public override uint MessageID { get { return ProtocolId; } }

        public double CollectorId = 0;

        public TaxCollectorMovementRemoveMessage()
        {
        }

        public TaxCollectorMovementRemoveMessage(
            double collectorId
        )
        {
            CollectorId = collectorId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(CollectorId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CollectorId = reader.ReadDouble();
        }
    }
}