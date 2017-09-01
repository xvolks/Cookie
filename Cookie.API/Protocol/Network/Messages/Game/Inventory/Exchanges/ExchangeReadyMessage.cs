using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeReadyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5511;

        public ExchangeReadyMessage(bool ready, ushort step)
        {
            Ready = ready;
            Step = step;
        }

        public ExchangeReadyMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Ready { get; set; }
        public ushort Step { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Ready);
            writer.WriteVarUhShort(Step);
        }

        public override void Deserialize(IDataReader reader)
        {
            Ready = reader.ReadBoolean();
            Step = reader.ReadVarUhShort();
        }
    }
}