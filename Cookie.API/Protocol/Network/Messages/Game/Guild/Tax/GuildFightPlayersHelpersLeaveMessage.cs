using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class GuildFightPlayersHelpersLeaveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5719;

        public GuildFightPlayersHelpersLeaveMessage(int fightId, ulong playerId)
        {
            FightId = fightId;
            PlayerId = playerId;
        }

        public GuildFightPlayersHelpersLeaveMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }
        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            PlayerId = reader.ReadVarUhLong();
        }
    }
}