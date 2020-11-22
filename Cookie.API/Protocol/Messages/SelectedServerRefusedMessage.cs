using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SelectedServerRefusedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 41;

        public override ushort MessageID => ProtocolId;

        public ushort ServerId { get; set; }
        public sbyte Error { get; set; }
        public sbyte ServerStatus { get; set; }
        public SelectedServerRefusedMessage() { }

        public SelectedServerRefusedMessage( ushort ServerId, sbyte Error, sbyte ServerStatus ){
            this.ServerId = ServerId;
            this.Error = Error;
            this.ServerStatus = ServerStatus;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ServerId);
            writer.WriteSByte(Error);
            writer.WriteSByte(ServerStatus);
        }

        public override void Deserialize(IDataReader reader)
        {
            ServerId = reader.ReadVarUhShort();
            Error = reader.ReadSByte();
            ServerStatus = reader.ReadSByte();
        }
    }
}
