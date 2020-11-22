using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightPlacementSwapPositionsCancelledMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6546;

        public override ushort MessageID => ProtocolId;

        public int RequestId { get; set; }
        public double CancellerId { get; set; }
        public GameFightPlacementSwapPositionsCancelledMessage() { }

        public GameFightPlacementSwapPositionsCancelledMessage( int RequestId, double CancellerId ){
            this.RequestId = RequestId;
            this.CancellerId = CancellerId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RequestId);
            writer.WriteDouble(CancellerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadInt();
            CancellerId = reader.ReadDouble();
        }
    }
}
