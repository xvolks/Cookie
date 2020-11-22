using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharactersListErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5545;
        public override uint MessageID { get { return ProtocolId; } }

        public CharactersListErrorMessage()
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