namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Utils.IO;

    public class HumanOptionSkillUse : HumanOption
    {
        public new const ushort ProtocolId = 495;
        public override ushort TypeID => ProtocolId;
        public uint ElementId { get; set; }
        public ushort SkillId { get; set; }
        public double SkillEndTime { get; set; }

        public HumanOptionSkillUse(uint elementId, ushort skillId, double skillEndTime)
        {
            ElementId = elementId;
            SkillId = skillId;
            SkillEndTime = skillEndTime;
        }

        public HumanOptionSkillUse() { }

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
