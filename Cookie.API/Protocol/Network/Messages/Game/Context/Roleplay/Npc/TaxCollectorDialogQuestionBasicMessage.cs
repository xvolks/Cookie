using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    public class TaxCollectorDialogQuestionBasicMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5619;

        public TaxCollectorDialogQuestionBasicMessage(BasicGuildInformations guildInfo)
        {
            GuildInfo = guildInfo;
        }

        public TaxCollectorDialogQuestionBasicMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public BasicGuildInformations GuildInfo { get; set; }

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