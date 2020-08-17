namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeBidHouseBuyResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6272;
        public override ushort MessageID => ProtocolId;
        public uint Uid { get; set; }
        public bool Bought { get; set; }

        public ExchangeBidHouseBuyResultMessage(uint uid, bool bought)
        {
            Uid = uid;
            Bought = bought;
        }

        public ExchangeBidHouseBuyResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Uid);
            writer.WriteBoolean(Bought);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadVarUhInt();
            Bought = reader.ReadBoolean();
        }

    }
}
