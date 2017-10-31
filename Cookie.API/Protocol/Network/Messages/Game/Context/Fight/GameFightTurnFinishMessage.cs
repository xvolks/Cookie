namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightTurnFinishMessage : NetworkMessage
    {
        public const ushort ProtocolId = 718;
        public override ushort MessageID => ProtocolId;
        public bool IsAfk { get; set; }

        public GameFightTurnFinishMessage(bool isAfk)
        {
            IsAfk = isAfk;
        }

        public GameFightTurnFinishMessage() { }

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
