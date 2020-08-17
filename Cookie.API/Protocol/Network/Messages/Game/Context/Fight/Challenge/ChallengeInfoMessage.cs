using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Challenge
{
    public class ChallengeInfoMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6022;

        public ChallengeInfoMessage(ushort challengeId, double targetId, uint xpBonus, uint dropBonus)
        {
            ChallengeId = challengeId;
            TargetId = targetId;
            XpBonus = xpBonus;
            DropBonus = dropBonus;
        }

        public ChallengeInfoMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ChallengeId { get; set; }
        public double TargetId { get; set; }
        public uint XpBonus { get; set; }
        public uint DropBonus { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ChallengeId);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhInt(XpBonus);
            writer.WriteVarUhInt(DropBonus);
        }

        public override void Deserialize(IDataReader reader)
        {
            ChallengeId = reader.ReadVarUhShort();
            TargetId = reader.ReadDouble();
            XpBonus = reader.ReadVarUhInt();
            DropBonus = reader.ReadVarUhInt();
        }
    }
}