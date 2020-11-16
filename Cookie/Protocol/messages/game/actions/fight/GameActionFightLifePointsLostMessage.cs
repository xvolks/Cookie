using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightLifePointsLostMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 6312;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public int Loss = 0;
        public int PermanentDamages = 0;
        public int ElementId = 0;

        public GameActionFightLifePointsLostMessage(): base()
        {
        }

        public GameActionFightLifePointsLostMessage(
            short actionId,
            double sourceId,
            double targetId,
            int loss,
            int permanentDamages,
            int elementId
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            Loss = loss;
            PermanentDamages = permanentDamages;
            ElementId = elementId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarInt(Loss);
            writer.WriteVarInt(PermanentDamages);
            writer.WriteVarInt(ElementId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Loss = reader.ReadVarInt();
            PermanentDamages = reader.ReadVarInt();
            ElementId = reader.ReadVarInt();
        }
    }
}