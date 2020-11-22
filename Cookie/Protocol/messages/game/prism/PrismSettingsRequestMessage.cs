using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismSettingsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6437;
        public override uint MessageID { get { return ProtocolId; } }

        public short SubAreaId = 0;
        public byte StartDefenseTime = 0;

        public PrismSettingsRequestMessage()
        {
        }

        public PrismSettingsRequestMessage(
            short subAreaId,
            byte startDefenseTime
        )
        {
            SubAreaId = subAreaId;
            StartDefenseTime = startDefenseTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
            writer.WriteByte(StartDefenseTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
            StartDefenseTime = reader.ReadByte();
        }
    }
}