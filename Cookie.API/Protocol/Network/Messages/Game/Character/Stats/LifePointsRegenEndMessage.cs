using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Stats
{
    public class LifePointsRegenEndMessage : UpdateLifePointsMessage
    {
        public new const ushort ProtocolId = 5686;

        public LifePointsRegenEndMessage(uint lifePointsGained)
        {
            LifePointsGained = lifePointsGained;
        }

        public LifePointsRegenEndMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint LifePointsGained { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(LifePointsGained);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LifePointsGained = reader.ReadVarUhInt();
        }
    }
}