using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterLoadingCompleteMessage : NetworkMessage
    {
        public const uint ProtocolId = 6471;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterLoadingCompleteMessage()
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