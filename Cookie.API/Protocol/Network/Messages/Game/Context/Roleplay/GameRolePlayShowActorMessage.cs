using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class GameRolePlayShowActorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5632;

        public GameRolePlayShowActorMessage(GameRolePlayActorInformations informations)
        {
            Informations = informations;
        }

        public GameRolePlayShowActorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public GameRolePlayActorInformations Informations { get; set; }

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