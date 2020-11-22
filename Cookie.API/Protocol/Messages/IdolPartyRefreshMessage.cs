using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdolPartyRefreshMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6583;

        public override ushort MessageID => ProtocolId;

        public PartyIdol PartyIdol { get; set; }
        public IdolPartyRefreshMessage() { }

        public IdolPartyRefreshMessage( PartyIdol PartyIdol ){
            this.PartyIdol = PartyIdol;
        }

        public override void Serialize(IDataWriter writer)
        {
            PartyIdol.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PartyIdol = new PartyIdol();
            PartyIdol.Deserialize(reader);
        }
    }
}
