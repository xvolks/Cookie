using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TaxCollectorDialogQuestionBasicMessage : NetworkMessage
    {
        public const uint ProtocolId = 5619;
        public override uint MessageID { get { return ProtocolId; } }

        public BasicGuildInformations GuildInfo;

        public TaxCollectorDialogQuestionBasicMessage()
        {
        }

        public TaxCollectorDialogQuestionBasicMessage(
            BasicGuildInformations guildInfo
        )
        {
            GuildInfo = guildInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuildInfo = new BasicGuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}