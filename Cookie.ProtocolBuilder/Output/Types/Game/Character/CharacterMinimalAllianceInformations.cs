namespace Cookie.API.Protocol.Network.Types.Game.Character
{
    using Types.Game.Context.Roleplay;
    using Types.Game.Context.Roleplay;
    using Types.Game.Look;
    using Utils.IO;

    public class CharacterMinimalAllianceInformations : CharacterMinimalGuildInformations
    {
        public new const ushort ProtocolId = 444;
        public override ushort TypeID => ProtocolId;
        public BasicAllianceInformations Alliance { get; set; }

        public CharacterMinimalAllianceInformations(BasicAllianceInformations alliance)
        {
            Alliance = alliance;
        }

        public CharacterMinimalAllianceInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Alliance = new BasicAllianceInformations();
            Alliance.Deserialize(reader);
        }

    }
}
