using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismFightRemovedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6453;
        public override uint MessageID { get { return ProtocolId; } }

        public short SubAreaId = 0;

        public PrismFightRemovedMessage()
        {
        }

        public PrismFightRemovedMessage(
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