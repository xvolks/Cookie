using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeLeaveMessage : LeaveDialogMessage
    {
        public new const uint ProtocolId = 5628;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Success = false;

        public ExchangeLeaveMessage(): base()
        {
        }

        public ExchangeLeaveMessage(
            byte dialogType,
            bool success
        ): base(
            dialogType
        )
        {
            Success = success;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Success);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Success = reader.ReadBoolean();
        }
    }
}