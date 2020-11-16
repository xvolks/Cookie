using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HumanOptionSkillUse : HumanOption
    {
        public new const short ProtocolId = 495;
        public override short TypeId { get { return ProtocolId; } }

        public int ElementId = 0;
        public short SkillId = 0;
        public double SkillEndTime = 0;

        public HumanOptionSkillUse(): base()
        {
        }

        public HumanOptionSkillUse(
            int elementId,
            short skillId,
            double skillEndTime
        ): base()
        {
            ElementId = elementId;
            SkillId = skillId;
            SkillEndTime = skillEndTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(ElementId);
            writer.WriteVarShort(SkillId);
            writer.WriteDouble(SkillEndTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ElementId = reader.ReadVarInt();
            SkillId = reader.ReadVarShort();
            SkillEndTime = reader.ReadDouble();
        }
    }
}