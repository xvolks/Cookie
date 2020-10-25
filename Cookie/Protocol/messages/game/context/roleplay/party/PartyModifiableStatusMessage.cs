using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyModifiableStatusMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6277;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Enabled = false;

        public PartyModifiableStatusMessage(): base()
        {
        }

        public PartyModifiableStatusMessage(
            int partyId,
            bool enabled
        ): base(
            partyId
        )
        {
            Enabled = enabled;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Enabled);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Enabled = reader.ReadBoolean();
        }
    }
}