namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Utils.IO;

    public class ErrorMapNotFoundMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6197;
        public override ushort MessageID => ProtocolId;
        public int MapId { get; set; }

        public ErrorMapNotFoundMessage(int mapId)
        {
            MapId = mapId;
        }

        public ErrorMapNotFoundMessage() { }

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
