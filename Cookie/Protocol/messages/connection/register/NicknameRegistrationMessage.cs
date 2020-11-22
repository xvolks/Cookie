using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class NicknameRegistrationMessage : NetworkMessage
    {
        public const uint ProtocolId = 5640;
        public override uint MessageID { get { return ProtocolId; } }

        public NicknameRegistrationMessage()
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