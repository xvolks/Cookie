using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightOptionStateUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5927;

        public GameFightOptionStateUpdateMessage(short fightId, byte teamId, byte option, bool state)
        {
            FightId = fightId;
            TeamId = teamId;
            Option = option;
            State = state;
        }

        public GameFightOptionStateUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public short FightId { get; set; }
        public byte TeamId { get; set; }
        public byte Option { get; set; }
        public bool State { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(FightId);
            writer.WriteByte(TeamId);
            writer.WriteByte(Option);
            writer.WriteBoolean(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadShort();
            TeamId = reader.ReadByte();
            Option = reader.ReadByte();
            State = reader.ReadBoolean();
        }
    }
}