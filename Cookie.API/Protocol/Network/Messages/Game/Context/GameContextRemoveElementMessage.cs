using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameContextRemoveElementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 251;

        public GameContextRemoveElementMessage(double objectId)
        {
            ObjectId = objectId;
        }

        public GameContextRemoveElementMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double ObjectId { get; set; }

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