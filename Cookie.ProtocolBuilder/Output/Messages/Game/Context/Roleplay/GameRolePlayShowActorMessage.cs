namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class GameRolePlayShowActorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5632;
        public override ushort MessageID => ProtocolId;
        public GameRolePlayActorInformations Informations { get; set; }

        public GameRolePlayShowActorMessage(GameRolePlayActorInformations informations)
        {
            Informations = informations;
        }

        public GameRolePlayShowActorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Informations.TypeID);
            Informations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Informations = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadUShort());
            Informations.Deserialize(reader);
        }

    }
}
