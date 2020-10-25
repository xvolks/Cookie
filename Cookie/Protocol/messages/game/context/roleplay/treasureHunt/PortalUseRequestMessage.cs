using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PortalUseRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6492;
        public override uint MessageID { get { return ProtocolId; } }

        public int PortalId = 0;

        public PortalUseRequestMessage()
        {
        }

        public PortalUseRequestMessage(
            int portalId
        )
        {
            PortalId = portalId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(PortalId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PortalId = reader.ReadVarInt();
        }
    }
}