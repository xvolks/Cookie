using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectItemQuantity : Item
    {
        public new const ushort ProtocolId = 119;

        public override ushort TypeID => ProtocolId;

        public uint ObjectUID { get; set; }
        public uint Quantity { get; set; }
        public ObjectItemQuantity() { }

        public ObjectItemQuantity( uint ObjectUID, uint Quantity ){
            this.ObjectUID = ObjectUID;
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectUID = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
        }
    }
}
