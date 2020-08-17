using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeRequestedTradeMessage : ExchangeRequestedMessage
    {
        public new const ushort ProtocolId = 5523;

        public ExchangeRequestedTradeMessage(ulong source, ulong target)
        {
            Source = source;
            Target = target;
        }

        public ExchangeRequestedTradeMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong Source { get; set; }
        public ulong Target { get; set; }

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