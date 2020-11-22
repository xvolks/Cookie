using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class NpcGenericActionRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5898;
        public override uint MessageID { get { return ProtocolId; } }

        public int NpcId = 0;
        public byte NpcActionId = 0;
        public double NpcMapId = 0;

        public NpcGenericActionRequestMessage()
        {
        }

        public NpcGenericActionRequestMessage(
            int npcId,
            byte npcActionId,
            double npcMapId
        )
        {
            NpcId = npcId;
            NpcActionId = npcActionId;
            NpcMapId = npcMapId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(NpcId);
            writer.WriteByte(NpcActionId);
            writer.WriteDouble(NpcMapId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            NpcId = reader.ReadInt();
            NpcActionId = reader.ReadByte();
            NpcMapId = reader.ReadDouble();
        }
    }
}