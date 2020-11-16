using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameMapMovementConfirmMessage : NetworkMessage
    {
        public const uint ProtocolId = 952;
        public override uint MessageID { get { return ProtocolId; } }

        public GameMapMovementConfirmMessage()
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