namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class GameContextRemoveElementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 251;
        public override ushort MessageID => ProtocolId;
        public double ObjectId { get; set; }

        public GameContextRemoveElementMessage(double objectId)
        {
            ObjectId = objectId;
        }

        public GameContextRemoveElementMessage() { }

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
