namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeRequestedTradeMessage : ExchangeRequestedMessage
    {
        public new const ushort ProtocolId = 5523;
        public override ushort MessageID => ProtocolId;
        public ulong Source { get; set; }
        public ulong Target { get; set; }

        public ExchangeRequestedTradeMessage(ulong source, ulong target)
        {
            Source = source;
            Target = target;
        }

        public ExchangeRequestedTradeMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Source);
            writer.WriteVarUhLong(Target);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Source = reader.ReadVarUhLong();
            Target = reader.ReadVarUhLong();
        }

    }
}
