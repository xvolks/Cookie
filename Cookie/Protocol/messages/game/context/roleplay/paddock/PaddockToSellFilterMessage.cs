using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PaddockToSellFilterMessage : NetworkMessage
    {
        public const uint ProtocolId = 6161;
        public override uint MessageID { get { return ProtocolId; } }

        public int AreaId = 0;
        public byte AtLeastNbMount = 0;
        public byte AtLeastNbMachine = 0;
        public long MaxPrice = 0;
        public byte OrderBy = 0;

        public PaddockToSellFilterMessage()
        {
        }

        public PaddockToSellFilterMessage(
            int areaId,
            byte atLeastNbMount,
            byte atLeastNbMachine,
            long maxPrice,
            byte orderBy
        )
        {
            AreaId = areaId;
            AtLeastNbMount = atLeastNbMount;
            AtLeastNbMachine = atLeastNbMachine;
            MaxPrice = maxPrice;
            OrderBy = orderBy;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(AreaId);
            writer.WriteByte(AtLeastNbMount);
            writer.WriteByte(AtLeastNbMachine);
            writer.WriteVarLong(MaxPrice);
            writer.WriteByte(OrderBy);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AreaId = reader.ReadInt();
            AtLeastNbMount = reader.ReadByte();
            AtLeastNbMachine = reader.ReadByte();
            MaxPrice = reader.ReadVarLong();
            OrderBy = reader.ReadByte();
        }
    }
}