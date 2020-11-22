using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ActorExtendedAlignmentInformations : ActorAlignmentInformations
    {
        public new const short ProtocolId = 202;
        public override short TypeId { get { return ProtocolId; } }

        public short Honor = 0;
        public short HonorGradeFloor = 0;
        public short HonorNextGradeFloor = 0;
        public byte Aggressable = 0;

        public ActorExtendedAlignmentInformations(): base()
        {
        }

        public ActorExtendedAlignmentInformations(
            byte alignmentSide,
            byte alignmentValue,
            byte alignmentGrade,
            double characterPower,
            short honor,
            short honorGradeFloor,
            short honorNextGradeFloor,
            byte aggressable
        ): base(
            alignmentSide,
            alignmentValue,
            alignmentGrade,
            characterPower
        )
        {
            Honor = honor;
            HonorGradeFloor = honorGradeFloor;
            HonorNextGradeFloor = honorNextGradeFloor;
            Aggressable = aggressable;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Honor);
            writer.WriteVarShort(HonorGradeFloor);
            writer.WriteVarShort(HonorNextGradeFloor);
            writer.WriteByte(Aggressable);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Honor = reader.ReadVarShort();
            HonorGradeFloor = reader.ReadVarShort();
            HonorNextGradeFloor = reader.ReadVarShort();
            Aggressable = reader.ReadByte();
        }
    }
}