using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class ErrorMapNotFoundMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6197;

        public ErrorMapNotFoundMessage(double mapId)
        {
            MapId = mapId;
        }

        public ErrorMapNotFoundMessage()
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