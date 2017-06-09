using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class MapInformationsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 225;
        public override uint MessageID { get { return ProtocolId; } }

        public int MapId { get; set; }

        public MapInformationsRequestMessage() { }

        public MapInformationsRequestMessage(int mapId)
        {
            MapId = mapId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(MapId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            _mapIdFunc(reader);
        }

        private void _mapIdFunc(ICustomDataInput reader)
        {
            MapId = reader.ReadInt();
        }
    }
}
