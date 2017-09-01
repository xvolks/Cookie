using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character.Alignment
{
    public class ActorExtendedAlignmentInformations : ActorAlignmentInformations
    {
        public new const ushort ProtocolId = 202;

        public ActorExtendedAlignmentInformations(ushort honor, ushort honorGradeFloor, ushort honorNextGradeFloor,
            byte aggressable)
        {
            Honor = honor;
            HonorGradeFloor = honorGradeFloor;
            HonorNextGradeFloor = honorNextGradeFloor;
            Aggressable = aggressable;
        }

        public ActorExtendedAlignmentInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort Honor { get; set; }
        public ushort HonorGradeFloor { get; set; }
        public ushort HonorNextGradeFloor { get; set; }
        public byte Aggressable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Honor);
            writer.WriteVarUhShort(HonorGradeFloor);
            writer.WriteVarUhShort(HonorNextGradeFloor);
            writer.WriteByte(Aggressable);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Honor = reader.ReadVarUhShort();
            HonorGradeFloor = reader.ReadVarUhShort();
            HonorNextGradeFloor = reader.ReadVarUhShort();
            Aggressable = reader.ReadByte();
        }
    }
}