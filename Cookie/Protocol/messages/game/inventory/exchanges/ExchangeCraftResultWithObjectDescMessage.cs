using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage
    {
        public new const uint ProtocolId = 5999;
        public override uint MessageID { get { return ProtocolId; } }

        public ObjectItemNotInContainer ObjectInfo;

        public ExchangeCraftResultWithObjectDescMessage(): base()
        {
        }

        public ExchangeCraftResultWithObjectDescMessage(
            byte craftResult,
            ObjectItemNotInContainer objectInfo
        ): base(
            craftResult
        )
        {
            ObjectInfo = objectInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            ObjectInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ObjectInfo = new ObjectItemNotInContainer();
            ObjectInfo.Deserialize(reader);
        }
    }
}