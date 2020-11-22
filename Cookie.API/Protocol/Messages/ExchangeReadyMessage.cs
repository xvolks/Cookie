using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeReadyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5511;

        public override ushort MessageID => ProtocolId;

        public bool Ready { get; set; }
        public ushort Step { get; set; }
        public ExchangeReadyMessage() { }

        public ExchangeReadyMessage( bool Ready, ushort Step ){
            this.Ready = Ready;
            this.Step = Step;
        }

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
