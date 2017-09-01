namespace Cookie.API.Protocol.Network.Types.Game.Interactive.Skill
{
    using Utils.IO;

    public class SkillActionDescriptionCraft : SkillActionDescription
    {
        public new const ushort ProtocolId = 100;
        public override ushort TypeID => ProtocolId;
        public byte Probability { get; set; }

        public SkillActionDescriptionCraft(byte probability)
        {
            Probability = probability;
        }

        public SkillActionDescriptionCraft() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Probability);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Probability = reader.ReadByte();
        }

    }
}
