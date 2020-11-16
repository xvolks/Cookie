using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceModificationEmblemValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6447;

        public override ushort MessageID => ProtocolId;

        public GuildEmblem Alliancemblem { get; set; }
        public AllianceModificationEmblemValidMessage() { }

        public AllianceModificationEmblemValidMessage( GuildEmblem Alliancemblem ){
            this.Alliancemblem = Alliancemblem;
        }

        public override void Serialize(IDataWriter writer)
        {
            Alliancemblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Alliancemblem = new GuildEmblem();
            Alliancemblem.Deserialize(reader);
        }
    }
}
