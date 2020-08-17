using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightTurnFinishMessage : NetworkMessage
    {
        public const ushort ProtocolId = 718;

        public GameFightTurnFinishMessage(bool isAfk)
        {
            IsAfk = isAfk;
        }

        public GameFightTurnFinishMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool IsAfk { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(IsAfk);
        }

        public override void Deserialize(IDataReader reader)
        {
            IsAfk = reader.ReadBoolean();
        }
    }
}