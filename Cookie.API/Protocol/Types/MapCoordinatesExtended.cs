using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class MapCoordinatesExtended : MapCoordinatesAndId
    {
        public new const ushort ProtocolId = 176;

        public override ushort TypeID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public MapCoordinatesExtended() { }

        public MapCoordinatesExtended( ushort SubAreaId ){
            this.SubAreaId = SubAreaId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SubAreaId = reader.ReadVarUhShort();
        }
    }
}
