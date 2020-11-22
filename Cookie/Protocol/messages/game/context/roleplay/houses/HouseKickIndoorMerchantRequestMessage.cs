using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseKickIndoorMerchantRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5661;
        public override uint MessageID { get { return ProtocolId; } }

        public short CellId = 0;

        public HouseKickIndoorMerchantRequestMessage()
        {
        }

        public HouseKickIndoorMerchantRequestMessage(
            short cellId
        )
        {
            CellId = cellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(CellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CellId = reader.ReadVarShort();
        }
    }
}