using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightJoinRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 701;

        public GameFightJoinRequestMessage(double fighterId, int fightId)
        {
            FighterId = fighterId;
            FightId = fightId;
        }

        public GameFightJoinRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double FighterId { get; set; }
        public int FightId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FighterId);
            writer.WriteInt(FightId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FighterId = reader.ReadDouble();
            FightId = reader.ReadInt();
        }
    }
}