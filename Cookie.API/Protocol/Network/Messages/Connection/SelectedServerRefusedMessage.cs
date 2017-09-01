using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class SelectedServerRefusedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 41;

        public SelectedServerRefusedMessage(ushort serverId, byte error, byte serverStatus)
        {
            ServerId = serverId;
            Error = error;
            ServerStatus = serverStatus;
        }

        public SelectedServerRefusedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ServerId { get; set; }
        public byte Error { get; set; }
        public byte ServerStatus { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ServerId);
            writer.WriteByte(Error);
            writer.WriteByte(ServerStatus);
        }

        public override void Deserialize(IDataReader reader)
        {
            ServerId = reader.ReadVarUhShort();
            Error = reader.ReadByte();
            ServerStatus = reader.ReadByte();
        }
    }
}