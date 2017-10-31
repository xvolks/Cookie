namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Utils.IO;

    public class ChangeMapMessage : NetworkMessage
    {
        public const ushort ProtocolId = 221;
        public override ushort MessageID => ProtocolId;
        public double MapId { get; set; }

        public ChangeMapMessage(double mapId)
        {
            MapId = mapId;
        }

        public ChangeMapMessage() { }

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
