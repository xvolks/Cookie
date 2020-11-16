using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BasicAckMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6362;

        public override ushort MessageID => ProtocolId;

        public uint Seq { get; set; }
        public ushort LastPacketId { get; set; }
        public BasicAckMessage() { }

        public BasicAckMessage( uint Seq, ushort LastPacketId ){
            this.Seq = Seq;
            this.LastPacketId = LastPacketId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Seq);
            writer.WriteVarUhShort(LastPacketId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Seq = reader.ReadVarUhInt();
            LastPacketId = reader.ReadVarUhShort();
        }
    }
}
