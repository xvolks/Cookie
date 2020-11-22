using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayPlayerFightRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5731;
        public override uint MessageID { get { return ProtocolId; } }

        public long TargetId = 0;
        public short TargetCellId = 0;
        public bool Friendly = false;

        public GameRolePlayPlayerFightRequestMessage()
        {
        }

        public GameRolePlayPlayerFightRequestMessage(
            long targetId,
            short targetCellId,
            bool friendly
        )
        {
            TargetId = targetId;
            TargetCellId = targetCellId;
            Friendly = friendly;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(TargetId);
            writer.WriteShort(TargetCellId);
            writer.WriteBoolean(Friendly);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TargetId = reader.ReadVarLong();
            TargetCellId = reader.ReadShort();
            Friendly = reader.ReadBoolean();
        }
    }
}