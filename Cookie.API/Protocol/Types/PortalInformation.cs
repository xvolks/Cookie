using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PortalInformation : NetworkType
    {
        public const ushort ProtocolId = 466;

        public override ushort TypeID => ProtocolId;

        public int PortalId { get; set; }
        public short AreaId { get; set; }
        public PortalInformation() { }

        public PortalInformation( int PortalId, short AreaId ){
            this.PortalId = PortalId;
            this.AreaId = AreaId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(PortalId);
            writer.WriteShort(AreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PortalId = reader.ReadInt();
            AreaId = reader.ReadShort();
        }
    }
}
