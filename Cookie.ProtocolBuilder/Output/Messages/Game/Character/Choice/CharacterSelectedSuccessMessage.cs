namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    using Types.Game.Character.Choice;
    using Utils.IO;

    public class CharacterSelectedSuccessMessage : NetworkMessage
    {
        public const ushort ProtocolId = 153;
        public override ushort MessageID => ProtocolId;
        public CharacterBaseInformations Infos { get; set; }
        public bool IsCollectingStats { get; set; }

        public CharacterSelectedSuccessMessage(CharacterBaseInformations infos, bool isCollectingStats)
        {
            Infos = infos;
            IsCollectingStats = isCollectingStats;
        }

        public CharacterSelectedSuccessMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Infos.Serialize(writer);
            writer.WriteBoolean(IsCollectingStats);
        }

        public override void Deserialize(IDataReader reader)
        {
            Infos = new CharacterBaseInformations();
            Infos.Deserialize(reader);
            IsCollectingStats = reader.ReadBoolean();
        }

    }
}
