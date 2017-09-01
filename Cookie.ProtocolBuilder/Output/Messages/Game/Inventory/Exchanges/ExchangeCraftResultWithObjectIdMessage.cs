namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeCraftResultWithObjectIdMessage : ExchangeCraftResultMessage
    {
        public new const ushort ProtocolId = 6000;
        public override ushort MessageID => ProtocolId;
        public ushort ObjectGenericId { get; set; }

        public ExchangeCraftResultWithObjectIdMessage(ushort objectGenericId)
        {
            ObjectGenericId = objectGenericId;
        }

        public ExchangeCraftResultWithObjectIdMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ObjectGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGenericId = reader.ReadVarUhShort();
        }

    }
}
