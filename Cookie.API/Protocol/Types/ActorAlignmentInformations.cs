using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ActorAlignmentInformations : NetworkType
    {
        public const ushort ProtocolId = 201;

        public override ushort TypeID => ProtocolId;

        public sbyte AlignmentSide { get; set; }
        public sbyte AlignmentValue { get; set; }
        public sbyte AlignmentGrade { get; set; }
        public double CharacterPower { get; set; }
        public ActorAlignmentInformations() { }

        public ActorAlignmentInformations( sbyte AlignmentSide, sbyte AlignmentValue, sbyte AlignmentGrade, double CharacterPower ){
            this.AlignmentSide = AlignmentSide;
            this.AlignmentValue = AlignmentValue;
            this.AlignmentGrade = AlignmentGrade;
            this.CharacterPower = CharacterPower;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(AlignmentSide);
            writer.WriteSByte(AlignmentValue);
            writer.WriteSByte(AlignmentGrade);
            writer.WriteDouble(CharacterPower);
        }

        public override void Deserialize(IDataReader reader)
        {
            AlignmentSide = reader.ReadSByte();
            AlignmentValue = reader.ReadSByte();
            AlignmentGrade = reader.ReadSByte();
            CharacterPower = reader.ReadDouble();
        }
    }
}
