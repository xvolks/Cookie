using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TeleportToBuddyCloseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6303;

        public override ushort MessageID => ProtocolId;

        public ushort DungeonId { get; set; }
        public ulong BuddyId { get; set; }
        public TeleportToBuddyCloseMessage() { }

        public TeleportToBuddyCloseMessage( ushort DungeonId, ulong BuddyId ){
            this.DungeonId = DungeonId;
            this.BuddyId = BuddyId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteVarUhLong(BuddyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            BuddyId = reader.ReadVarUhLong();
        }
    }
}
