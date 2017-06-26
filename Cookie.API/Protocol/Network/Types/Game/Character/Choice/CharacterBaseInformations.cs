using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character.Choice
{
    public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
    {
        public new const short ProtocolId = 45;

        public CharacterBaseInformations()
        {
        }

        public CharacterBaseInformations(sbyte breed, bool sex)
        {
            Breed = breed;
            Sex = sex;
        }

        public override short TypeID => ProtocolId;

        public sbyte Breed { get; set; }
        public bool Sex { get; set; }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
        }
    }
}