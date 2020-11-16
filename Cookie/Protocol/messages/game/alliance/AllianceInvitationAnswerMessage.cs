using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceInvitationAnswerMessage : NetworkMessage
    {
        public const uint ProtocolId = 6401;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Accept = false;

        public AllianceInvitationAnswerMessage()
        {
        }

        public AllianceInvitationAnswerMessage(
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