using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightPlacementSwapPositionsErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6548;
        public override uint MessageID { get { return ProtocolId; } }

        public GameFightPlacementSwapPositionsErrorMessage()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
        }

        public override void Deserialize(ICustomDataInput reader)
        {
        }
    }
}