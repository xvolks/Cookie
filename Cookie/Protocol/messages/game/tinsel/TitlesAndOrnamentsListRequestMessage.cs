using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TitlesAndOrnamentsListRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6363;
        public override uint MessageID { get { return ProtocolId; } }

        public TitlesAndOrnamentsListRequestMessage()
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