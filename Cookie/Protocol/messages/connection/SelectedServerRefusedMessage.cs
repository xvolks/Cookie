using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SelectedServerRefusedMessage : NetworkMessage
    {
        public const uint ProtocolId = 41;
        public override uint MessageID { get { return ProtocolId; } }

        public short ServerId = 0;
        public byte Error = 1;
        public byte ServerStatus = 1;

        public SelectedServerRefusedMessage()
        {
        }

        public SelectedServerRefusedMessage(
            short serverId,
            byte error,
            byte serverStatus
        )
        {
            ServerId = serverId;
            Error = error;
            ServerStatus = serverStatus;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ServerId);
            writer.WriteByte(Error);
            writer.WriteByte(ServerStatus);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ServerId = reader.ReadVarShort();
            Error = reader.ReadByte();
            ServerStatus = reader.ReadByte();
        }
    }
}