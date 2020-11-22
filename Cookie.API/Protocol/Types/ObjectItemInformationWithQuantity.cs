using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectItemInformationWithQuantity : ObjectItemMinimalInformation
    {
        public new const ushort ProtocolId = 387;

        public override ushort TypeID => ProtocolId;

        public uint Quantity { get; set; }
        public ObjectItemInformationWithQuantity() { }

        public ObjectItemInformationWithQuantity( uint Quantity ){
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Quantity = reader.ReadVarUhInt();
        }
    }
}
