using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Interactive.Skill
{
    public class SkillActionDescriptionTimed : SkillActionDescription
    {
        public new const ushort ProtocolId = 103;

        public SkillActionDescriptionTimed(byte time)
        {
            Time = time;
        }

        public SkillActionDescriptionTimed()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte Time { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Time);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Time = reader.ReadByte();
        }
    }
}