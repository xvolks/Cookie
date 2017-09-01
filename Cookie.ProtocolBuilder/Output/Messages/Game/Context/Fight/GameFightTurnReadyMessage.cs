namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightTurnReadyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 716;
        public override ushort MessageID => ProtocolId;
        public bool IsReady { get; set; }

        public GameFightTurnReadyMessage(bool isReady)
        {
            IsReady = isReady;
        }

        public GameFightTurnReadyMessage() { }

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
