using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class UpdateLifePointsMessage : NetworkMessage
    {
        public const uint ProtocolId = 5658;
        public override uint MessageID { get { return ProtocolId; } }

        public int LifePoints = 0;
        public int MaxLifePoints = 0;

        public UpdateLifePointsMessage()
        {
        }

        public UpdateLifePointsMessage(
            int lifePoints,
            int maxLifePoints
        )
        {
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(LifePoints);
            writer.WriteVarInt(MaxLifePoints);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            LifePoints = reader.ReadVarInt();
            MaxLifePoints = reader.ReadVarInt();
        }
    }
}