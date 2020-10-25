using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MapRunningFightListRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5742;
        public override uint MessageID { get { return ProtocolId; } }

        public MapRunningFightListRequestMessage()
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