using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildInvitationStateRecruterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5563;

        public override ushort MessageID => ProtocolId;

        public string RecrutedName { get; set; }
        public sbyte InvitationState { get; set; }
        public GuildInvitationStateRecruterMessage() { }

        public GuildInvitationStateRecruterMessage( string RecrutedName, sbyte InvitationState ){
            this.RecrutedName = RecrutedName;
            this.InvitationState = InvitationState;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(RecrutedName);
            writer.WriteSByte(InvitationState);
        }

        public override void Deserialize(IDataReader reader)
        {
            RecrutedName = reader.ReadUTF();
            InvitationState = reader.ReadSByte();
        }
    }
}
