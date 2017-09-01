using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Startup
{
    public class StartupActionsObjetAttributionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1303;

        public StartupActionsObjetAttributionMessage(int actionId, ulong characterId)
        {
            ActionId = actionId;
            CharacterId = characterId;
        }

        public StartupActionsObjetAttributionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int ActionId { get; set; }
        public ulong CharacterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ActionId);
            writer.WriteVarUhLong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadInt();
            CharacterId = reader.ReadVarUhLong();
        }
    }
}