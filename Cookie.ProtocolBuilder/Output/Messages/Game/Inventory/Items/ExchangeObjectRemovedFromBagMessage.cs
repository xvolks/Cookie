namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Messages.Game.Inventory.Exchanges;
    using Utils.IO;

    public class ExchangeObjectRemovedFromBagMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 6010;
        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }

        public ExchangeObjectRemovedFromBagMessage(uint objectUID)
        {
            ObjectUID = objectUID;
        }

        public ExchangeObjectRemovedFromBagMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(ObjectUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectUID = reader.ReadVarUhInt();
        }

    }
}
