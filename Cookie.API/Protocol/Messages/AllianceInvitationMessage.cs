using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceInvitationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6395;

        public override ushort MessageID => ProtocolId;

        public ulong TargetId { get; set; }
        public AllianceInvitationMessage() { }

        public AllianceInvitationMessage( ulong TargetId ){
            this.TargetId = TargetId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TargetId = reader.ReadVarUhLong();
        }
    }
}
