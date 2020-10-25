using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChallengeTargetsListRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5614;
        public override uint MessageID { get { return ProtocolId; } }

        public short ChallengeId = 0;

        public ChallengeTargetsListRequestMessage()
        {
        }

        public ChallengeTargetsListRequestMessage(
            short challengeId
        )
        {
            ChallengeId = challengeId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ChallengeId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ChallengeId = reader.ReadVarShort();
        }
    }
}