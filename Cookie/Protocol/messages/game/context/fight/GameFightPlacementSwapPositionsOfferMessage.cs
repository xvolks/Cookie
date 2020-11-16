using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightPlacementSwapPositionsOfferMessage : NetworkMessage
    {
        public const uint ProtocolId = 6542;
        public override uint MessageID { get { return ProtocolId; } }

        public int RequestId = 0;
        public double RequesterId = 0;
        public short RequesterCellId = 0;
        public double RequestedId = 0;
        public short RequestedCellId = 0;

        public GameFightPlacementSwapPositionsOfferMessage()
        {
        }

        public GameFightPlacementSwapPositionsOfferMessage(
            int requestId,
            double requesterId,
            short requesterCellId,
            double requestedId,
            short requestedCellId
        )
        {
            RequestId = requestId;
            RequesterId = requesterId;
            RequesterCellId = requesterCellId;
            RequestedId = requestedId;
            RequestedCellId = requestedCellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(RequestId);
            writer.WriteDouble(RequesterId);
            writer.WriteVarShort(RequesterCellId);
            writer.WriteDouble(RequestedId);
            writer.WriteVarShort(RequestedCellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RequestId = reader.ReadInt();
            RequesterId = reader.ReadDouble();
            RequesterCellId = reader.ReadVarShort();
            RequestedId = reader.ReadDouble();
            RequestedCellId = reader.ReadVarShort();
        }
    }
}