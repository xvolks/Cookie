using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceCreationValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6393;

        public override ushort MessageID => ProtocolId;

        public string AllianceName { get; set; }
        public string AllianceTag { get; set; }
        public GuildEmblem AllianceEmblem { get; set; }
        public AllianceCreationValidMessage() { }

        public AllianceCreationValidMessage( string AllianceName, string AllianceTag, GuildEmblem AllianceEmblem ){
            this.AllianceName = AllianceName;
            this.AllianceTag = AllianceTag;
            this.AllianceEmblem = AllianceEmblem;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(AllianceName);
            writer.WriteUTF(AllianceTag);
            AllianceEmblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceName = reader.ReadUTF();
            AllianceTag = reader.ReadUTF();
            AllianceEmblem = new GuildEmblem();
            AllianceEmblem.Deserialize(reader);
        }
    }
}
