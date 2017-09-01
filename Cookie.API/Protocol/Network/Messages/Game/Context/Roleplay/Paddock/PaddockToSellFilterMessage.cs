using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Paddock
{
    public class PaddockToSellFilterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6161;

        public PaddockToSellFilterMessage(int areaId, sbyte atLeastNbMount, sbyte atLeastNbMachine, ulong maxPrice)
        {
            AreaId = areaId;
            AtLeastNbMount = atLeastNbMount;
            AtLeastNbMachine = atLeastNbMachine;
            MaxPrice = maxPrice;
        }

        public PaddockToSellFilterMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int AreaId { get; set; }
        public sbyte AtLeastNbMount { get; set; }
        public sbyte AtLeastNbMachine { get; set; }
        public ulong MaxPrice { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AreaId);
            writer.WriteSByte(AtLeastNbMount);
            writer.WriteSByte(AtLeastNbMachine);
            writer.WriteVarUhLong(MaxPrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            AreaId = reader.ReadInt();
            AtLeastNbMount = reader.ReadSByte();
            AtLeastNbMachine = reader.ReadSByte();
            MaxPrice = reader.ReadVarUhLong();
        }
    }
}