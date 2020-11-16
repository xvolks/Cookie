using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightDodgePointLossMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5828;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public short Amount = 0;

        public GameActionFightDodgePointLossMessage(): base()
        {
        }

        public GameActionFightDodgePointLossMessage(
            short actionId,
            double sourceId,
            double targetId,
            short amount
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
            writer.WriteVarShort(Amount);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Amount = reader.ReadVarShort();
        }
    }
}