using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightPlacementSwapPositionsOfferMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6542;

        public GameFightPlacementSwapPositionsOfferMessage(int requestId, double requesterId, ushort requesterCellId,
            double requestedId, ushort requestedCellId)
        {
            RequestId = requestId;
            RequesterId = requesterId;
            RequesterCellId = requesterCellId;
            RequestedId = requestedId;
            RequestedCellId = requestedCellId;
        }

        public GameFightPlacementSwapPositionsOfferMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int RequestId { get; set; }
        public double RequesterId { get; set; }
        public ushort RequesterCellId { get; set; }
        public double RequestedId { get; set; }
        public ushort RequestedCellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RequestId);
            writer.WriteDouble(RequesterId);
            writer.WriteVarUhShort(RequesterCellId);
            writer.WriteDouble(RequestedId);
            writer.WriteVarUhShort(RequestedCellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadInt();
            RequesterId = reader.ReadDouble();
            RequesterCellId = reader.ReadVarUhShort();
            RequestedId = reader.ReadDouble();
            RequestedCellId = reader.ReadVarUhShort();
        }
    }
}