using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class SkillActionDescription : NetworkType
    {
        public const short ProtocolId = 102;
        public override short TypeId { get { return ProtocolId; } }

        public short SkillId = 0;

        public SkillActionDescription()
        {
        }

        public SkillActionDescription(
            short skillId
        )
        {
            SkillId = skillId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SkillId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SkillId = reader.ReadVarShort();
        }
    }
}