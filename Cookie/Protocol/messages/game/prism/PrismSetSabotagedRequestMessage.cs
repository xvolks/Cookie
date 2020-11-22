using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismSetSabotagedRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6468;
        public override uint MessageID { get { return ProtocolId; } }

        public short SubAreaId = 0;

        public PrismSetSabotagedRequestMessage()
        {
        }

        public PrismSetSabotagedRequestMessage(
            short subAreaId
        )
        {
            SubAreaId = subAreaId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
        }
    }
}