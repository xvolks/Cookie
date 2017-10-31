namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightPlacementSwapPositionsCancelMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6543;
        public override ushort MessageID => ProtocolId;
        public int RequestId { get; set; }

        public GameFightPlacementSwapPositionsCancelMessage(int requestId)
        {
            RequestId = requestId;
        }

        public GameFightPlacementSwapPositionsCancelMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RequestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadInt();
        }

    }
}
