using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TaxCollectorDialogQuestionBasicMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5619;

        public override ushort MessageID => ProtocolId;

        public BasicGuildInformations GuildInfo { get; set; }
        public TaxCollectorDialogQuestionBasicMessage() { }

        public TaxCollectorDialogQuestionBasicMessage( BasicGuildInformations GuildInfo ){
            this.GuildInfo = GuildInfo;
        }

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
