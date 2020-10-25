using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterSelectedErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5836;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterSelectedErrorMessage()
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