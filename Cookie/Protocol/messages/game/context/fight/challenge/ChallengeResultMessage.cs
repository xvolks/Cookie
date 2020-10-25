using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChallengeResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 6019;
        public override uint MessageID { get { return ProtocolId; } }

        public short ChallengeId = 0;
        public bool Success = false;

        public ChallengeResultMessage()
        {
        }

        public ChallengeResultMessage(
            short challengeId,
            bool success
        )
        {
            ChallengeId = challengeId;
            Success = success;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ChallengeId);
            writer.WriteBoolean(Success);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ChallengeId = reader.ReadVarShort();
            Success = reader.ReadBoolean();
        }
    }
}