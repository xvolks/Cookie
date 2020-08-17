using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character.Status
{
    public class PlayerStatus : NetworkType
    {
        public const ushort ProtocolId = 415;

        public PlayerStatus(byte statusId)
        {
            StatusId = statusId;
        }

        public PlayerStatus()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte StatusId { get; set; }

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