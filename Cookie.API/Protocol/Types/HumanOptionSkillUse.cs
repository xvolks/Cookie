using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HumanOptionSkillUse : HumanOption
    {
        public new const ushort ProtocolId = 495;

        public override ushort TypeID => ProtocolId;

        public uint ElementId { get; set; }
        public ushort SkillId { get; set; }
        public double SkillEndTime { get; set; }
        public HumanOptionSkillUse() { }

        public HumanOptionSkillUse( uint ElementId, ushort SkillId, double SkillEndTime ){
            this.ElementId = ElementId;
            this.SkillId = SkillId;
            this.SkillEndTime = SkillEndTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(ElementId);
            writer.WriteVarUhShort(SkillId);
            writer.WriteDouble(SkillEndTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ElementId = reader.ReadVarUhInt();
            SkillId = reader.ReadVarUhShort();
            SkillEndTime = reader.ReadDouble();
        }
    }
}
