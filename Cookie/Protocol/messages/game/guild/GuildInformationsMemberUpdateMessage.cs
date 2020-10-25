using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildInformationsMemberUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5597;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildMember Member;

        public GuildInformationsMemberUpdateMessage()
        {
        }

        public GuildInformationsMemberUpdateMessage(
            GuildMember member
        )
        {
            Member = member;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Member.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Member = new GuildMember();
            Member.Deserialize(reader);
        }
    }
}