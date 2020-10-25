using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildLeftMessage : NetworkMessage
    {
        public const uint ProtocolId = 5562;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildLeftMessage()
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