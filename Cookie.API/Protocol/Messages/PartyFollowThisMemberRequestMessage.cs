using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyFollowThisMemberRequestMessage : PartyFollowMemberRequestMessage
    {
        public new const ushort ProtocolId = 5588;

        public override ushort MessageID => ProtocolId;

        public bool Enabled { get; set; }
        public PartyFollowThisMemberRequestMessage() { }

        public PartyFollowThisMemberRequestMessage( bool Enabled ){
            this.Enabled = Enabled;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Enabled);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Enabled = reader.ReadBoolean();
        }
    }
}
