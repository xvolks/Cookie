using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeMountsStableBornAddMessage : ExchangeMountsStableAddMessage
    {
        public new const uint ProtocolId = 6557;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeMountsStableBornAddMessage(): base()
        {
        }

        public ExchangeMountsStableBornAddMessage(
            List<MountClientData> mountDescription
        ): base(
            mountDescription
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}