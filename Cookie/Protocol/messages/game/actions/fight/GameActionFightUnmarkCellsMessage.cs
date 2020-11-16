using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightUnmarkCellsMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5570;
        public override uint MessageID { get { return ProtocolId; } }

        public short MarkId = 0;

        public GameActionFightUnmarkCellsMessage(): base()
        {
        }

        public GameActionFightUnmarkCellsMessage(
            short actionId,
            double sourceId,
            short markId
        ): base(
            actionId,
            sourceId
        )
        {
            MarkId = markId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MarkId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MarkId = reader.ReadShort();
        }
    }
}