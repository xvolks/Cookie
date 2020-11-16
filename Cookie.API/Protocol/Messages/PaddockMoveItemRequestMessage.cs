using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PaddockMoveItemRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6052;

        public override ushort MessageID => ProtocolId;

        public ushort OldCellId { get; set; }
        public ushort NewCellId { get; set; }
        public PaddockMoveItemRequestMessage() { }

        public PaddockMoveItemRequestMessage( ushort OldCellId, ushort NewCellId ){
            this.OldCellId = OldCellId;
            this.NewCellId = NewCellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(OldCellId);
            writer.WriteVarUhShort(NewCellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            OldCellId = reader.ReadVarUhShort();
            NewCellId = reader.ReadVarUhShort();
        }
    }
}
