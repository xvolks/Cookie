using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeObjectRemovedMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 5517;

        public override ushort MessageID => ProtocolId;

        public uint ObjectUID { get; set; }
        public ExchangeObjectRemovedMessage() { }

        public ExchangeObjectRemovedMessage( uint ObjectUID ){
            this.ObjectUID = ObjectUID;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(ObjectUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectUID = reader.ReadVarUhInt();
        }
    }
}
