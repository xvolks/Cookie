namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Challenge
{
    using Utils.IO;

    public class ChallengeTargetsListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5614;
        public override ushort MessageID => ProtocolId;
        public ushort ChallengeId { get; set; }

        public ChallengeTargetsListRequestMessage(ushort challengeId)
        {
            ChallengeId = challengeId;
        }

        public ChallengeTargetsListRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ChallengeId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ChallengeId = reader.ReadVarUhShort();
        }

    }
}
