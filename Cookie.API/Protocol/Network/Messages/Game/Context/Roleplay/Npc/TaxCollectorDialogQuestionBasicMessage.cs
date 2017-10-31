namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class TaxCollectorDialogQuestionBasicMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5619;
        public override ushort MessageID => ProtocolId;
        public BasicGuildInformations GuildInfo { get; set; }

        public TaxCollectorDialogQuestionBasicMessage(BasicGuildInformations guildInfo)
        {
            GuildInfo = guildInfo;
        }

        public TaxCollectorDialogQuestionBasicMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildInfo = new BasicGuildInformations();
            GuildInfo.Deserialize(reader);
        }

    }
}
