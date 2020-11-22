using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PaddockToSellListRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6141;
        public override uint MessageID { get { return ProtocolId; } }

        public short PageIndex = 0;

        public PaddockToSellListRequestMessage()
        {
        }

        public PaddockToSellListRequestMessage(
            short pageIndex
        )
        {
            PageIndex = pageIndex;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(PageIndex);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PageIndex = reader.ReadVarShort();
        }
    }
}