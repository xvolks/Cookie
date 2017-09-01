using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Zaap
{
    public class TeleportRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5961;

        public TeleportRequestMessage(byte teleporterType, int mapId)
        {
            TeleporterType = teleporterType;
            MapId = mapId;
        }

        public TeleportRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte TeleporterType { get; set; }
        public int MapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(TeleporterType);
            writer.WriteInt(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TeleporterType = reader.ReadByte();
            MapId = reader.ReadInt();
        }
    }
}