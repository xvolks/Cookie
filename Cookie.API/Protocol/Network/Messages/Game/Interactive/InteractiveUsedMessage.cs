using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive
{
    public class InteractiveUsedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5745;

        public InteractiveUsedMessage(ulong entityId, uint elemId, ushort skillId, ushort duration, bool canMove)
        {
            EntityId = entityId;
            ElemId = elemId;
            SkillId = skillId;
            Duration = duration;
            CanMove = canMove;
        }

        public InteractiveUsedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong EntityId { get; set; }
        public uint ElemId { get; set; }
        public ushort SkillId { get; set; }
        public ushort Duration { get; set; }
        public bool CanMove { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(EntityId);
            writer.WriteVarUhInt(ElemId);
            writer.WriteVarUhShort(SkillId);
            writer.WriteVarUhShort(Duration);
            writer.WriteBoolean(CanMove);
        }

        public override void Deserialize(IDataReader reader)
        {
            EntityId = reader.ReadVarUhLong();
            ElemId = reader.ReadVarUhInt();
            SkillId = reader.ReadVarUhShort();
            Duration = reader.ReadVarUhShort();
            CanMove = reader.ReadBoolean();
        }
    }
}