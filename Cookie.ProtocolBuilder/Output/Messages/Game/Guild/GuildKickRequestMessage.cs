namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildKickRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5887;
        public override ushort MessageID => ProtocolId;
        public ulong KickedId { get; set; }

        public GuildKickRequestMessage(ulong kickedId)
        {
            KickedId = kickedId;
        }

        public GuildKickRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(KickedId);
        }

        public override void Deserialize(IDataReader reader)
        {
            KickedId = reader.ReadVarUhLong();
        }

    }
}
