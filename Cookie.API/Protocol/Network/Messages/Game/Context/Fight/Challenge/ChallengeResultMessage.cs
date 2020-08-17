using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Challenge
{
    public class ChallengeResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6019;

        public ChallengeResultMessage(ushort challengeId, bool success)
        {
            ChallengeId = challengeId;
            Success = success;
        }

        public ChallengeResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ChallengeId { get; set; }
        public bool Success { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ChallengeId);
            writer.WriteBoolean(Success);
        }

        public override void Deserialize(IDataReader reader)
        {
            ChallengeId = reader.ReadVarUhShort();
            Success = reader.ReadBoolean();
        }
    }
}