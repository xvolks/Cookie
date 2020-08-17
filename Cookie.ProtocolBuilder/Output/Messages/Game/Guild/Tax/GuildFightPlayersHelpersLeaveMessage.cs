namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Utils.IO;

    public class GuildFightPlayersHelpersLeaveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5719;
        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }
        public ulong PlayerId { get; set; }

        public GuildFightPlayersHelpersLeaveMessage(int fightId, ulong playerId)
        {
            FightId = fightId;
            PlayerId = playerId;
        }

        public GuildFightPlayersHelpersLeaveMessage() { }

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
