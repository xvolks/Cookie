using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildKickRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5887;

        public override ushort MessageID => ProtocolId;

        public ulong KickedId { get; set; }
        public GuildKickRequestMessage() { }

        public GuildKickRequestMessage( ulong KickedId ){
            this.KickedId = KickedId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(KickedId);
        }

        public override void Deserialize(IDataReader reader)
        {
            KickedId = reader.ReadVarUhLong();
        }
    }
}
