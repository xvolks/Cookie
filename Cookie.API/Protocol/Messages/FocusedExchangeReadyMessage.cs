using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FocusedExchangeReadyMessage : ExchangeReadyMessage
    {
        public new const ushort ProtocolId = 6701;

        public override ushort MessageID => ProtocolId;

        public uint FocusActionId { get; set; }
        public FocusedExchangeReadyMessage() { }

        public FocusedExchangeReadyMessage( uint FocusActionId ){
            this.FocusActionId = FocusActionId;
        }

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
