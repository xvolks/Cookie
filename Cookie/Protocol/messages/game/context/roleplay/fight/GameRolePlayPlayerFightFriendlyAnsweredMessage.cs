using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayPlayerFightFriendlyAnsweredMessage : NetworkMessage
    {
        public const uint ProtocolId = 5733;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;
        public long SourceId = 0;
        public long TargetId = 0;
        public bool Accept = false;

        public GameRolePlayPlayerFightFriendlyAnsweredMessage()
        {
        }

        public GameRolePlayPlayerFightFriendlyAnsweredMessage(
            short fightId,
            long sourceId,
            long targetId,
            bool accept
        )
        {
            FightId = fightId;
            SourceId = sourceId;
            TargetId = targetId;
            Accept = accept;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            writer.WriteVarLong(SourceId);
            writer.WriteVarLong(TargetId);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            SourceId = reader.ReadVarLong();
            TargetId = reader.ReadVarLong();
            Accept = reader.ReadBoolean();
        }
    }
}