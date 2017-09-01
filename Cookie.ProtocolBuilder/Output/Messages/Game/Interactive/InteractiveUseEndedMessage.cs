namespace Cookie.API.Protocol.Network.Messages.Game.Interactive
{
    using Utils.IO;

    public class InteractiveUseEndedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6112;
        public override ushort MessageID => ProtocolId;
        public uint ElemId { get; set; }
        public ushort SkillId { get; set; }

        public InteractiveUseEndedMessage(uint elemId, ushort skillId)
        {
            ElemId = elemId;
            SkillId = skillId;
        }

        public InteractiveUseEndedMessage() { }

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
