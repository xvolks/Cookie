using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightPlacementSwapPositionsOfferMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6542;

        public override ushort MessageID => ProtocolId;

        public int RequestId { get; set; }
        public double RequesterId { get; set; }
        public ushort RequesterCellId { get; set; }
        public double RequestedId { get; set; }
        public ushort RequestedCellId { get; set; }
        public GameFightPlacementSwapPositionsOfferMessage() { }

        public GameFightPlacementSwapPositionsOfferMessage( int RequestId, double RequesterId, ushort RequesterCellId, double RequestedId, ushort RequestedCellId ){
            this.RequestId = RequestId;
            this.RequesterId = RequesterId;
            this.RequesterCellId = RequesterCellId;
            this.RequestedId = RequestedId;
            this.RequestedCellId = RequestedCellId;
        }

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
