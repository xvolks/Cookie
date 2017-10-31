namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Zaap
{
    using Utils.IO;

    public class ZaapRespawnUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6571;
        public override ushort MessageID => ProtocolId;
        public double MapId { get; set; }

        public ZaapRespawnUpdatedMessage(double mapId)
        {
            MapId = mapId;
        }

        public ZaapRespawnUpdatedMessage() { }

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
