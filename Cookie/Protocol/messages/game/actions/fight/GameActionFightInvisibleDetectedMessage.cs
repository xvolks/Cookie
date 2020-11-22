using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightInvisibleDetectedMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 6320;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public short CellId = 0;

        public GameActionFightInvisibleDetectedMessage(): base()
        {
        }

        public GameActionFightInvisibleDetectedMessage(
            short actionId,
            double sourceId,
            double targetId,
            short cellId
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            CellId = cellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(CellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            CellId = reader.ReadShort();
        }
    }
}