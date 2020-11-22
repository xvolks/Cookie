using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismFightSwapRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5901;

        public override ushort MessageID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public ulong TargetId { get; set; }
        public PrismFightSwapRequestMessage() { }

        public PrismFightSwapRequestMessage( ushort SubAreaId, ulong TargetId ){
            this.SubAreaId = SubAreaId;
            this.TargetId = TargetId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteVarUhLong(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            TargetId = reader.ReadVarUhLong();
        }
    }
}
