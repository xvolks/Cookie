using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightLifeAndShieldPointsLostMessage : GameActionFightLifePointsLostMessage
    {
        public new const ushort ProtocolId = 6310;

        public GameActionFightLifeAndShieldPointsLostMessage(ushort shieldLoss)
        {
            ShieldLoss = shieldLoss;
        }

        public GameActionFightLifeAndShieldPointsLostMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ShieldLoss { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ShieldLoss);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ShieldLoss = reader.ReadVarUhShort();
        }
    }
}