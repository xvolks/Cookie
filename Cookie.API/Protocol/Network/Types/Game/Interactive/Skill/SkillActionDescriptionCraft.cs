using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Interactive.Skill
{
    public class SkillActionDescriptionCraft : SkillActionDescription
    {
        public new const ushort ProtocolId = 100;

        public SkillActionDescriptionCraft(byte probability)
        {
            Probability = probability;
        }

        public SkillActionDescriptionCraft()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte Probability { get; set; }

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