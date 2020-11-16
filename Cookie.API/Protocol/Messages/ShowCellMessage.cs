using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ShowCellMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5612;

        public override ushort MessageID => ProtocolId;

        public double SourceId { get; set; }
        public ushort CellId { get; set; }
        public ShowCellMessage() { }

        public ShowCellMessage( double SourceId, ushort CellId ){
            this.SourceId = SourceId;
            this.CellId = CellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(SourceId);
            writer.WriteVarUhShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SourceId = reader.ReadDouble();
            CellId = reader.ReadVarUhShort();
        }
    }
}
