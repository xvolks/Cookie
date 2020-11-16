using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildInvitationStateRecrutedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5548;

        public override ushort MessageID => ProtocolId;

        public sbyte InvitationState { get; set; }
        public GuildInvitationStateRecrutedMessage() { }

        public GuildInvitationStateRecrutedMessage( sbyte InvitationState ){
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
