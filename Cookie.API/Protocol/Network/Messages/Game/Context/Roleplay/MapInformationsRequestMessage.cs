using Cookie.API.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class MapInformationsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 225;

        public MapInformationsRequestMessage()
        {
        }

        public MapInformationsRequestMessage(int mapId)
        {
            MapId = mapId;
        }

        public override uint MessageID => ProtocolId;

        public int MapId { get; set; }

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