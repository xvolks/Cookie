using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DareRewardConsumeRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6676;
        public override uint MessageID { get { return ProtocolId; } }

        public double DareId = 0;
        public byte Type = 0;

        public DareRewardConsumeRequestMessage()
        {
        }

        public DareRewardConsumeRequestMessage(
            double dareId,
            byte type
        )
        {
            DareId = dareId;
            Type = type;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteByte(Type);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DareId = reader.ReadDouble();
            Type = reader.ReadByte();
        }
    }
}