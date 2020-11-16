using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightPlacementSwapPositionsCancelledMessage : NetworkMessage
    {
        public const uint ProtocolId = 6546;
        public override uint MessageID { get { return ProtocolId; } }

        public int RequestId = 0;
        public double CancellerId = 0;

        public GameFightPlacementSwapPositionsCancelledMessage()
        {
        }

        public GameFightPlacementSwapPositionsCancelledMessage(
            int requestId,
            double cancellerId
        )
        {
            RequestId = requestId;
            CancellerId = cancellerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(RequestId);
            writer.WriteDouble(CancellerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RequestId = reader.ReadInt();
            CancellerId = reader.ReadDouble();
        }
    }
}