using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class IdentifiedEntityDispositionInformations : EntityDispositionInformations
    {
        public new const short ProtocolId = 107;
        public override short TypeId { get { return ProtocolId; } }

        public double Id_ = 0;

        public IdentifiedEntityDispositionInformations(): base()
        {
        }

        public IdentifiedEntityDispositionInformations(
            short cellId,
            byte direction,
            double id_
        ): base(
            cellId,
            direction
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Id_ = reader.ReadDouble();
        }
    }
}