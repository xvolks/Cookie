using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayFightRequestCanceledMessage : NetworkMessage
    {
        public const uint ProtocolId = 5822;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;
        public double SourceId = 0;
        public double TargetId = 0;

        public GameRolePlayFightRequestCanceledMessage()
        {
        }

        public GameRolePlayFightRequestCanceledMessage(
            short fightId,
            double sourceId,
            double targetId
        )
        {
            FightId = fightId;
            SourceId = sourceId;
            TargetId = targetId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            writer.WriteDouble(SourceId);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            SourceId = reader.ReadDouble();
            TargetId = reader.ReadDouble();
        }
    }
}