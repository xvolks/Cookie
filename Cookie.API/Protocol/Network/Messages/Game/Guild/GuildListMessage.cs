using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6413;

        public GuildListMessage(List<GuildInformations> guilds)
        {
            Guilds = guilds;
        }

        public GuildListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<GuildInformations> Guilds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Guilds.Count);
            for (var guildsIndex = 0; guildsIndex < Guilds.Count; guildsIndex++)
            {
                var objectToSend = Guilds[guildsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var guildsCount = reader.ReadUShort();
            Guilds = new List<GuildInformations>();
            for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
            {
                var objectToAdd = new GuildInformations();
                objectToAdd.Deserialize(reader);
                Guilds.Add(objectToAdd);
            }
        }
    }
}