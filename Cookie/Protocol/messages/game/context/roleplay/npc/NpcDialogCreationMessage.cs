using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class NpcDialogCreationMessage : NetworkMessage
    {
        public const uint ProtocolId = 5618;
        public override uint MessageID { get { return ProtocolId; } }

        public double MapId = 0;
        public int NpcId = 0;

        public NpcDialogCreationMessage()
        {
        }

        public NpcDialogCreationMessage(
            double mapId,
            int npcId
        )
        {
            MapId = mapId;
            NpcId = npcId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteInt(NpcId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MapId = reader.ReadDouble();
            NpcId = reader.ReadInt();
        }
    }
}