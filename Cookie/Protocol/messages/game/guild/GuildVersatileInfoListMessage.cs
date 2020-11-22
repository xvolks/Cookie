using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildVersatileInfoListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6435;
        public override uint MessageID { get { return ProtocolId; } }

        public List<GuildVersatileInformations> Guilds;

        public GuildVersatileInfoListMessage()
        {
        }

        public GuildVersatileInfoListMessage(
            List<GuildVersatileInformations> guilds
        )
        {
            Guilds = guilds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Guilds.Count());
            foreach (var current in Guilds)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countGuilds = reader.ReadShort();
            Guilds = new List<GuildVersatileInformations>();
            for (short i = 0; i < countGuilds; i++)
            {
                var guildstypeId = reader.ReadShort();
                GuildVersatileInformations type = new GuildVersatileInformations();
                type.Deserialize(reader);
                Guilds.Add(type);
            }
        }
    }
}