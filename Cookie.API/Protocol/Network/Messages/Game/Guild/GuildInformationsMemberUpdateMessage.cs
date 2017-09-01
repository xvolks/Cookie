using Cookie.API.Protocol.Network.Types.Game.Guild;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildInformationsMemberUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5597;

        public GuildInformationsMemberUpdateMessage(GuildMember member)
        {
            Member = member;
        }

        public GuildInformationsMemberUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public GuildMember Member { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Member.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Member = new GuildMember();
            Member.Deserialize(reader);
        }
    }
}