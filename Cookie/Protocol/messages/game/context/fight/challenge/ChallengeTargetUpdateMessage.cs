using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChallengeTargetUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6123;
        public override uint MessageID { get { return ProtocolId; } }

        public short ChallengeId = 0;
        public double TargetId = 0;

        public ChallengeTargetUpdateMessage()
        {
        }

        public ChallengeTargetUpdateMessage(
            short challengeId,
            double targetId
        )
        {
            ChallengeId = challengeId;
            TargetId = targetId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ChallengeId);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ChallengeId = reader.ReadVarShort();
            TargetId = reader.ReadDouble();
        }
    }
}