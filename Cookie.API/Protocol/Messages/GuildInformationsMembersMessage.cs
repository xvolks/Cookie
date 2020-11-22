using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildInformationsMembersMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5558;

        public override ushort MessageID => ProtocolId;

        public List<GuildMember> Members { get; set; }
        public GuildInformationsMembersMessage() { }

        public GuildInformationsMembersMessage( List<GuildMember> Members ){
            this.Members = Members;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Members.Count);
			foreach (var x in Members)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var MembersCount = reader.ReadShort();
            Members = new List<GuildMember>();
            for (var i = 0; i < MembersCount; i++)
            {
                var objectToAdd = new GuildMember();
                objectToAdd.Deserialize(reader);
                Members.Add(objectToAdd);
            }
        }
    }
}
