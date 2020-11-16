using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterSelectedForceReadyMessage : NetworkMessage
    {
        public const uint ProtocolId = 6072;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterSelectedForceReadyMessage()
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