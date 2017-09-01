using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Interactive.Skill
{
    public class SkillActionDescriptionCollect : SkillActionDescriptionTimed
    {
        public new const ushort ProtocolId = 99;

        public SkillActionDescriptionCollect(ushort min, ushort max)
        {
            Min = min;
            Max = max;
        }

        public SkillActionDescriptionCollect()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort Min { get; set; }
        public ushort Max { get; set; }

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