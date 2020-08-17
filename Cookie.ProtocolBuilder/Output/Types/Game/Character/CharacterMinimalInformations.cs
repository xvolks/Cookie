namespace Cookie.API.Protocol.Network.Types.Game.Character
{
    using Utils.IO;

    public class CharacterMinimalInformations : CharacterBasicMinimalInformations
    {
        public new const ushort ProtocolId = 110;
        public override ushort TypeID => ProtocolId;
        public byte Level { get; set; }

        public CharacterMinimalInformations(byte level)
        {
            Level = level;
        }

        public CharacterMinimalInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadByte();
        }

    }
}
