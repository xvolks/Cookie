namespace Cookie.API.Protocol.Network.Types.Game.Character
{
    using Utils.IO;

    public class CharacterBasicMinimalInformations : AbstractCharacterInformation
    {
        public new const ushort ProtocolId = 503;
        public override ushort TypeID => ProtocolId;
        public string Name { get; set; }

        public CharacterBasicMinimalInformations(string name)
        {
            Name = name;
        }

        public CharacterBasicMinimalInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
        }

    }
}
