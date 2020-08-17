namespace Cookie.API.Protocol.Network.Types.Game.Character
{
    using Types.Game.Look;
    using Utils.IO;

    public class CharacterMinimalPlusLookAndGradeInformations : CharacterMinimalPlusLookInformations
    {
        public new const ushort ProtocolId = 193;
        public override ushort TypeID => ProtocolId;
        public uint Grade { get; set; }

        public CharacterMinimalPlusLookAndGradeInformations(uint grade)
        {
            Grade = grade;
        }

        public CharacterMinimalPlusLookAndGradeInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Grade);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Grade = reader.ReadVarUhInt();
        }

    }
}
