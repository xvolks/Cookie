using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AbstractPartyEventMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6273;
        public override uint MessageID { get { return ProtocolId; } }

        public AbstractPartyEventMessage(): base()
        {
        }

        public AbstractPartyEventMessage(
            int partyId
        ): base(
            partyId
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