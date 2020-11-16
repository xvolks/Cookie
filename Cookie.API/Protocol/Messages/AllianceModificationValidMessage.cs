using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceModificationValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6450;

        public override ushort MessageID => ProtocolId;

        public string AllianceName { get; set; }
        public string AllianceTag { get; set; }
        public GuildEmblem Alliancemblem { get; set; }
        public AllianceModificationValidMessage() { }

        public AllianceModificationValidMessage( string AllianceName, string AllianceTag, GuildEmblem Alliancemblem ){
            this.AllianceName = AllianceName;
            this.AllianceTag = AllianceTag;
            this.Alliancemblem = Alliancemblem;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(AllianceName);
            writer.WriteUTF(AllianceTag);
            Alliancemblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceName = reader.ReadUTF();
            AllianceTag = reader.ReadUTF();
            Alliancemblem = new GuildEmblem();
            Alliancemblem.Deserialize(reader);
        }
    }
}
