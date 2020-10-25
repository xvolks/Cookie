using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DungeonPartyFinderAvailableDungeonsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6240;
        public override uint MessageID { get { return ProtocolId; } }

        public DungeonPartyFinderAvailableDungeonsRequestMessage()
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