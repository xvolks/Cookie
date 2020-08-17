namespace Cookie.API.Protocol.Network.Types.Game.Character.Status
{
    using Utils.IO;

    public class PlayerStatus : NetworkType
    {
        public const ushort ProtocolId = 415;
        public override ushort TypeID => ProtocolId;
        public byte StatusId { get; set; }

        public PlayerStatus(byte statusId)
        {
            StatusId = statusId;
        }

        public PlayerStatus() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(StatusId);
        }

        public override void Deserialize(IDataReader reader)
        {
            StatusId = reader.ReadByte();
        }

    }
}
