using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightPlacementSwapPositionsCancelMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6543;

        public override ushort MessageID => ProtocolId;

        public int RequestId { get; set; }
        public GameFightPlacementSwapPositionsCancelMessage() { }

        public GameFightPlacementSwapPositionsCancelMessage( int RequestId ){
            this.RequestId = RequestId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RequestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadInt();
        }
    }
}
