using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CompassUpdatePartyMemberMessage : CompassUpdateMessage
    {
        public new const ushort ProtocolId = 5589;

        public override ushort MessageID => ProtocolId;

        public ulong MemberId { get; set; }
        public bool Active { get; set; }
        public CompassUpdatePartyMemberMessage() { }

        public CompassUpdatePartyMemberMessage( ulong MemberId, bool Active ){
            this.MemberId = MemberId;
            this.Active = Active;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(MemberId);
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MemberId = reader.ReadVarUhLong();
            Active = reader.ReadBoolean();
        }
    }
}
