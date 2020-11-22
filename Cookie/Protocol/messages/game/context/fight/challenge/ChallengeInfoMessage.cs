using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChallengeInfoMessage : NetworkMessage
    {
        public const uint ProtocolId = 6022;
        public override uint MessageID { get { return ProtocolId; } }

        public short ChallengeId = 0;
        public double TargetId = 0;
        public int XpBonus = 0;
        public int DropBonus = 0;

        public ChallengeInfoMessage()
        {
        }

        public ChallengeInfoMessage(
            short challengeId,
            double targetId,
            int xpBonus,
            int dropBonus
        )
        {
            ChallengeId = challengeId;
            TargetId = targetId;
            XpBonus = xpBonus;
            DropBonus = dropBonus;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ChallengeId);
            writer.WriteDouble(TargetId);
            writer.WriteVarInt(XpBonus);
            writer.WriteVarInt(DropBonus);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ChallengeId = reader.ReadVarShort();
            TargetId = reader.ReadDouble();
            XpBonus = reader.ReadVarInt();
            DropBonus = reader.ReadVarInt();
        }
    }
}