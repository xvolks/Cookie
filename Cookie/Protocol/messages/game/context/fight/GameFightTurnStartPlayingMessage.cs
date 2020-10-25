using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightTurnStartPlayingMessage : NetworkMessage
    {
        public const uint ProtocolId = 6465;
        public override uint MessageID { get { return ProtocolId; } }

        public GameFightTurnStartPlayingMessage()
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