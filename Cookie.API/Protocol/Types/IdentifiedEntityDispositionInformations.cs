using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class IdentifiedEntityDispositionInformations : EntityDispositionInformations
    {
        public new const ushort ProtocolId = 107;

        public override ushort TypeID => ProtocolId;

        public double Id { get; set; }
        public IdentifiedEntityDispositionInformations() { }

        public IdentifiedEntityDispositionInformations( double Id ){
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Id = reader.ReadDouble();
        }
    }
}
