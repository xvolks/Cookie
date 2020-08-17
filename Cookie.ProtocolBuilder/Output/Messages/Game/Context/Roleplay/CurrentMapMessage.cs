namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Utils.IO;

    public class CurrentMapMessage : NetworkMessage
    {
        public const ushort ProtocolId = 220;
        public override ushort MessageID => ProtocolId;
        public int MapId { get; set; }
        public string MapKey { get; set; }

        public CurrentMapMessage(int mapId, string mapKey)
        {
            MapId = mapId;
            MapKey = mapKey;
        }

        public CurrentMapMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(MapId);
            writer.WriteUTF(MapKey);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadInt();
            MapKey = reader.ReadUTF();
        }

    }
}
