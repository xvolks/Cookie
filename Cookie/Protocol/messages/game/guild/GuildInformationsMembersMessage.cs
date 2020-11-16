using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildInformationsMembersMessage : NetworkMessage
    {
        public const uint ProtocolId = 5558;
        public override uint MessageID { get { return ProtocolId; } }

        public List<GuildMember> Members;

        public GuildInformationsMembersMessage()
        {
        }

        public GuildInformationsMembersMessage(
            List<GuildMember> members
        )
        {
            Members = members;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Members.Count());
            foreach (var current in Members)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countMembers = reader.ReadShort();
            Members = new List<GuildMember>();
            for (short i = 0; i < countMembers; i++)
            {
                GuildMember type = new GuildMember();
                type.Deserialize(reader);
                Members.Add(type);
            }
        }
    }
}