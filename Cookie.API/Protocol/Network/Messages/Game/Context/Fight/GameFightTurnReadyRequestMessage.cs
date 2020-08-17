using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightTurnReadyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 715;

        public GameFightTurnReadyRequestMessage(double objectId)
        {
            ObjectId = objectId;
        }

        public GameFightTurnReadyRequestMessage()
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