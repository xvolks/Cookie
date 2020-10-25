using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismsListUpdateMessage : PrismsListMessage
    {
        public new const uint ProtocolId = 6438;
        public override uint MessageID { get { return ProtocolId; } }

        public PrismsListUpdateMessage(): base()
        {
        }

        public PrismsListUpdateMessage(
            List<PrismSubareaEmptyInfo> prisms
        ): base(
            prisms
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