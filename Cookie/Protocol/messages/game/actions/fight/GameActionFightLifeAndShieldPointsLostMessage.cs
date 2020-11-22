using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightLifeAndShieldPointsLostMessage : GameActionFightLifePointsLostMessage
    {
        public new const uint ProtocolId = 6310;
        public override uint MessageID { get { return ProtocolId; } }

        public short ShieldLoss = 0;

        public GameActionFightLifeAndShieldPointsLostMessage(): base()
        {
        }

        public GameActionFightLifeAndShieldPointsLostMessage(
            short actionId,
            double sourceId,
            double targetId,
            int loss,
            int permanentDamages,
            int elementId,
            short shieldLoss
        ): base(
            actionId,
            sourceId,
            targetId,
            loss,
            permanentDamages,
            elementId
        )
        {
            ShieldLoss = shieldLoss;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(ShieldLoss);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ShieldLoss = reader.ReadVarShort();
        }
    }
}