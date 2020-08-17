namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Zaap
{
    using Utils.IO;

    public class ZaapRespawnUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6571;
        public override ushort MessageID => ProtocolId;
        public int MapId { get; set; }

        public ZaapRespawnUpdatedMessage(int mapId)
        {
            MapId = mapId;
        }

        public ZaapRespawnUpdatedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadInt();
        }

    }
}
