using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TeleportBuddiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6289;

        public override ushort MessageID => ProtocolId;

        public ushort DungeonId { get; set; }
        public TeleportBuddiesMessage() { }

        public TeleportBuddiesMessage( ushort DungeonId ){
            this.DungeonId = DungeonId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
        }
    }
}
