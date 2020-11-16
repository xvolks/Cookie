using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildInvitationMessage : NetworkMessage
    {
        public const uint ProtocolId = 5551;
        public override uint MessageID { get { return ProtocolId; } }

        public long TargetId = 0;

        public GuildInvitationMessage()
        {
        }

        public GuildInvitationMessage(
            long targetId
        )
        {
            TargetId = targetId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(TargetId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TargetId = reader.ReadVarLong();
        }
    }
}