using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightPlacementSwapPositionsRequestMessage : GameFightPlacementPositionRequestMessage
    {
        public new const ushort ProtocolId = 6541;

        public GameFightPlacementSwapPositionsRequestMessage(double requestedId)
        {
            RequestedId = requestedId;
        }

        public GameFightPlacementSwapPositionsRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double RequestedId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(RequestedId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            RequestedId = reader.ReadDouble();
        }
    }
}