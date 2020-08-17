using Cookie.API.Protocol.Network.Types.Game.Guild;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceModificationValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6450;

        public AllianceModificationValidMessage(string allianceName, string allianceTag, GuildEmblem alliancemblem)
        {
            AllianceName = allianceName;
            AllianceTag = allianceTag;
            Alliancemblem = alliancemblem;
        }

        public AllianceModificationValidMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string AllianceName { get; set; }
        public string AllianceTag { get; set; }
        public GuildEmblem Alliancemblem { get; set; }

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