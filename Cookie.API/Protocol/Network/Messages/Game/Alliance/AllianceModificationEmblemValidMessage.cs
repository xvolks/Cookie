using Cookie.API.Protocol.Network.Types.Game.Guild;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceModificationEmblemValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6447;

        public AllianceModificationEmblemValidMessage(GuildEmblem alliancemblem)
        {
            Alliancemblem = alliancemblem;
        }

        public AllianceModificationEmblemValidMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public GuildEmblem Alliancemblem { get; set; }

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