using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightLifePointsGainMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 6311;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public int Delta = 0;

        public GameActionFightLifePointsGainMessage(): base()
        {
        }

        public GameActionFightLifePointsGainMessage(
            short actionId,
            double sourceId,
            double targetId,
            int delta
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            Delta = delta;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarInt(Delta);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Delta = reader.ReadVarInt();
        }
    }
}