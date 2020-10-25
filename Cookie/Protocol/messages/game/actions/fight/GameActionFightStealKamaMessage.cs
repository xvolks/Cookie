using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightStealKamaMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5535;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public long Amount = 0;

        public GameActionFightStealKamaMessage(): base()
        {
        }

        public GameActionFightStealKamaMessage(
            short actionId,
            double sourceId,
            double targetId,
            long amount
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            Amount = amount;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarLong(Amount);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Amount = reader.ReadVarLong();
        }
    }
}