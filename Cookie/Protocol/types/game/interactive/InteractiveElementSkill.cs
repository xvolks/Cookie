using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class InteractiveElementSkill : NetworkType
    {
        public const short ProtocolId = 219;
        public override short TypeId { get { return ProtocolId; } }

        public int SkillId = 0;
        public int SkillInstanceUid = 0;

        public InteractiveElementSkill()
        {
        }

        public InteractiveElementSkill(
            int skillId,
            int skillInstanceUid
        )
        {
            SkillId = skillId;
            SkillInstanceUid = skillInstanceUid;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(SkillId);
            writer.WriteInt(SkillInstanceUid);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SkillId = reader.ReadVarInt();
            SkillInstanceUid = reader.ReadInt();
        }
    }
}