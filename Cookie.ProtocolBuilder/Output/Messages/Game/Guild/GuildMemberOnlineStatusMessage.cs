namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildMemberOnlineStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6061;
        public override ushort MessageID => ProtocolId;
        public ulong MemberId { get; set; }
        public bool Online { get; set; }

        public GuildMemberOnlineStatusMessage(ulong memberId, bool online)
        {
            MemberId = memberId;
            Online = online;
        }

        public GuildMemberOnlineStatusMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(MemberId);
            writer.WriteBoolean(Online);
        }

        public override void Deserialize(IDataReader reader)
        {
            MemberId = reader.ReadVarUhLong();
            Online = reader.ReadBoolean();
        }

    }
}
