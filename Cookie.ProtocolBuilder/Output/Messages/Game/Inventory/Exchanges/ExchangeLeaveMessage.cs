namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Messages.Game.Dialog;
    using Utils.IO;

    public class ExchangeLeaveMessage : LeaveDialogMessage
    {
        public new const ushort ProtocolId = 5628;
        public override ushort MessageID => ProtocolId;
        public bool Success { get; set; }

        public ExchangeLeaveMessage(bool success)
        {
            Success = success;
        }

        public ExchangeLeaveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Success);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Success = reader.ReadBoolean();
        }

    }
}
