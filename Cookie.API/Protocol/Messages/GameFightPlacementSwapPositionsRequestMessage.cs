using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightPlacementSwapPositionsRequestMessage : GameFightPlacementPositionRequestMessage
    {
        public new const ushort ProtocolId = 6541;

        public override ushort MessageID => ProtocolId;

        public double RequestedId { get; set; }
        public GameFightPlacementSwapPositionsRequestMessage() { }

        public GameFightPlacementSwapPositionsRequestMessage( double RequestedId ){
            this.RequestedId = RequestedId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(RequestedId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            RequestedId = reader.ReadDouble();
        }
    }
}
