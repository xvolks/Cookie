using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyNewGuestMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 6260;

        public override ushort MessageID => ProtocolId;

        public PartyGuestInformations Guest { get; set; }
        public PartyNewGuestMessage() { }

        public PartyNewGuestMessage( PartyGuestInformations Guest ){
            this.Guest = Guest;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Guest.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Guest = new PartyGuestInformations();
            Guest.Deserialize(reader);
        }
    }
}
