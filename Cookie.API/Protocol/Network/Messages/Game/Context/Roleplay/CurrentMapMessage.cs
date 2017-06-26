using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class CurrentMapMessage : NetworkMessage
    {
        public const uint ProtocolId = 220;

        public CurrentMapMessage()
        {
        }

        public CurrentMapMessage(int mapId, string mapKey)
        {
            MapId = mapId;
            MapKey = mapKey;
        }

        public override uint MessageID => ProtocolId;

        public int MapId { get; set; }
        public string MapKey { get; set; }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(MapId);
            writer.WriteUTF(MapKey);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            _mapIdFunc(reader);
            _mapKeyFunc(reader);
        }

        private void _mapIdFunc(ICustomDataInput reader)
        {
            MapId = reader.ReadInt();
        }

        private void _mapKeyFunc(ICustomDataInput reader)
        {
            MapKey = reader.ReadUTF();
        }
    }
}