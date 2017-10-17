using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Zaap
{
    public class TeleportRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5961;

        public TeleportRequestMessage(byte teleporterType, double mapId)
        {
            TeleporterType = teleporterType;
            MapId = mapId;
        }

        public TeleportRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte TeleporterType { get; set; }
        public double MapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(TeleporterType);
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TeleporterType = reader.ReadByte();
            MapId = reader.ReadDouble();
        }
    }
}