using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Interactive.Skill
{
    public class SkillActionDescription : NetworkType
    {
        public const ushort ProtocolId = 102;

        public SkillActionDescription(ushort skillId)
        {
            SkillId = skillId;
        }

        public SkillActionDescription()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort SkillId { get; set; }

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