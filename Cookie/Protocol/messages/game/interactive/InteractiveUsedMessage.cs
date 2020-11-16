using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class InteractiveUsedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5745;
        public override uint MessageID { get { return ProtocolId; } }

        public long EntityId = 0;
        public int ElemId = 0;
        public short SkillId = 0;
        public short Duration = 0;
        public bool CanMove = false;

        public InteractiveUsedMessage()
        {
        }

        public InteractiveUsedMessage(
            long entityId,
            int elemId,
            short skillId,
            short duration,
            bool canMove
        )
        {
            EntityId = entityId;
            ElemId = elemId;
            SkillId = skillId;
            Duration = duration;
            CanMove = canMove;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(EntityId);
            writer.WriteVarInt(ElemId);
            writer.WriteVarShort(SkillId);
            writer.WriteVarShort(Duration);
            writer.WriteBoolean(CanMove);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            EntityId = reader.ReadVarLong();
            ElemId = reader.ReadVarInt();
            SkillId = reader.ReadVarShort();
            Duration = reader.ReadVarShort();
            CanMove = reader.ReadBoolean();
        }
    }
}