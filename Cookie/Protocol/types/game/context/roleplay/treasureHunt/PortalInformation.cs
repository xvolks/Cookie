using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PortalInformation : NetworkType
    {
        public const short ProtocolId = 466;
        public override short TypeId { get { return ProtocolId; } }

        public int PortalId = 0;
        public short AreaId = 0;

        public PortalInformation()
        {
        }

        public PortalInformation(
            int portalId,
            short areaId
        )
        {
            PortalId = portalId;
            AreaId = areaId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(PortalId);
            writer.WriteShort(AreaId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PortalId = reader.ReadInt();
            AreaId = reader.ReadShort();
        }
    }
}