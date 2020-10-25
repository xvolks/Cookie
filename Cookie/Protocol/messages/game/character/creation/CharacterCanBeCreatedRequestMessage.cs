using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterCanBeCreatedRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6732;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterCanBeCreatedRequestMessage()
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