using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightExchangePositionsMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5527;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public short CasterCellId = 0;
        public short TargetCellId = 0;

        public GameActionFightExchangePositionsMessage(): base()
        {
        }

        public GameActionFightExchangePositionsMessage(
            short actionId,
            double sourceId,
            double targetId,
            short casterCellId,
            short targetCellId
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            CasterCellId = casterCellId;
            TargetCellId = targetCellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(CasterCellId);
            writer.WriteShort(TargetCellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            CasterCellId = reader.ReadShort();
            TargetCellId = reader.ReadShort();
        }
    }
}