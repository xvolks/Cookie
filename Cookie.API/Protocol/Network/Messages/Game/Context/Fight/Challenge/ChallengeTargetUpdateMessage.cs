using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Challenge
{
    public class ChallengeTargetUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6123;

        public ChallengeTargetUpdateMessage(ushort challengeId, double targetId)
        {
            ChallengeId = challengeId;
            TargetId = targetId;
        }

        public ChallengeTargetUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ChallengeId { get; set; }
        public double TargetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ChallengeId);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ChallengeId = reader.ReadVarUhShort();
            TargetId = reader.ReadDouble();
        }
    }
}