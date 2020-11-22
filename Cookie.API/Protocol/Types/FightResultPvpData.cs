using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightResultPvpData : FightResultAdditionalData
    {
        public new const ushort ProtocolId = 190;

        public override ushort TypeID => ProtocolId;

        public byte Grade { get; set; }
        public ushort MinHonorForGrade { get; set; }
        public ushort MaxHonorForGrade { get; set; }
        public ushort Honor { get; set; }
        public short HonorDelta { get; set; }
        public FightResultPvpData() { }

        public FightResultPvpData( byte Grade, ushort MinHonorForGrade, ushort MaxHonorForGrade, ushort Honor, short HonorDelta ){
            this.Grade = Grade;
            this.MinHonorForGrade = MinHonorForGrade;
            this.MaxHonorForGrade = MaxHonorForGrade;
            this.Honor = Honor;
            this.HonorDelta = HonorDelta;
        }

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
