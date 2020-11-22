using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class SkillActionDescription : NetworkType
    {
        public const ushort ProtocolId = 102;

        public override ushort TypeID => ProtocolId;

        public ushort SkillId { get; set; }
        public SkillActionDescription() { }

        public SkillActionDescription( ushort SkillId ){
            this.SkillId = SkillId;
        }

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
