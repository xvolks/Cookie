using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionNoopMessage : NetworkMessage
    {
        public const uint ProtocolId = 1002;
        public override uint MessageID { get { return ProtocolId; } }

        public GameActionNoopMessage()
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