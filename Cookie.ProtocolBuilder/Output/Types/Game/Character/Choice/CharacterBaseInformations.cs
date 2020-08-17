namespace Cookie.API.Protocol.Network.Types.Game.Character.Choice
{
    using Types.Game.Character;
    using Types.Game.Look;
    using Utils.IO;

    public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
    {
        public new const ushort ProtocolId = 45;
        public override ushort TypeID => ProtocolId;
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }

        public CharacterBaseInformations(sbyte breed, bool sex)
        {
            Breed = breed;
            Sex = sex;
        }

        public CharacterBaseInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
        }

    }
}
