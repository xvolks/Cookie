using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightSlideMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5525;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public short StartCellId = 0;
        public short EndCellId = 0;

        public GameActionFightSlideMessage(): base()
        {
        }

        public GameActionFightSlideMessage(
            short actionId,
            double sourceId,
            double targetId,
            short startCellId,
            short endCellId
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            StartCellId = startCellId;
            EndCellId = endCellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(StartCellId);
            writer.WriteShort(EndCellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            StartCellId = reader.ReadShort();
            EndCellId = reader.ReadShort();
        }
    }
}