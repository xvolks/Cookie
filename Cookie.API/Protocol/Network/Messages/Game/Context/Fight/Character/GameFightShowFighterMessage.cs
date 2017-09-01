using Cookie.API.Protocol.Network.Types.Game.Context.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Character
{
    public class GameFightShowFighterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5864;

        public GameFightShowFighterMessage(GameFightFighterInformations informations)
        {
            Informations = informations;
        }

        public GameFightShowFighterMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public GameFightFighterInformations Informations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Informations.TypeID);
            Informations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Informations = ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadUShort());
            Informations.Deserialize(reader);
        }
    }
}