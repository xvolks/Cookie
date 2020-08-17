namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Messages.Game.Inventory.Exchanges;
    using Types.Game.Data.Items;
    using Utils.IO;

    public class ExchangeObjectPutInBagMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 6009;
        public override ushort MessageID => ProtocolId;
        public ObjectItem Object { get; set; }

        public ExchangeObjectPutInBagMessage(ObjectItem @object)
        {
            Object = @object;
        }

        public ExchangeObjectPutInBagMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Object.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Object = new ObjectItem();
            Object.Deserialize(reader);
        }

    }
}
