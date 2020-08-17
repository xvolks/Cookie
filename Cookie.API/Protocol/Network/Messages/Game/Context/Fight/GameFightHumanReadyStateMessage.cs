using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightHumanReadyStateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 740;

        public GameFightHumanReadyStateMessage(ulong characterId, bool isReady)
        {
            CharacterId = characterId;
            IsReady = isReady;
        }

        public GameFightHumanReadyStateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong CharacterId { get; set; }
        public bool IsReady { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(CharacterId);
            writer.WriteBoolean(IsReady);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharacterId = reader.ReadVarUhLong();
            IsReady = reader.ReadBoolean();
        }
    }
}