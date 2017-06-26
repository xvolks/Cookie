using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character
{
    public class CharacterBasicMinimalInformations : AbstractCharacterInformation
    {
        public new const short ProtocolId = 503;

        public CharacterBasicMinimalInformations()
        {
        }

        public CharacterBasicMinimalInformations(string name)
        {
            Name = name;
        }

        public override short TypeID => ProtocolId;

        public string Name { get; set; }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
        }
    }
}