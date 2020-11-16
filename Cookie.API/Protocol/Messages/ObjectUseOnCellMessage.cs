using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectUseOnCellMessage : ObjectUseMessage
    {
        public new const ushort ProtocolId = 3013;

        public override ushort MessageID => ProtocolId;

        public ushort Cells { get; set; }
        public ObjectUseOnCellMessage() { }

        public ObjectUseOnCellMessage( ushort Cells ){
            this.Cells = Cells;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Cells);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Cells = reader.ReadVarUhShort();
        }
    }
}
