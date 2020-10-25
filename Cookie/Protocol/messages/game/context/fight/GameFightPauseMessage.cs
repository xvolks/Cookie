using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightPauseMessage : NetworkMessage
    {
        public const uint ProtocolId = 6754;
        public override uint MessageID { get { return ProtocolId; } }

        public bool IsPaused = false;

        public GameFightPauseMessage()
        {
        }

        public GameFightPauseMessage(
            bool isPaused
        )
        {
            IsPaused = isPaused;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(IsPaused);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            IsPaused = reader.ReadBoolean();
        }
    }
}