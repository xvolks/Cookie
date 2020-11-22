using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildInvitedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5552;

        public override ushort MessageID => ProtocolId;

        public ulong RecruterId { get; set; }
        public string RecruterName { get; set; }
        public BasicGuildInformations GuildInfo { get; set; }
        public GuildInvitedMessage() { }

        public GuildInvitedMessage( ulong RecruterId, string RecruterName, BasicGuildInformations GuildInfo ){
            this.RecruterId = RecruterId;
            this.RecruterName = RecruterName;
            this.GuildInfo = GuildInfo;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(RecruterId);
            writer.WriteUTF(RecruterName);
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            RecruterId = reader.ReadVarUhLong();
            RecruterName = reader.ReadUTF();
            GuildInfo = new BasicGuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}
