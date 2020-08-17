using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Guild;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildInformationsMembersMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5558;

        public GuildInformationsMembersMessage(List<GuildMember> members)
        {
            Members = members;
        }

        public GuildInformationsMembersMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<GuildMember> Members { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Members.Count);
            for (var membersIndex = 0; membersIndex < Members.Count; membersIndex++)
            {
                var objectToSend = Members[membersIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var membersCount = reader.ReadUShort();
            Members = new List<GuildMember>();
            for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
            {
                var objectToAdd = new GuildMember();
                objectToAdd.Deserialize(reader);
                Members.Add(objectToAdd);
            }
        }
    }
}