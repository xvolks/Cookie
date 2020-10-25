using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6413;
        public override uint MessageID { get { return ProtocolId; } }

        public List<GuildInformations> Guilds;

        public GuildListMessage()
        {
        }

        public GuildListMessage(
            List<GuildInformations> guilds
        )
        {
            Guilds = guilds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Guilds.Count());
            foreach (var current in Guilds)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countGuilds = reader.ReadShort();
            Guilds = new List<GuildInformations>();
            for (short i = 0; i < countGuilds; i++)
            {
                GuildInformations type = new GuildInformations();
                type.Deserialize(reader);
                Guilds.Add(type);
            }
        }
    }
}