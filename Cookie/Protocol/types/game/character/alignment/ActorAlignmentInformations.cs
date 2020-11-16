using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ActorAlignmentInformations : NetworkType
    {
        public const short ProtocolId = 201;
        public override short TypeId { get { return ProtocolId; } }

        public byte AlignmentSide = 0;
        public byte AlignmentValue = 0;
        public byte AlignmentGrade = 0;
        public double CharacterPower = 0;

        public ActorAlignmentInformations()
        {
        }

        public ActorAlignmentInformations(
            byte alignmentSide,
            byte alignmentValue,
            byte alignmentGrade,
            double characterPower
        )
        {
            AlignmentSide = alignmentSide;
            AlignmentValue = alignmentValue;
            AlignmentGrade = alignmentGrade;
            CharacterPower = characterPower;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(AlignmentSide);
            writer.WriteByte(AlignmentValue);
            writer.WriteByte(AlignmentGrade);
            writer.WriteDouble(CharacterPower);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AlignmentSide = reader.ReadByte();
            AlignmentValue = reader.ReadByte();
            AlignmentGrade = reader.ReadByte();
            CharacterPower = reader.ReadDouble();
        }
    }
}