using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class KickHavenBagRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6652;

        public override ushort MessageID => ProtocolId;

        public ulong GuestId { get; set; }
        public KickHavenBagRequestMessage() { }

        public KickHavenBagRequestMessage( ulong GuestId ){
            this.GuestId = GuestId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(GuestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuestId = reader.ReadVarUhLong();
        }
    }
}
