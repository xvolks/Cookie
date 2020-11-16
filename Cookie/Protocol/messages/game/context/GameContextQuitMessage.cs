using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextQuitMessage : NetworkMessage
    {
        public const uint ProtocolId = 255;
        public override uint MessageID { get { return ProtocolId; } }

        public GameContextQuitMessage()
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