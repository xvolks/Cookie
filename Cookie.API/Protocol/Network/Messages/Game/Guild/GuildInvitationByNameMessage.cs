namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildInvitationByNameMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6115;
        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }

        public GuildInvitationByNameMessage(string name)
        {
            Name = name;
        }

        public GuildInvitationByNameMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
        }

    }
}
