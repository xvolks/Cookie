using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TeleportOnSameMapMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6048;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public ushort CellId { get; set; }
        public TeleportOnSameMapMessage() { }

        public TeleportOnSameMapMessage( double TargetId, ushort CellId ){
            this.TargetId = TargetId;
            this.CellId = CellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(TargetId);
            writer.WriteVarUhShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TargetId = reader.ReadDouble();
            CellId = reader.ReadVarUhShort();
        }
    }
}
