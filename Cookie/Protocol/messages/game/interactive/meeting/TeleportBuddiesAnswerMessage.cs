using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TeleportBuddiesAnswerMessage : NetworkMessage
    {
        public const uint ProtocolId = 6294;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Accept = false;

        public TeleportBuddiesAnswerMessage()
        {
        }

        public TeleportBuddiesAnswerMessage(
            bool accept
        )
        {
            Accept = accept;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Accept = reader.ReadBoolean();
        }
    }
}