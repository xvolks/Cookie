using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeObjectRemovedFromBagMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 6010;

        public override ushort MessageID => ProtocolId;

        public uint ObjectUID { get; set; }
        public ExchangeObjectRemovedFromBagMessage() { }

        public ExchangeObjectRemovedFromBagMessage( uint ObjectUID ){
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
