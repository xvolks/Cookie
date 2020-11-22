using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class SkillActionDescriptionCollect : SkillActionDescriptionTimed
    {
        public new const short ProtocolId = 99;
        public override short TypeId { get { return ProtocolId; } }

        public short Min = 0;
        public short Max = 0;

        public SkillActionDescriptionCollect(): base()
        {
        }

        public SkillActionDescriptionCollect(
            short skillId,
            byte time,
            short min,
            short max
        ): base(
            skillId,
            time
        )
        {
            Min = min;
            Max = max;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Min);
            writer.WriteVarShort(Max);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Min = reader.ReadVarShort();
            Max = reader.ReadVarShort();
        }
    }
}