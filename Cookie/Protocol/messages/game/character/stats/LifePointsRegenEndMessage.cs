using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LifePointsRegenEndMessage : UpdateLifePointsMessage
    {
        public new const uint ProtocolId = 5686;
        public override uint MessageID { get { return ProtocolId; } }

        public int LifePointsGained = 0;

        public LifePointsRegenEndMessage(): base()
        {
        }

        public LifePointsRegenEndMessage(
            int lifePoints,
            int maxLifePoints,
            int lifePointsGained
        ): base(
            lifePoints,
            maxLifePoints
        )
        {
            LifePointsGained = lifePointsGained;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(LifePointsGained);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            LifePointsGained = reader.ReadVarInt();
        }
    }
}