using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightTurnReadyMessage : NetworkMessage
    {
        public const uint ProtocolId = 716;
        public override uint MessageID { get { return ProtocolId; } }

        public bool IsReady = false;

        public GameFightTurnReadyMessage()
        {
        }

        public GameFightTurnReadyMessage(
            bool isReady
        )
        {
            IsReady = isReady;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(IsReady);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            IsReady = reader.ReadBoolean();
        }
    }
}