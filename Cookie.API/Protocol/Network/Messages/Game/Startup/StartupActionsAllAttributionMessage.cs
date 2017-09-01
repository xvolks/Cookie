using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Startup
{
    public class StartupActionsAllAttributionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6537;

        public StartupActionsAllAttributionMessage(ulong characterId)
        {
            CharacterId = characterId;
        }

        public StartupActionsAllAttributionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong CharacterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharacterId = reader.ReadVarUhLong();
        }
    }
}