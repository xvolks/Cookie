using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildCreationStartedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5920;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildCreationStartedMessage()
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