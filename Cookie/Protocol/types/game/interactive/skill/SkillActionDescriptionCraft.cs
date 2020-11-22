using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class SkillActionDescriptionCraft : SkillActionDescription
    {
        public new const short ProtocolId = 100;
        public override short TypeId { get { return ProtocolId; } }

        public byte Probability = 0;

        public SkillActionDescriptionCraft(): base()
        {
        }

        public SkillActionDescriptionCraft(
            short skillId,
            byte probability
        ): base(
            skillId
        )
        {
            Probability = probability;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Probability);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Probability = reader.ReadByte();
        }
    }
}