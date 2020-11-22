using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AbstractGameActionWithAckMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 1001;
        public override uint MessageID { get { return ProtocolId; } }

        public short WaitAckId = 0;

        public AbstractGameActionWithAckMessage(): base()
        {
        }

        public AbstractGameActionWithAckMessage(
            short actionId,
            double sourceId,
            short waitAckId
        ): base(
            actionId,
            sourceId
        )
        {
            WaitAckId = waitAckId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WaitAckId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            WaitAckId = reader.ReadShort();
        }
    }
}