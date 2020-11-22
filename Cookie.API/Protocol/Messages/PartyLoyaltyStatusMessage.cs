using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyLoyaltyStatusMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6270;

        public override ushort MessageID => ProtocolId;

        public bool Loyal { get; set; }
        public PartyLoyaltyStatusMessage() { }

        public PartyLoyaltyStatusMessage( bool Loyal ){
            this.Loyal = Loyal;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Loyal);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Loyal = reader.ReadBoolean();
        }
    }
}
