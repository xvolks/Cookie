using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectUseMultipleMessage : ObjectUseMessage
    {
        public new const ushort ProtocolId = 6234;

        public override ushort MessageID => ProtocolId;

        public uint Quantity { get; set; }
        public ObjectUseMultipleMessage() { }

        public ObjectUseMultipleMessage( uint Quantity ){
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
