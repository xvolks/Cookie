using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class SkillActionDescriptionCollect : SkillActionDescriptionTimed
    {
        public new const ushort ProtocolId = 99;

        public override ushort TypeID => ProtocolId;

        public ushort Min { get; set; }
        public ushort Max { get; set; }
        public SkillActionDescriptionCollect() { }

        public SkillActionDescriptionCollect( ushort Min, ushort Max ){
            this.Min = Min;
            this.Max = Max;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Min);
            writer.WriteVarUhShort(Max);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Min = reader.ReadVarUhShort();
            Max = reader.ReadVarUhShort();
        }
    }
}
