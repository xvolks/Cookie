using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    public class GameRolePlayPlayerFightFriendlyAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5732;

        public GameRolePlayPlayerFightFriendlyAnswerMessage(int fightId, bool accept)
        {
            FightId = fightId;
            Accept = accept;
        }

        public GameRolePlayPlayerFightFriendlyAnswerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }
        public bool Accept { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            Accept = reader.ReadBoolean();
        }
    }
}