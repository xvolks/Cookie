using Cookie.API.Protocol.Network.Types.Game.Guild;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceCreationValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6393;

        public AllianceCreationValidMessage(string allianceName, string allianceTag, GuildEmblem allianceEmblem)
        {
            AllianceName = allianceName;
            AllianceTag = allianceTag;
            AllianceEmblem = allianceEmblem;
        }

        public AllianceCreationValidMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string AllianceName { get; set; }
        public string AllianceTag { get; set; }
        public GuildEmblem AllianceEmblem { get; set; }

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