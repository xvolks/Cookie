using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class FocusedExchangeReadyMessage : ExchangeReadyMessage
    {
        public new const ushort ProtocolId = 6701;

        public FocusedExchangeReadyMessage(uint focusActionId)
        {
            FocusActionId = focusActionId;
        }

        public FocusedExchangeReadyMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint FocusActionId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(FocusActionId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FocusActionId = reader.ReadVarUhInt();
        }
    }
}