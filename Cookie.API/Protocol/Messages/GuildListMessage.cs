using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6413;

        public override ushort MessageID => ProtocolId;

        public List<GuildInformations> Guilds { get; set; }
        public GuildListMessage() { }

        public GuildListMessage( List<GuildInformations> Guilds ){
            this.Guilds = Guilds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Guilds.Count);
			foreach (var x in Guilds)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var GuildsCount = reader.ReadShort();
            Guilds = new List<GuildInformations>();
            for (var i = 0; i < GuildsCount; i++)
            {
                var objectToAdd = new GuildInformations();
                objectToAdd.Deserialize(reader);
                Guilds.Add(objectToAdd);
            }
        }
    }
}
