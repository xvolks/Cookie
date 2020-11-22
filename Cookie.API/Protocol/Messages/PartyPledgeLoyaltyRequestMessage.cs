using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyPledgeLoyaltyRequestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6269;

        public override ushort MessageID => ProtocolId;

        public bool Loyal { get; set; }
        public PartyPledgeLoyaltyRequestMessage() { }

        public PartyPledgeLoyaltyRequestMessage( bool Loyal ){
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
