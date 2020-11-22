using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayPlayerFightFriendlyRequestedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5937;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;
        public long SourceId = 0;
        public long TargetId = 0;

        public GameRolePlayPlayerFightFriendlyRequestedMessage()
        {
        }

        public GameRolePlayPlayerFightFriendlyRequestedMessage(
            short fightId,
            long sourceId,
            long targetId
        )
        {
            FightId = fightId;
            SourceId = sourceId;
            TargetId = targetId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            writer.WriteVarLong(SourceId);
            writer.WriteVarLong(TargetId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            SourceId = reader.ReadVarLong();
            TargetId = reader.ReadVarLong();
        }
    }
}