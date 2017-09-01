namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Utils.IO;

    public class FightResultPvpData : FightResultAdditionalData
    {
        public new const ushort ProtocolId = 190;
        public override ushort TypeID => ProtocolId;
        public byte Grade { get; set; }
        public ushort MinHonorForGrade { get; set; }
        public ushort MaxHonorForGrade { get; set; }
        public ushort Honor { get; set; }
        public short HonorDelta { get; set; }

        public FightResultPvpData(byte grade, ushort minHonorForGrade, ushort maxHonorForGrade, ushort honor, short honorDelta)
        {
            Grade = grade;
            MinHonorForGrade = minHonorForGrade;
            MaxHonorForGrade = maxHonorForGrade;
            Honor = honor;
            HonorDelta = honorDelta;
        }

        public FightResultPvpData() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Grade);
            writer.WriteVarUhShort(MinHonorForGrade);
            writer.WriteVarUhShort(MaxHonorForGrade);
            writer.WriteVarUhShort(Honor);
            writer.WriteVarShort(HonorDelta);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Grade = reader.ReadByte();
            MinHonorForGrade = reader.ReadVarUhShort();
            MaxHonorForGrade = reader.ReadVarUhShort();
            Honor = reader.ReadVarUhShort();
            HonorDelta = reader.ReadVarShort();
        }

    }
}
