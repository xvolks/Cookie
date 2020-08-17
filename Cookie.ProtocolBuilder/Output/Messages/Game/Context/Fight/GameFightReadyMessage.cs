namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightReadyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 708;
        public override ushort MessageID => ProtocolId;
        public bool IsReady { get; set; }

        public GameFightReadyMessage(bool isReady)
        {
            IsReady = isReady;
        }

        public GameFightReadyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(IsReady);
        }

        public override void Deserialize(IDataReader reader)
        {
            IsReady = reader.ReadBoolean();
        }

    }
}
