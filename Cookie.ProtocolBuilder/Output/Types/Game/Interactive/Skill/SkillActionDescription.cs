namespace Cookie.API.Protocol.Network.Types.Game.Interactive.Skill
{
    using Utils.IO;

    public class SkillActionDescription : NetworkType
    {
        public const ushort ProtocolId = 102;
        public override ushort TypeID => ProtocolId;
        public ushort SkillId { get; set; }

        public SkillActionDescription(ushort skillId)
        {
            SkillId = skillId;
        }

        public SkillActionDescription() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SkillId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SkillId = reader.ReadVarUhShort();
        }

    }
}
