using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightTeamMemberCharacterInformations : FightTeamMemberInformations
    {
        public new const ushort ProtocolId = 13;

        public FightTeamMemberCharacterInformations(string name, byte level)
        {
            Name = name;
            Level = level;
        }

        public FightTeamMemberCharacterInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public string Name { get; set; }
        public byte Level { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteByte(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Level = reader.ReadByte();
        }
    }
}