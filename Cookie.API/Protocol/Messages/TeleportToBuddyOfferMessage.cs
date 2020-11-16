using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TeleportToBuddyOfferMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6287;

        public override ushort MessageID => ProtocolId;

        public ushort DungeonId { get; set; }
        public ulong BuddyId { get; set; }
        public uint TimeLeft { get; set; }
        public TeleportToBuddyOfferMessage() { }

        public TeleportToBuddyOfferMessage( ushort DungeonId, ulong BuddyId, uint TimeLeft ){
            this.DungeonId = DungeonId;
            this.BuddyId = BuddyId;
            this.TimeLeft = TimeLeft;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteVarUhLong(BuddyId);
            writer.WriteVarUhInt(TimeLeft);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            BuddyId = reader.ReadVarUhLong();
            TimeLeft = reader.ReadVarUhInt();
        }
    }
}
