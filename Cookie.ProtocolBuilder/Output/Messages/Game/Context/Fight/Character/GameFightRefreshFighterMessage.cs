namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Character
{
    using Types.Game.Context;
    using Utils.IO;

    public class GameFightRefreshFighterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6309;
        public override ushort MessageID => ProtocolId;
        public GameContextActorInformations Informations { get; set; }

        public GameFightRefreshFighterMessage(GameContextActorInformations informations)
        {
            Informations = informations;
        }

        public GameFightRefreshFighterMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Informations.TypeID);
            Informations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Informations = ProtocolTypeManager.GetInstance<GameContextActorInformations>(reader.ReadUShort());
            Informations.Deserialize(reader);
        }

    }
}
