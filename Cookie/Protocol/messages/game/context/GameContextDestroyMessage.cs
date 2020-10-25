using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextDestroyMessage : NetworkMessage
    {
        public const uint ProtocolId = 201;
        public override uint MessageID { get { return ProtocolId; } }

        public GameContextDestroyMessage()
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