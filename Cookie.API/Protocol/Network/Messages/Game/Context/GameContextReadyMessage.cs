using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameContextReadyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6071;

        public GameContextReadyMessage(double mapId)
        {
            MapId = mapId;
        }

        public GameContextReadyMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double MapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
        }
    }
}