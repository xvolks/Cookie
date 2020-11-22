using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightPlacementSwapPositionsCancelMessage : NetworkMessage
    {
        public const uint ProtocolId = 6543;
        public override uint MessageID { get { return ProtocolId; } }

        public int RequestId = 0;

        public GameFightPlacementSwapPositionsCancelMessage()
        {
        }

        public GameFightPlacementSwapPositionsCancelMessage(
            int requestId
        )
        {
            RequestId = requestId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(RequestId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RequestId = reader.ReadInt();
        }
    }
}