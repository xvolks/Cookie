using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    public class CurrentServerStatusUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6525;

        public CurrentServerStatusUpdateMessage(byte status)
        {
            Status = status;
        }

        public CurrentServerStatusUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Status { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Status);
        }

        public override void Deserialize(IDataReader reader)
        {
            Status = reader.ReadByte();
        }
    }
}