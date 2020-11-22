using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceInvitationStateRecrutedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6392;

        public override ushort MessageID => ProtocolId;

        public sbyte InvitationState { get; set; }
        public AllianceInvitationStateRecrutedMessage() { }

        public AllianceInvitationStateRecrutedMessage( sbyte InvitationState ){
            this.InvitationState = InvitationState;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(InvitationState);
        }

        public override void Deserialize(IDataReader reader)
        {
            InvitationState = reader.ReadSByte();
        }
    }
}
