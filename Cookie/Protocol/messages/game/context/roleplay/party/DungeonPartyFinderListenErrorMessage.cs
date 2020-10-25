using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DungeonPartyFinderListenErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6248;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;

        public DungeonPartyFinderListenErrorMessage()
        {
        }

        public DungeonPartyFinderListenErrorMessage(
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