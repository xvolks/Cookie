using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AcquaintancesGetListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6819;
        public override uint MessageID { get { return ProtocolId; } }

        public AcquaintancesGetListMessage()
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