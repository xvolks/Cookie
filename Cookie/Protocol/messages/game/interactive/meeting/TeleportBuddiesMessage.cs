using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TeleportBuddiesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6289;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;

        public TeleportBuddiesMessage()
        {
        }

        public TeleportBuddiesMessage(
            short dungeonId
        )
        {
            DungeonId = dungeonId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(DungeonId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DungeonId = reader.ReadVarShort();
        }
    }
}