using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class DareReward : NetworkType
    {
        public const short ProtocolId = 505;
        public override short TypeId { get { return ProtocolId; } }

        public byte Type = 0;
        public short MonsterId = 0;
        public long Kamas = 0;
        public double DareId = 0;

        public DareReward()
        {
        }

        public DareReward(
            byte type,
            short monsterId,
            long kamas,
            double dareId
        )
        {
            Type = type;
            MonsterId = monsterId;
            Kamas = kamas;
            DareId = dareId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Type);
            writer.WriteVarShort(MonsterId);
            writer.WriteVarLong(Kamas);
            writer.WriteDouble(DareId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = reader.ReadByte();
            MonsterId = reader.ReadVarShort();
            Kamas = reader.ReadVarLong();
            DareId = reader.ReadDouble();
        }
    }
}