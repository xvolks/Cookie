using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TeleportToBuddyAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6293;

        public override ushort MessageID => ProtocolId;

        public ushort DungeonId { get; set; }
        public ulong BuddyId { get; set; }
        public bool Accept { get; set; }
        public TeleportToBuddyAnswerMessage() { }

        public TeleportToBuddyAnswerMessage( ushort DungeonId, ulong BuddyId, bool Accept ){
            this.DungeonId = DungeonId;
            this.BuddyId = BuddyId;
            this.Accept = Accept;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteVarUhLong(BuddyId);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            BuddyId = reader.ReadVarUhLong();
            Accept = reader.ReadBoolean();
        }
    }
}
