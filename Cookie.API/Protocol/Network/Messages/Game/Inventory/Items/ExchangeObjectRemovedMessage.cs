namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Messages.Game.Inventory.Exchanges;
    using Utils.IO;

    public class ExchangeObjectRemovedMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 5517;
        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }

        public ExchangeObjectRemovedMessage(uint objectUID)
        {
            ObjectUID = objectUID;
        }

        public ExchangeObjectRemovedMessage() { }

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
