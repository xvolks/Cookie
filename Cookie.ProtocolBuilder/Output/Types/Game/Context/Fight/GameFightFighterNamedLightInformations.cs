namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightFighterNamedLightInformations : GameFightFighterLightInformations
    {
        public new const ushort ProtocolId = 456;
        public override ushort TypeID => ProtocolId;
        public string Name { get; set; }

        public GameFightFighterNamedLightInformations(string name)
        {
            Name = name;
        }

        public GameFightFighterNamedLightInformations() { }

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
