namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightTurnEndMessage : NetworkMessage
    {
        public const ushort ProtocolId = 719;
        public override ushort MessageID => ProtocolId;
        public double ObjectId { get; set; }

        public GameFightTurnEndMessage(double objectId)
        {
            ObjectId = objectId;
        }

        public GameFightTurnEndMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadDouble();
        }

    }
}
