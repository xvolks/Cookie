using Cookie.API.Protocol.Network.Messages.Game.Dialog;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeLeaveMessage : LeaveDialogMessage
    {
        public new const ushort ProtocolId = 5628;

        public ExchangeLeaveMessage(bool success)
        {
            Success = success;
        }

        public ExchangeLeaveMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Success { get; set; }

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