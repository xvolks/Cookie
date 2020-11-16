using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectItemGenericQuantity : Item
    {
        public new const ushort ProtocolId = 483;

        public override ushort TypeID => ProtocolId;

        public ushort ObjectGID { get; set; }
        public uint Quantity { get; set; }
        public ObjectItemGenericQuantity() { }

        public ObjectItemGenericQuantity( ushort ObjectGID, uint Quantity ){
            this.ObjectGID = ObjectGID;
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ObjectGID);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarUhShort();
            Quantity = reader.ReadVarUhInt();
        }
    }
}
