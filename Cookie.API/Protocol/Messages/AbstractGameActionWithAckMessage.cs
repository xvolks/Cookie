using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AbstractGameActionWithAckMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 1001;

        public override ushort MessageID => ProtocolId;

        public short WaitAckId { get; set; }
        public AbstractGameActionWithAckMessage() { }

        public AbstractGameActionWithAckMessage( short WaitAckId ){
            this.WaitAckId = WaitAckId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WaitAckId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WaitAckId = reader.ReadShort();
        }
    }
}
