using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ActorExtendedAlignmentInformations : ActorAlignmentInformations
    {
        public new const ushort ProtocolId = 202;

        public override ushort TypeID => ProtocolId;

        public ushort Honor { get; set; }
        public ushort HonorGradeFloor { get; set; }
        public ushort HonorNextGradeFloor { get; set; }
        public sbyte Aggressable { get; set; }
        public ActorExtendedAlignmentInformations() { }

        public ActorExtendedAlignmentInformations( ushort Honor, ushort HonorGradeFloor, ushort HonorNextGradeFloor, sbyte Aggressable ){
            this.Honor = Honor;
            this.HonorGradeFloor = HonorGradeFloor;
            this.HonorNextGradeFloor = HonorNextGradeFloor;
            this.Aggressable = Aggressable;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Honor);
            writer.WriteVarUhShort(HonorGradeFloor);
            writer.WriteVarUhShort(HonorNextGradeFloor);
            writer.WriteSByte(Aggressable);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Honor = reader.ReadVarUhShort();
            HonorGradeFloor = reader.ReadVarUhShort();
            HonorNextGradeFloor = reader.ReadVarUhShort();
            Aggressable = reader.ReadSByte();
        }
    }
}
