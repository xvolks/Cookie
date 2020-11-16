using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightReduceDamagesMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5526;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public int Amount = 0;

        public GameActionFightReduceDamagesMessage(): base()
        {
        }

        public GameActionFightReduceDamagesMessage(
            short actionId,
            double sourceId,
            double targetId,
            int amount
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
            writer.WriteVarInt(Amount);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Amount = reader.ReadVarInt();
        }
    }
}