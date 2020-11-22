using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DungeonKeyRingUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6296;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;
        public bool Available = false;

        public DungeonKeyRingUpdateMessage()
        {
        }

        public DungeonKeyRingUpdateMessage(
            short dungeonId,
            bool available
        )
        {
            DungeonId = dungeonId;
            Available = available;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(DungeonId);
            writer.WriteBoolean(Available);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DungeonId = reader.ReadVarShort();
            Available = reader.ReadBoolean();
        }
    }
}