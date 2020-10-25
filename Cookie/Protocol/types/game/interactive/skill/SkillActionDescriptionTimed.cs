using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class SkillActionDescriptionTimed : SkillActionDescription
    {
        public new const short ProtocolId = 103;
        public override short TypeId { get { return ProtocolId; } }

        public byte Time = 0;

        public SkillActionDescriptionTimed(): base()
        {
        }

        public SkillActionDescriptionTimed(
            short skillId,
            byte time
        ): base(
            skillId
        )
        {
            Time = time;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Time);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Time = reader.ReadByte();
        }
    }
}