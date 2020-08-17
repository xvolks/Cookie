using Cookie.API.Protocol.Network.Types.Game.Guild;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class AllianceInformations : BasicNamedAllianceInformations
    {
        public new const ushort ProtocolId = 417;

        public AllianceInformations(GuildEmblem allianceEmblem)
        {
            AllianceEmblem = allianceEmblem;
        }

        public AllianceInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public GuildEmblem AllianceEmblem { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceEmblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceEmblem = new GuildEmblem();
            AllianceEmblem.Deserialize(reader);
        }
    }
}