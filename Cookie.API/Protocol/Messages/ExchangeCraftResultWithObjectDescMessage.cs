using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage
    {
        public new const ushort ProtocolId = 5999;

        public override ushort MessageID => ProtocolId;

        public ObjectItemNotInContainer ObjectInfo { get; set; }
        public ExchangeCraftResultWithObjectDescMessage() { }

        public ExchangeCraftResultWithObjectDescMessage( ObjectItemNotInContainer ObjectInfo ){
            this.ObjectInfo = ObjectInfo;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            ObjectInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectInfo = new ObjectItemNotInContainer();
            ObjectInfo.Deserialize(reader);
        }
    }
}
