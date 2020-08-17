using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Paddock
{
    public class PaddockSellBuyDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6018;

        public PaddockSellBuyDialogMessage(bool bsell, uint ownerId, ulong price)
        {
            Bsell = bsell;
            OwnerId = ownerId;
            Price = price;
        }

        public PaddockSellBuyDialogMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Bsell { get; set; }
        public uint OwnerId { get; set; }
        public ulong Price { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Bsell);
            writer.WriteVarUhInt(OwnerId);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            Bsell = reader.ReadBoolean();
            OwnerId = reader.ReadVarUhInt();
            Price = reader.ReadVarUhLong();
        }
    }
}