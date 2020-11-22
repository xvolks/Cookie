using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeObjectPutInBagMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 6009;

        public override ushort MessageID => ProtocolId;

        public ObjectItem Object { get; set; }
        public ExchangeObjectPutInBagMessage() { }

        public ExchangeObjectPutInBagMessage( ObjectItem Object ){
            this.Object = Object;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Object.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Object = new ObjectItem();
            Object.Deserialize(reader);
        }
    }
}
