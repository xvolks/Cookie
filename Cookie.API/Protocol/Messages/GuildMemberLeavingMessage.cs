using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildMemberLeavingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5923;

        public override ushort MessageID => ProtocolId;

        public bool Kicked { get; set; }
        public ulong MemberId { get; set; }
        public GuildMemberLeavingMessage() { }

        public GuildMemberLeavingMessage( bool Kicked, ulong MemberId ){
            this.Kicked = Kicked;
            this.MemberId = MemberId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Kicked);
            writer.WriteVarUhLong(MemberId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Kicked = reader.ReadBoolean();
            MemberId = reader.ReadVarUhLong();
        }
    }
}
