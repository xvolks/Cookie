using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive
{
    public class InteractiveUseEndedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6112;

        public InteractiveUseEndedMessage(uint elemId, ushort skillId)
        {
            ElemId = elemId;
            SkillId = skillId;
        }

        public InteractiveUseEndedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint ElemId { get; set; }
        public ushort SkillId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ElemId);
            writer.WriteVarUhShort(SkillId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ElemId = reader.ReadVarUhInt();
            SkillId = reader.ReadVarUhShort();
        }
    }
}