using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeLeaveMessage : LeaveDialogMessage
    {
        public new const ushort ProtocolId = 5628;

        public override ushort MessageID => ProtocolId;

        public bool Success { get; set; }
        public ExchangeLeaveMessage() { }

        public ExchangeLeaveMessage( bool Success ){
            this.Success = Success;
        }

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
