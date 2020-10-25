using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IdolPartyRefreshMessage : NetworkMessage
    {
        public const uint ProtocolId = 6583;
        public override uint MessageID { get { return ProtocolId; } }

        public PartyIdol PartyIdol_;

        public IdolPartyRefreshMessage()
        {
        }

        public IdolPartyRefreshMessage(
            PartyIdol partyIdol_
        )
        {
            PartyIdol_ = partyIdol_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            PartyIdol_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PartyIdol_ = new PartyIdol();
            PartyIdol_.Deserialize(reader);
        }
    }
}