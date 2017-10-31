namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeCraftInformationObjectMessage : ExchangeCraftResultWithObjectIdMessage
    {
        public new const ushort ProtocolId = 5794;
        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

        public ExchangeCraftInformationObjectMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public ExchangeCraftInformationObjectMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
        }

    }
}
