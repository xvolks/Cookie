namespace Cookie.API.Protocol.Network.Types.Game.Interactive
{
    using Utils.IO;

    public class InteractiveElementSkill : NetworkType
    {
        public const ushort ProtocolId = 219;
        public override ushort TypeID => ProtocolId;
        public uint SkillId { get; set; }
        public int SkillInstanceUid { get; set; }

        public InteractiveElementSkill(uint skillId, int skillInstanceUid)
        {
            SkillId = skillId;
            SkillInstanceUid = skillInstanceUid;
        }

        public InteractiveElementSkill() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(SkillId);
            writer.WriteInt(SkillInstanceUid);
        }

        public override void Deserialize(IDataReader reader)
        {
            SkillId = reader.ReadVarUhInt();
            SkillInstanceUid = reader.ReadInt();
        }

    }
}
