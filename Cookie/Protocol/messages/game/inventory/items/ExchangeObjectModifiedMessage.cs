using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectModifiedMessage : ExchangeObjectMessage
    {
        public new const uint ProtocolId = 5519;
        public override uint MessageID { get { return ProtocolId; } }

        public ObjectItem Object_;

        public ExchangeObjectModifiedMessage(): base()
        {
        }

        public ExchangeObjectModifiedMessage(
            bool remote,
            ObjectItem object_
        ): base(
            remote
        )
        {
            Object_ = object_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Object_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Object_ = new ObjectItem();
            Object_.Deserialize(reader);
        }
    }
}