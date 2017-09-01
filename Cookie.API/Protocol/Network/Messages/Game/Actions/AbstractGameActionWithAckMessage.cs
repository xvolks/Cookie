using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions
{
    public class AbstractGameActionWithAckMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 1001;

        public AbstractGameActionWithAckMessage(short waitAckId)
        {
            WaitAckId = waitAckId;
        }

        public AbstractGameActionWithAckMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public short WaitAckId { get; set; }

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