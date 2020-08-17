using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Zaap
{
    public class ZaapListMessage : TeleportDestinationsListMessage
    {
        public new const ushort ProtocolId = 1604;

        public ZaapListMessage(int spawnMapId)
        {
            SpawnMapId = spawnMapId;
        }

        public ZaapListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int SpawnMapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(SpawnMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpawnMapId = reader.ReadInt();
        }
    }
}