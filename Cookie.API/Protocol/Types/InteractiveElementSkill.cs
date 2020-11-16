using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class InteractiveElementSkill : NetworkType
    {
        public const ushort ProtocolId = 219;

        public override ushort TypeID => ProtocolId;

        public uint SkillId { get; set; }
        public int SkillInstanceUid { get; set; }
        public InteractiveElementSkill() { }

        public InteractiveElementSkill( uint SkillId, int SkillInstanceUid ){
            this.SkillId = SkillId;
            this.SkillInstanceUid = SkillInstanceUid;
        }

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
