using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeWaitingResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5786;

        public ExchangeWaitingResultMessage(bool bwait)
        {
            Bwait = bwait;
        }

        public ExchangeWaitingResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Bwait { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Bwait);
        }

        public override void Deserialize(IDataReader reader)
        {
            Bwait = reader.ReadBoolean();
        }
    }
}