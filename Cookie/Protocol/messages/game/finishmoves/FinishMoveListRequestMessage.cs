using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FinishMoveListRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6702;
        public override uint MessageID { get { return ProtocolId; } }

        public FinishMoveListRequestMessage()
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