using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameEntityDispositionErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5695;
        public override uint MessageID { get { return ProtocolId; } }

        public GameEntityDispositionErrorMessage()
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