using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightResultPvpData : FightResultAdditionalData
    {
        public new const short ProtocolId = 190;
        public override short TypeId { get { return ProtocolId; } }

        public byte Grade = 0;
        public short MinHonorForGrade = 0;
        public short MaxHonorForGrade = 0;
        public short Honor = 0;
        public short HonorDelta = 0;

        public FightResultPvpData(): base()
        {
        }

        public FightResultPvpData(
            byte grade,
            short minHonorForGrade,
            short maxHonorForGrade,
            short honor,
            short honorDelta
        ): base()
        {
            Grade = grade;
            MinHonorForGrade = minHonorForGrade;
            MaxHonorForGrade = maxHonorForGrade;
            Honor = honor;
            HonorDelta = honorDelta;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Grade);
            writer.WriteVarShort(MinHonorForGrade);
            writer.WriteVarShort(MaxHonorForGrade);
            writer.WriteVarShort(Honor);
            writer.WriteVarShort(HonorDelta);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Grade = reader.ReadByte();
            MinHonorForGrade = reader.ReadVarShort();
            MaxHonorForGrade = reader.ReadVarShort();
            Honor = reader.ReadVarShort();
            HonorDelta = reader.ReadVarShort();
        }
    }
}