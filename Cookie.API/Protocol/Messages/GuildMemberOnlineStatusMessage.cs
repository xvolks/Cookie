using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildMemberOnlineStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6061;

        public override ushort MessageID => ProtocolId;

        public ulong MemberId { get; set; }
        public bool Online { get; set; }
        public GuildMemberOnlineStatusMessage() { }

        public GuildMemberOnlineStatusMessage( ulong MemberId, bool Online ){
            this.MemberId = MemberId;
            this.Online = Online;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(MemberId);
            writer.WriteBoolean(Online);
        }

        public override void Deserialize(IDataReader reader)
        {
            MemberId = reader.ReadVarUhLong();
            Online = reader.ReadBoolean();
        }
    }
}
