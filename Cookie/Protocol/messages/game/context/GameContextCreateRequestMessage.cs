using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextCreateRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 250;
        public override uint MessageID { get { return ProtocolId; } }

        public GameContextCreateRequestMessage()
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